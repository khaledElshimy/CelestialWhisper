namespace CM.MVC.Interfaces
{
    /// <summary>
    /// Interface defining the basic operations for a controller in the MVC pattern.
    /// </summary>
    /// <typeparam name="M">The type of the model managed by the controller.</typeparam>
    /// <typeparam name="V">The type of the view managed by the controller.</typeparam>
    public interface IController<M, V> 
        where M : IModel 
        where V : IView
    {
        /// <summary>
        /// Gets the model associated with the controller.
        /// </summary>
        IModel Model { get; }

        /// <summary>
        /// Gets the view associated with the controller.
        /// </summary>
        IView View { get; }

        /// <summary>
        /// Sets up the controller by initializing the model and view.
        /// </summary>
        void Setup();
    }
}
