using UnityEngine;

namespace CM.MVC.Interfaces
{
    public interface IView
    {
        GameObject gameObject{ get; }
        void Initialize();
    }
}
