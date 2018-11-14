using System;
using System.Collections.Generic;
 

namespace Quartz.netLesson8Core
{
    public class ScheduleActionFactory : IScheduleActionFactory
    {
        private static readonly Dictionary<string, IFactory<IScheduleAction>> _scheduleActions = new Dictionary<string, IFactory<IScheduleAction>>();

        public static Dictionary<string, IFactory<IScheduleAction>> ScheduleActions => _scheduleActions;

        public IScheduleAction Create(string name)
        {
            IFactory<IScheduleAction> actionFactory;

            if (!_scheduleActions.TryGetValue(name, out actionFactory))
            {
                throw new Exception(string.Format("not found ActionFactory {0} in ScheduleActionFactory.ScheduleActions", name));
            }
            var action = actionFactory.Create();
            return action;
        }
    }
}
