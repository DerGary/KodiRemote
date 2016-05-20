using Microsoft.Data.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database.Utils {
    public class DatabaseWrapper<T>  where T : TableEntryBase, new() {
        //private List<T> list = null;
        private Dictionary<string, T> dic = null;
        private Dictionary<string, T> toAdd = new Dictionary<string, T>();
        private Dictionary<string, T> toRemove = new Dictionary<string, T>();
        private Dictionary<string, T> toUpdate = new Dictionary<string, T>();
        private int nextId = -1;
        private PropertyInfo keyProperty = null;
        private DatabaseContextWrapper wrapper;

        public DatabaseWrapper(DatabaseContextWrapper wrapper){
            this.wrapper = wrapper;

            foreach (var prop in typeof(T).GetProperties()) {
                if(prop.PropertyType == typeof(int)) {
                    AutoIncrementAttribute att = prop.GetCustomAttribute<AutoIncrementAttribute>();
                    if(att != null) {
                        keyProperty = prop;
                    }
                }
            }
        }

        public async Task EnsureData() {
            if (dic == null) {
                using (var context = wrapper.CreateContext()) {
                    dic = new Dictionary<string, T>();
                    var list = await context.Set<T>().AsNoTracking().ToListAsync();
                    foreach(var item in list) {
                        dic.Add(item.Key, item);
                        if(keyProperty != null) {
                            int id = (int)keyProperty.GetValue(item);
                            if(id > nextId) {
                                nextId = id + 1;
                            }
                        }
                    }
                    if (nextId == -1) {
                        nextId = 1;
                    }
                }
            }
        }

        public async Task<bool> AnyAsync(Func<T,bool> expression) {
            await EnsureData();
            return dic.Values.Any(expression);
        }
        public async Task<InsertOrUpdate> InsertOrUpdateAsync(T item) {
            await EnsureData();
            T first;
            dic.TryGetValue(item.Key, out first);
            if (first == null) {
                if(keyProperty != null) {
                    keyProperty.SetValue(item, nextId);
                    nextId++;
                }
                toAdd.Add(item.Key, item);
                dic.Add(item.Key, item);
                return InsertOrUpdate.Insert;
            } else {
                if(keyProperty != null) {
                    keyProperty.SetValue(item, keyProperty.GetValue(first));
                }
                if (item.Equals(first)) { //if the item is completely equal with the current db state then dont add it do be updated
                    return InsertOrUpdate.Update;
                }
                dic.Remove(first.Key);
                dic.Add(item.Key, item);
                T firstToUpdate;
                toUpdate.TryGetValue(item.Key, out firstToUpdate);
                if(firstToUpdate != null) {
                    toUpdate.Remove(item.Key);
                }
                toUpdate.Add(item.Key, item);
                return InsertOrUpdate.Update;
            }
        }

        public async Task<T> FirstOrDefaultAsync(Func<T, bool> expression) {
            await EnsureData();
            return dic.Values.FirstOrDefault(expression);
        }

        public async Task RemoveAsync(T item) {
            await EnsureData();
            T first;
            dic.TryGetValue(item.Key, out first);
            if(keyProperty != null) {
                keyProperty.SetValue(item, keyProperty.GetValue(first));
            }
            dic.Remove(item.Key);
            toRemove.Add(item.Key, item);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> items) {
            foreach(T item in items) {
                await RemoveAsync(item);
            }
        }

        public async Task RemoveAllAsync(Func<T, bool> expression) {
            await EnsureData();
            var remove = dic.Values.Where(expression).ToList();
            foreach(T item in remove) {
                dic.Remove(item.Key);
                toRemove.Add(item.Key, item);
            }
        }

        public async Task<IEnumerable<T>> WhereAsync(Func<T, bool> expression) {
            await EnsureData();
            return dic.Values.Where(expression);
        }
        
        public async Task SaveChangesAsync() {
            await DoDatabaseOperation(toRemove, (DatabaseContext context, T x) => context.Set<T>().Remove(x));
            await DoDatabaseOperation(toAdd, (DatabaseContext context, T x) => context.Set<T>().Add(x));
            await DoDatabaseOperation(toUpdate, (DatabaseContext context, T x) => context.Set<T>().Update(x));
            //if (toRemove.Any()) {
            //    using (var context = wrapper.CreateContext()) {
            //        context.Set<T>().RemoveRange(toRemove.Values);
            //        await context.SaveChangesAsync();
            //        toUpdate.Clear();
            //    }
            //}
            //if (toAdd.Any()) {
            //    using (var context = wrapper.CreateContext()) {
            //        context.Set<T>().AddRange(toAdd.Values);
            //        await context.SaveChangesAsync();
            //        toUpdate.Clear();
            //    }
            //}
            //if (toUpdate.Any()) {
            //    using (var context = wrapper.CreateContext()) {
            //        context.Set<T>().UpdateRange(toUpdate.Values);
            //        await context.SaveChangesAsync();
            //        toUpdate.Clear();
            //    }
            //}
        }

        public async Task DoDatabaseOperation(Dictionary<string, T> values, Action<DatabaseContext, T> action) {
            if (values.Any()) {
                int i = 0;
                var context = wrapper.CreateContext();
                foreach (var item in values.Values) {
                    i++;
                    action.Invoke(context, item);
                    if (i % 1000 == 0) {
                        await context.SaveChangesAsync();
                        context.Dispose();
                        context = wrapper.CreateContext();
                    }
                }
                await context.SaveChangesAsync();
                context.Dispose();
                values.Clear();
            }
        }
    }
}
