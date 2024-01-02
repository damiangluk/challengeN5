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
    public class PermissionController : ControllerBase
    {
        private readonly IElasticsearchService _elasticsearchService;
        private readonly IMediator _mediator;
        private readonly string PERMISSIONS_INDEX = "permissions";

        public PermissionController(IElasticsearchService elasticsearchService, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _elasticsearchService = elasticsearchService;
            _mediator = mediator;
        }

        [Route("get-all")]
        [HttpGet]
        public async Task<string> GetAllPermissions()
        {
            try
            {
                var permissions = await _mediator.Send(new GetAllPermissionQuery());

                object result = new
                {
                    status = true,
                    validation = true,
                    content = permissions,
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
                        message = "An error ocurred while getting all the permission",
                        exception = ex
                    }
                };

                return JsonHelper.SerializeObject(result, 4);
            }
        }

        [Route("request-permission")]
        [HttpPost]
        public async Task<string> RequestPermission(Permission permission)
        {
            try
            {
                var newPermission = await _mediator.Send(
                    new CreatePermissionCommand(permission.EmployeeName, permission.EmployeeSurname, permission.PermissionDate, permission.PermissionTypeId)
                );

                if (newPermission == null)
                {
                    object resultError = new
                    {
                        status = true,
                        validation = true,
                        content = new
                        {
                            message = "The specified permission type was not found."
                        }
                    };

                    return JsonHelper.SerializeObject(resultError, 2);
                }

                await _elasticsearchService.InsertDocument(PERMISSIONS_INDEX, newPermission.FormatForElasticsearch());

                object result = new
                {
                    status = true,
                    validation = true,
                    content = newPermission,
                };

                return JsonHelper.SerializeObject(result, 4);

            } catch(Exception ex)
            {
                object result = new
                {
                    status = true,
                    validation = false,
                    content = new {
                        message = "An error ocurred while creating the permission",
                        exception = ex
                    }
                };

                return JsonHelper.SerializeObject(result, 4);
            }
        }

        [Route("modify-permission")]
        [HttpPost]
        public async Task<string> ModifyPermission(Permission permission)
        {
            try
            {
                var updatedPermission = await _mediator.Send(new UpdatePermissionCommand(
                    permission.Id,
                    permission.EmployeeName,
                    permission.EmployeeSurname,
                    permission.PermissionDate,
                    permission.PermissionTypeId
                ));
                
                if(updatedPermission == null)
                {
                    object resultError = new
                    {
                        status = true,
                        validation = true,
                        content = new
                        {
                            message = "The specified permission or permission type was not found."
                        }
                    };

                    return JsonHelper.SerializeObject(resultError, 2);
                }

                await _elasticsearchService.InsertDocument(PERMISSIONS_INDEX, updatedPermission.FormatForElasticsearch());

                object result = new
                {
                    status = true,
                    validation = true,
                    content = updatedPermission,
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
                        message = "An error ocurred while updating the permission",
                        exception = ex
                    }
                };

                return JsonHelper.SerializeObject(result, 4);
            }
        }
    }
}