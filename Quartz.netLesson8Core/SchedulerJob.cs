using System;
using System.Threading.Tasks;

namespace Quartz.netLesson8Core
{
    /// <summary>
    /// 基于Quartz的批处理工作
    /// </summary>
    public class SchedulerJob
    {
        private static IFactory<IScheduleJobIMP> _scheduleJobIMPFactory=new ScheduleJobIMPFactory();

        public static IFactory<IScheduleJobIMP> ScheduleJobIMPFactory
        {
            set
            {
                _scheduleJobIMPFactory = value;
            }
        }

        private IScheduleJobIMP _scheduleJobIMP;

        public SchedulerJob()
        {
            _scheduleJobIMP = _scheduleJobIMPFactory.Create();
        }

        /// <summary>
        /// 工作名称
        /// </summary>
        public string Name
        {
            get
            ;
            set
            ;
        }

        /// <summary>
        /// 所属组名称
        /// </summary>
        public string GroupName
        {
            get
            ;
            set
            ;
        }

        /// <summary>
        /// 触发条件表达式
        /// </summary>
        public string CronExpression
        {
            get
            ;
            set
            ;
        }

        public IJobDetail GenerateJob()
        {
            return  _scheduleJobIMP.GenerateJob(this);
        } 

        public ITrigger GenerateTrigger()
        {
            return  _scheduleJobIMP.GenerateTrigger(this);
        }
    }


    public interface IScheduleJobIMP
    {
        IJobDetail GenerateJob(SchedulerJob sJob);
        ITrigger GenerateTrigger(SchedulerJob sJob);
    }

    public class ScheduleJobIMP : IScheduleJobIMP
    {
        private IScheduleActionFactory _scheduleActionFactory;
        public ScheduleJobIMP(IScheduleActionFactory scheduleActionFactory)
        {
            _scheduleActionFactory = scheduleActionFactory;
        }
        public IJobDetail GenerateJob(SchedulerJob sJob)
        {
            MainJob.ScheduleActionFactory = _scheduleActionFactory;
            IJobDetail job = JobBuilder.Create<MainJob>()
                                       .WithIdentity(sJob.Name, sJob.GroupName)
                                       .UsingJobData("Name", sJob.Name)
                                       .UsingJobData("ActionName", sJob.Name)
                                       .Build();

            return job;
        }

        public ITrigger GenerateTrigger(SchedulerJob sJob)
        {
            ITrigger trigger = TriggerBuilder.Create()
                                   .WithIdentity(sJob.Name, sJob.Name)
                                      .StartNow()
                                       .WithCronSchedule(sJob.CronExpression)
                                       .Build();
            return trigger;
        }

        [DisallowConcurrentExecution]
        private class MainJob : IJob
        {
            private static IScheduleActionFactory _scheduleActionFactory;

            public static IScheduleActionFactory ScheduleActionFactory
            {
                set
                {
                    _scheduleActionFactory = value;
                }
            }
            public  Task Execute(IJobExecutionContext context)
            {
                try
                {
                    var action = _scheduleActionFactory.Create(context.JobDetail.JobDataMap.GetString("ActionName"));
                   // Logger.WriteLog(string.Format("批处理工作{0}开始执行", context.JobDetail.JobDataMap.GetString("Name")), System.Diagnostics.EventLogEntryType.SuccessAudit);
                    action.Start().Wait();
                    action.End().Wait();
                   
                    //Logger.WriteLog(string.Format("批处理工作{0}执行结束", context.JobDetail.JobDataMap.GetString("Name")), System.Diagnostics.EventLogEntryType.SuccessAudit);                    
                }
                catch (Exception ex)
                {
                   // Logger.WriteLog(string.Format("批处理工作{0}执行出错，详细信息：{1}", context.JobDetail.JobDataMap.GetString("Name"), ex.ToString()), System.Diagnostics.EventLogEntryType.Error);
                }
                return Task.CompletedTask;
            }
        }
    }

    public class ScheduleJobIMPFactory : IFactory<IScheduleJobIMP>
    {
        public IScheduleJobIMP Create()
        {
            ScheduleActionFactory scheduleActionFactory = new ScheduleActionFactory();
            ScheduleJobIMP scheduleJobIMP = new ScheduleJobIMP(scheduleActionFactory);
            return scheduleJobIMP;
        }
    }
}
