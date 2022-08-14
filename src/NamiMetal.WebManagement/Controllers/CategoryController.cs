using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NamiMetal.Application.Dtos;
using NamiMetal.Categories;
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
    [Route("Category")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly RemoteServiceOptions _remoteServiceOptions;

        public CategoryController(ILogger<CategoryController> logger,
            IOptions<RemoteServiceOptions> remoteServiceOptions)
        {
            _logger = logger;
            _remoteServiceOptions = remoteServiceOptions.Value;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("DataGrid")]
        public async Task<IActionResult> DataGridAsync(SearchCategoryDto input)
        {
            return PartialView("_DataGrid", await GetPagingProductCategories(input));
        }

        private async Task<PagedResultDto<CategoryDto>> GetPagingProductCategories(SearchCategoryDto input)
        {
            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                input.SkipCount = (input.SkipCount - 1) * input.MaxResultCount;
                var request = new RestRequest("api/app/productCategory", Method.Get)
                    .AddObject(input)
                    ;

                response = await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            PagedResultDto<CategoryDto> result = new PagedResultDto<CategoryDto>
            {
                Items = new List<CategoryDto>(),
                TotalCount = 0
            };

            if (response != null && response.StatusCode.Equals(HttpStatusCode.OK) && !response.Content.IsNullOrWhiteSpace())
            {
                result = JsonConvert.DeserializeObject<PagedResultDto<CategoryDto>>(response.Content);
            }

            if (result != null)
            {
                result.SkipCount = input.SkipCount;
                result.MaxResultCount = input.MaxResultCount;
            }

            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Form(Guid id)
        {
            CategoryDto result = new CategoryDto();

            ViewBag.ParentProductCategories = await GetPagingProductCategories(new SearchCategoryDto
            {
                Active = true,
                SkipCount = 1,
                MaxResultCount = 999999,
                Sorting = "CreationTime"
            });

            if (id.Equals(Guid.Empty))
            {
                return PartialView("_Form", result);
            }

            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                var request = new RestRequest($"api/app/productCategory/{id}", Method.Get)
                    ;
                //request.Timeout = 30000;

                response = await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }


            if (response != null && response.StatusCode.Equals(HttpStatusCode.OK) && !response.Content.IsNullOrWhiteSpace())
            {
                result = JsonConvert.DeserializeObject<CategoryDto>(response.Content);
            }

            return PartialView("_Form", result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                var request = new RestRequest("api/app/productCategory/", Method.Post)
                    .AddJsonBody(dto)
                    ;

                response = await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            if (response != null && response.StatusCode.Equals(HttpStatusCode.OK) && !response.Content.IsNullOrWhiteSpace())
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCategoryDto dto)
        {
            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                var request = new RestRequest($"api/app/productCategory/{id}", Method.Put)
                    .AddJsonBody(dto)
                    ;

                response = await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            if (response != null && response.StatusCode.Equals(HttpStatusCode.OK) && !response.Content.IsNullOrWhiteSpace())
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                var request = new RestRequest($"api/app/productCategory/{id}", Method.Delete);

                response = await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            if (response != null && response.StatusCode.Equals(HttpStatusCode.NoContent) && response.Content.IsNullOrWhiteSpace())
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
