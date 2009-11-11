using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Laos;

namespace Coal.BLL
{
    [Serializable]
    [global::System.AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class PermissionAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionEventArgs eventArgs)
        {
            LoginContext context = eventArgs.GetReadOnlyArgumentArray()[1] as LoginContext;

            if (context == null || context.UserId < 0)
            {
                eventArgs.FlowBehavior = FlowBehavior.Return;
                eventArgs.ReturnValue = false;
            }
        }
    }
}
