using KodiRemote.ViewModel.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KodiRemote.View.TemplateSelector {
    public class ListViewTemplateSelector : DataTemplateSelector {
        public DataTemplate EpisodeTemplate { get; set; }
        public DataTemplate MovieTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item) {
            if(item is EpisodeViewModel) {
                return EpisodeTemplate;
            }else if(item is MovieViewModel) {
                return MovieTemplate;
            }
            return base.SelectTemplateCore(item);
        }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container) {
            return SelectTemplateCore(item);
        }
    }
}
