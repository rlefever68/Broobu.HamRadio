using Broobu.Fx.UI;
using Broobu.Fx.UI.Interfaces;

namespace Broobu.ManageQso.UI
{
    public class ManageQsoPlugin :PluginBase
    {
        protected override IPluginForm CreatePluginFormInternal()
        {
            return new ManageQsoWindow();
        }

    }
}
