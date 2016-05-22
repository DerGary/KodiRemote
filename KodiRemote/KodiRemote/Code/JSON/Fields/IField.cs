using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public interface IField {
        void All();
        List<string> ToList();
        void Mine();
    }
    public abstract class Field<T> : IField where T : IField, new() {
        public abstract void All();
        public abstract void Mine();

        public abstract List<string> ToList();
        public static T WithAll() {
            T all = new T();
            all.All();
            return all;
        }

        public static T WithMine() {
            T mine = new T();
            mine.Mine();
            return mine;
        }
    }
}
