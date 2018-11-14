namespace Quartz.netLesson8Core
{
    public class ScheduleActionForTest1Factory : IFactory<IScheduleAction>
    {
        public IScheduleAction Create()
        {
            Test1ScheduleAction test1 = new Test1ScheduleAction();
            return test1;
        }
    }
}

