using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NamiMetal.Application.Dtos;
using NamiMetal.ProductCategories;
using NamiMetal.WebManagement.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace NamiMetal.WebManagement.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ILogger<ProductCategoryController> _logger;
        private readonly RemoteServiceOptions _remoteServiceOptions;

        public ProductCategoryController(ILogger<ProductCategoryController> logger,
            IOptions<RemoteServiceOptions> remoteServiceOptions)
        {
            _logger = logger;
            _remoteServiceOptions = remoteServiceOptions.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DataGridAsync(SearchProductCategoryDto input)
        {
            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                var request = new RestRequest("api/app/productCategory", Method.Get)
                    ;
                //request.Timeout = 30000;
                request.AddQueryParameter(nameof(input.SkipCount), input.SkipCount);
                request.AddQueryParameter(nameof(input.MaxResultCount), input.MaxResultCount);
                request.AddQueryParameter(nameof(input.Name), input.Name);
                request.AddQueryParameter(nameof(input.Description), input.Description);
                request.AddQueryParameter(nameof(input.Active), input.Active?.ToString());

                response = await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            PagedResultDto<ProductCategoryDto> result = new PagedResultDto<ProductCategoryDto>
            {
                Items = new List<ProductCategoryDto>(),
                TotalCount = 0
            };

            if (response != null && response.StatusCode.Equals(HttpStatusCode.OK) && !response.Content.IsNullOrWhiteSpace())
            {
                result = JsonConvert.DeserializeObject<PagedResultDto<ProductCategoryDto>>(response.Content);
            }

            if(result != null)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = input.MaxResultCount;
            }

            return PartialView("_DataGrid", result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
