using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SpriteSheetCommon
{
    public class CompositionHost<T,TMetadata> where T: class where TMetadata: class
    {
        private CompositionContainer _container;

        [ImportMany]
        private IEnumerable<Lazy<T, TMetadata>> _plugins;

        public CompositionHost(string pluginDirectory)
        {
           
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(pluginDirectory));
            this._container = new CompositionContainer(catalog);
            this._container.ComposeParts(this);
        }

        public IEnumerable<Lazy<T, TMetadata>> GetLoadedPlugins()
        {
            return this._plugins;
        }
    }
}
