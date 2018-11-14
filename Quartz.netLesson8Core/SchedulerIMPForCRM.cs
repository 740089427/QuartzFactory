using System.Collections.Specialized;
using System.Threading.Tasks;
using Quartz.Impl;

namespace Quartz.netLesson8Core
{
    public class SchedulerIMPForCRM : ISchedulerIMP
    {
        private SchedulerConfigurationService _schedulerConfigurationService;

        public SchedulerIMPForCRM(SchedulerConfigurationService schedulerConfigurationService)
        {
            _schedulerConfigurationService = schedulerConfigurationService;
        }
        public Task<IScheduler> GenerateScheduler(Scheduler scheduler)
        {
            var props = new NameValueCollection();
            //使用简单线程池      
            props["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            //最大线程数        
            props["quartz.threadPool.threadCount"] = scheduler.MaxThreads.ToString();
            //线程优先级：正常        
            props["quartz.threadPool.threadPriority"] = "Normal";
            props["quartz.jobStore.misfireThreshold"] = "240000";

            var schedulerFactory = new StdSchedulerFactory(props);
            var s = schedulerFactory.GetScheduler();

            var schedulersModel = _schedulerConfigurationService.GetData();
            var Jobs = schedulersModel.Jobs;
            if (Jobs != null)
            {
                foreach (var jobModel in Jobs)
                {
                    SchedulerJob schedulerJob = new SchedulerJob();
                    schedulerJob.Name = jobModel.JobName;
                    schedulerJob.GroupName = jobModel.GroupName;
                    schedulerJob.CronExpression = jobModel.CronExpression;

                    var j = schedulerJob.GenerateJob();
                    var t = schedulerJob.GenerateTrigger();
                    s.Result.ScheduleJob(j, t);
                }
            }
            return s;
        }
    }
}
