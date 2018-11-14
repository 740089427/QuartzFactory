using System;
using System.Threading.Tasks;

namespace Quartz.netLesson8Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Test2ScheduleAction : IScheduleAction
    {

        public async Task Start()
        {
            Console.WriteLine(DateTime.Now + ":test2");
        }

        public async Task End()
        {
            await Task.FromResult(0);
        }
    }
}