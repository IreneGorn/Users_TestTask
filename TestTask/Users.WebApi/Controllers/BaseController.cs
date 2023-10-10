using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using Users.Domain;

namespace Users.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        
        internal Guid RoleId => !User.Identity.IsAuthenticated 
            ? Guid.Empty 
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
