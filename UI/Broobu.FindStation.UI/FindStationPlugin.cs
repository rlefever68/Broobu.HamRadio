using Broobu.Fx.UI;
using Broobu.Fx.UI.Interfaces;

namespace Broobu.FindStation.UI
{
    public class FindStationPlugin : PluginBase
    {
        protected override IPluginForm CreatePluginFormInternal()
        {
            return new FindStationWindow();
        }
    }
}
