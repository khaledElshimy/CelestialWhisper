namespace CM.MVC.Interfaces
{
    /// <summary>
    /// Interface defining the basic operations for a model in the MVC pattern.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Gets the unique identifier for the model.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Initializes the data for the model.
        /// </summary>
        void InitializeData();
    }
}
