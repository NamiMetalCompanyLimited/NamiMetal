using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NamiMetal.ProductCategories;
using NamiMetal.WebManagement.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        [HttpPost]
        public async Task<IActionResult> Index(SearchProductCategoryDto input)
        {
            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                var request = new RestRequest("", Method.Get)
                    ;
                //request.Timeout = 30000;
                request.AddQueryParameter(nameof(input.PageIndex), input.PageIndex);
                request.AddQueryParameter(nameof(input.PageSize), input.PageSize);
                request.AddQueryParameter(nameof(input.SOCodeKeyword), input.SOCodeKeyword);
                request.AddQueryParameter(nameof(input.InvoiceKeyWord), input.InvoiceKeyWord);
                request.AddQueryParameter(nameof(input.SellerTaxCodeKeyWord), input.SellerTaxCodeKeyWord);
                request.AddQueryParameter(nameof(input.Status), input.Status);
                request.AddQueryParameter(nameof(input.FromDate), input.FromDate.HasValue ? input.FromDate.Value.ToString() : string.Empty);
                request.AddQueryParameter(nameof(input.ToDate), input.ToDate.HasValue ? input.ToDate.Value.ToString() : string.Empty);

                response = await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            BasePagedList<InvoiceDataList> result = new BasePagedList<InvoiceDataList>(null, 0, 0, 0);

            _logger.LogInformation("ReportGridAsync API response");
            _logger.LogInformation(JsonConvert.SerializeObject(response));
            if (response != null && response.StatusCode.Equals(HttpStatusCode.OK) && !response.Content.IsNullOrWhiteSpace())
            {
                result = JsonConvert.DeserializeObject<BasePagedList<InvoiceDataList>>(response.Content);
            }

            return PartialView("_ReportGrid", result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
