using Broobu.ManageQso.Contract.Agent;
using Broobu.ManageQso.Contract.Interfaces;

namespace Broobu.ManageQso.Contract
{
    public static class ManageQsoPortal
    {
        public static IManageQsoAgent Agent
        {
            get { return new ManageQsoAgent(); }
        }
    }
}
