﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Management.Security.Authorization.Content;
using Umbraco.Cms.Api.Management.ViewModels.Document;
using Umbraco.Cms.Core.Actions;
using Umbraco.Cms.Core.Security.Authorization;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Extensions;

namespace Umbraco.Cms.Api.Management.Controllers.Document;

public abstract class CreateDocumentControllerBase : DocumentControllerBase
{
    private readonly IAuthorizationService _authorizationService;

    protected CreateDocumentControllerBase(IAuthorizationService authorizationService)
        => _authorizationService = authorizationService;

    protected async Task<IActionResult> HandleRequest(CreateDocumentRequestModel requestModel, Func<Task<IActionResult>> authorizedHandler)
    {
        // TODO This have temporarily been uncommented, to support the client sends values from all cultures, even when the user do not have access to the languages.
        // The values are ignored in the ContentEditingService

        // IEnumerable<string> cultures = requestModel.Variants
        //     .Where(v => v.Culture is not null)
        //     .Select(v => v.Culture!);
        // AuthorizationResult authorizationResult = await _authorizationService.AuthorizeResourceAsync(
        //     User,
        //     ContentPermissionResource.WithKeys(ActionNew.ActionLetter, requestModel.Parent?.Id, cultures),
        //     AuthorizationPolicies.ContentPermissionByResource);
        //
        // if (!authorizationResult.Succeeded)
        // {
        //     return Forbidden();
        // }

        return await authorizedHandler();
    }
}
