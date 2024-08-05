using CM.MVC.Interfaces;
using UnityEngine;

namespace CM.Factories.Interfaces
{
    public interface IFactory<M, V, C>  where M:IModel where V: IView where C : IController <M, V> 
    {
       IController<M, V> Create(Transform container = null);
    }

}