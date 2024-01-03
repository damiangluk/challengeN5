using challengeN5.Data.interfaces;
using challengeN5.Data.relational.commands;
using challengeN5.Data.relational.queries;
using challengeN5.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TPINTEGRADOR.Models;

namespace challengeN5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<string> GetAllPermissions()
        {
            try
            {
                var permissionTypes = await _mediator.Send(new GetAllPermissionTypeQuery());

                object result = new
                {
                    status = true,
                    validation = true,
                    content = permissionTypes.Select(p => p.FormatForFront()),
                };

                return JsonHelper.SerializeObject(result, 4);

            }
            catch (Exception ex)
            {
                object result = new
                {
                    status = true,
                    validation = false,
                    content = new
                    {
                        message = "An error ocurred while getting all the permission types",
                        exception = ex
                    }
                };

                return JsonHelper.SerializeObject(result, 4);
            }
        }
    }
}