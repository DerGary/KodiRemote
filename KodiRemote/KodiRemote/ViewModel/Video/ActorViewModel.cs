using KodiRemote.Code.Database.MovieTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel.Video {
    public class ActorViewModel : ItemViewModel {
        public string Role { get; set; }

        public ActorViewModel(MovieActorMapper item) : base(item.Actor) {
            this.Role = item.Role;
        }
    }
}
