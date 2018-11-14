namespace Quartz.netLesson8Core
{
    public class AppSchedulerControlFactory : IFactory<AppSchedulerControl>
    {
        public AppSchedulerControl Create()
        {
            SchedulerConfigurationService schedulerConfigurationService = new SchedulerConfigurationService();
            SchedulerRepository schedulerRepository = new SchedulerRepository(schedulerConfigurationService);
            AppSchedulerControl appSchedulerControl = new AppSchedulerControl(schedulerRepository);

            return appSchedulerControl;
        }
    }
}
