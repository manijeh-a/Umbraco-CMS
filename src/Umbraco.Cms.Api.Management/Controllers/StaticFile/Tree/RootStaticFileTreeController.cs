﻿using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Api.Common.ViewModels.Pagination;
using Umbraco.Cms.Api.Management.ViewModels.Tree;

namespace Umbraco.Cms.Api.Management.Controllers.StaticFile.Tree;

[ApiVersion("1.0")]
public class RootStaticFileTreeController : StaticFileTreeControllerBase
{
    public RootStaticFileTreeController(IPhysicalFileSystem physicalFileSystem)
        : base(physicalFileSystem)
    {
    }

    [HttpGet("root")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(typeof(PagedViewModel<FileSystemTreeItemPresentationModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedViewModel<FileSystemTreeItemPresentationModel>>> Root(int skip = 0, int take = 100)
        => await GetRoot(skip, take);
}
