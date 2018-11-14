namespace Quartz.netLesson8Core
{
    /// <summary>
    /// 批处理动作工厂
    /// </summary>
    public interface IScheduleActionFactory
    {
        IScheduleAction Create(string name);
    }
}