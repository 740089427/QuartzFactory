using System;
using System.Threading.Tasks;


namespace Quartz.netLesson8Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Test1ScheduleAction : IScheduleAction
    {
     
        public async Task Start()
        {
             Console.WriteLine(DateTime.Now+":test1");
        }

        public async Task End()
        {
            await Task.FromResult(0);
        }
    }
}
