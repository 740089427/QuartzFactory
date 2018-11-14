using System.Threading.Tasks;

namespace Quartz.netLesson8Core
{
    /// <summary>
    ///     基于Quartz的批处理计划
    /// </summary>
    public class Scheduler 
    {
        private static IFactory<ISchedulerIMP> _schedulerIMPFactory;
        private readonly ISchedulerIMP _schedulerIMP;

        public Scheduler()
        {
            _schedulerIMP = _schedulerIMPFactory.Create();
        }

        public static IFactory<ISchedulerIMP> SchedulerIMPFactory
        {
            set => _schedulerIMPFactory = value;
        }
        /// <summary>
        /// 最大线程并行度
        /// </summary>
        public int MaxThreads
        {
            get;set;
        }

        /// <summary>
        /// 生成Quartz批处理计划
        /// </summary>
        /// <returns></returns>
        public Task< IScheduler> GenerateScheduler()
        {
            return _schedulerIMP.GenerateScheduler(this);
        }
    }

    public interface ISchedulerIMP
    {
        Task<IScheduler> GenerateScheduler(Scheduler scheduler);
    }
}