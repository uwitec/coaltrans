using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Laos;

namespace Coal.AOP
{
    [Serializable]
    [global::System.AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class PermissionAttribute : OnMethodBoundaryAspect  
    {
        public override void OnEntry(MethodExecutionEventArgs eventArgs)
        {
            object[] args = eventArgs.GetReadOnlyArgumentArray();
            eventArgs.FlowBehavior = FlowBehavior.Return;
            eventArgs.ReturnValue = args[1].ToString() == "cheese1@sina.com";
        }
    }
}
