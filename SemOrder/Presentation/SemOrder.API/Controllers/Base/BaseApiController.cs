using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SemOrder.Common.WorkContext;

namespace SemOrder.API.Controllers.Base
{
    [Authorize]
    [ApiController]
    public class BaseApiController<T> : ControllerBase where T : BaseApiController<T>
    {
        public BaseApiController()
        {

        }
        private IWorkContext _workContext;
        public IWorkContext WorkContext { 
            get
            {
                if (_workContext == null)
                    _workContext = HttpContext.RequestServices.GetService<IWorkContext>();
                return _workContext;
            }
            set
            {
                _workContext = value;
            }
        }

    }
}
