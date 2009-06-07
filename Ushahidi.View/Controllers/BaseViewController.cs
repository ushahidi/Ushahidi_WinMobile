using Ushahidi.Common.MVC;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// The base view controller
    /// </summary>
    /// <typeparam name="TView">view</typeparam>
    public abstract class BaseViewController<TView> : ViewController<TView> where TView : IView, new()
    {
       
    }
}
