using System;

namespace Quartz.netLesson8Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Scheduler.SchedulerIMPFactory = new SchedulerIMPForCRMFactory();
            ScheduleActionFactory.ScheduleActions[ScheduleActionName.Test1.ToString()] = new ScheduleActionForTest1Factory();
            ScheduleActionFactory.ScheduleActions[ScheduleActionName.Test2.ToString()] = new ScheduleActionForTest2Factory();

            IFactory<AppSchedulerControl> appSchedulerControlFactory = new AppSchedulerControlFactory();
            var appSchedulerControl = appSchedulerControlFactory.Create();
            appSchedulerControl.Start();
            Console.ReadLine();
        }
    }
}
