namespace Quartz.netLesson8Core
{   
    public class AppSchedulerControl 
    {
        private SchedulerRepository _schedulerIRepository;
        private IScheduler _qScheduler;

        public AppSchedulerControl (SchedulerRepository schedulerIRepository)
        {
            _schedulerIRepository = schedulerIRepository;
        }
        public void Continue()
        {
            if (_qScheduler!=null)
            {
                _qScheduler.ResumeAll();
            }
        }

        public void Pause()
        {
            if (_qScheduler != null)
            {
                _qScheduler.PauseAll();
            }
        }

        public void Start()
        {
            Stop();
            var schedulerMain = _schedulerIRepository.SetMainScheduler();
            _qScheduler = schedulerMain.GenerateScheduler().Result;
            _qScheduler.Start();
        }

        public void Stop()
        {
            if (_qScheduler != null)
            {
                _qScheduler.Shutdown(true);
            }
        }
    }
}
