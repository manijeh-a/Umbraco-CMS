﻿using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Services.OperationStatus;

namespace Umbraco.Cms.Api.Management.Controllers.Script;

[ApiVersion("1.0")]
public class DeleteScriptController : ScriptControllerBase
{
    private readonly IScriptService _scriptService;
    private readonly IBackOfficeSecurityAccessor _backOfficeSecurityAccessor;

    public DeleteScriptController(
        IScriptService scriptService,
        IBackOfficeSecurityAccessor backOfficeSecurityAccessor)
    {
        _scriptService = scriptService;
        _backOfficeSecurityAccessor = backOfficeSecurityAccessor;
    }

    [HttpDelete]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(string path)
    {
        ScriptOperationStatus operationStatus = await _scriptService.DeleteAsync(path, CurrentUserKey(_backOfficeSecurityAccessor));

        return operationStatus is ScriptOperationStatus.Success
            ? Ok()
            : ScriptOperationStatusResult(operationStatus);
    }
}
