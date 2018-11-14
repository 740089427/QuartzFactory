namespace Quartz.netLesson8Core
{
    public class SchedulerIMPForCRMFactory : IFactory<ISchedulerIMP>
    {
        public ISchedulerIMP Create()
        {
            SchedulerConfigurationService schedulerConfigurationService = new SchedulerConfigurationService();
            SchedulerIMPForCRM schedulerImpForCrm = new SchedulerIMPForCRM(schedulerConfigurationService);
            return schedulerImpForCrm;
        }
    }
}
