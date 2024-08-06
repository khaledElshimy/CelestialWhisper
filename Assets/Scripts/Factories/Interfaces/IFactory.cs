using CM.MVC.Interfaces;

namespace CM.Factories.Interfaces
{
    /// <summary>
    /// Defines a factory interface for creating controllers with specific model, view, and controller types.
    /// </summary>
    /// <typeparam name="M">The type of model.</typeparam>
    /// <typeparam name="V">The type of view.</typeparam>
    /// <typeparam name="C">The type of controller, which must implement <see cref="IController{M, V}"/>.</typeparam>
    public interface IFactory<M, V, C>  
        where M : IModel 
        where V : IView 
        where C : IController<M, V> 
    {
        /// <summary>
        /// Creates and returns a controller instance.
        /// </summary>
        /// <returns>An instance of <see cref="IController{M, V}"/>.</returns>
        IController<M, V> Create();
    }
}
