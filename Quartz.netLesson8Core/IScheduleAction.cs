using System.Threading.Tasks;

namespace Quartz.netLesson8Core
{
    /// <summary>
    /// 批处理动作接口
    /// </summary>
    public interface IScheduleAction
    {
        /// <summary>
        /// 执行开始
        /// </summary>
        /// <returns></returns>
        Task Start();
        /// <summary>
        /// 执行结束
        /// </summary>
        /// <returns></returns>
        Task End();
    }
}