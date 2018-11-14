namespace Quartz.netLesson8Core
{
    public class ScheduleActionForTest2Factory : IFactory<IScheduleAction>
    {
        public IScheduleAction Create()
        {
            Test2ScheduleAction test2 = new Test2ScheduleAction();
            return test2;
        }
    }
}