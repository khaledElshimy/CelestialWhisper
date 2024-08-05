namespace CM.MVC.Interfaces
{
    public interface IController<M, V> where M:IModel where V: IView
    {
        IModel Model{ get; }
        IView View { get; }
        void Setup();
    }
}