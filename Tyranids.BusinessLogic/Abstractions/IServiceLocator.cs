namespace Tyranids.BusinessLogic.Abstractions
{
    public interface IServiceLocator
    {
        T Get<T>();
    }
}
