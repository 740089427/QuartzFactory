namespace Quartz.netLesson8Core
{
    public interface IFactory<T>
    {
        T Create();
    }
}