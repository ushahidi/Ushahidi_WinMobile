using Ushahidi.Common.MVC;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// The base view controller
    /// </summary>
    /// <typeparam name="TView">view</typeparam>
    /// <typeparam name="TModel">model</typeparam>
    public abstract class BaseViewController<TView, TModel> : ViewController<TView, TModel>
        where TView : IView, new()
        where TModel : IModel, new()
    {
       
    }
}
