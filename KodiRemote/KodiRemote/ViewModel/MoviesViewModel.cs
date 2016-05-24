using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel {
    public class MoviesViewModel : ViewModelBase {
        public async Task Init() {
            var result = Kodi.Database.Movies;

            Debug.WriteLine(result);
        }
    }
}
