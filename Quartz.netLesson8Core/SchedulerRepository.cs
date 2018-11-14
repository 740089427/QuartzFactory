namespace Quartz.netLesson8Core
{
    public class SchedulerRepository 
    {
        private SchedulerConfigurationService _schedulerConfigurationService;

        public SchedulerRepository(SchedulerConfigurationService schedulerConfigurationService)
        {
            _schedulerConfigurationService = schedulerConfigurationService;
        }

        public Scheduler SetMainScheduler()
        {
            Scheduler schedulerMain = new Scheduler();
            schedulerMain.MaxThreads = _schedulerConfigurationService.GetData().ThreadCount;
            return schedulerMain;
        }
    }
}
