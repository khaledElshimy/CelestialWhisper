using UnityEngine;

namespace CM.MVC.Interfaces
{
    /// <summary>
    /// Interface defining the basic operations for a view in the MVC pattern.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Gets the GameObject associated with the view.
        /// </summary>
        GameObject gameObject { get; }

        /// <summary>
        /// Initializes the view with the specified name and parent transform.
        /// </summary>
        /// <param name="name">The name to assign to the view.</param>
        /// <param name="parentTransform">The transform to set as the parent of the view.</param>
        void InitializeView(string name, Transform parentTransform);
    }
}
