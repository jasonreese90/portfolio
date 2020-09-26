using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginInterfaces
{
    public interface IDescriptionMetadata
    {
        string Description { get; }
        string Author { get; }
        double Version { get; }
        Image Icon { get; }
    }
}
