using UnityEngine;

namespace CM.MVC.Interfaces
{
    public interface IModel
    {
        int Id { get;}
        void InitializeData();
    }
}
