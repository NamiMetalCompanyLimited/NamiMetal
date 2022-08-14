using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NamiMetal.Application.Dtos;
using NamiMetal.Collections;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace NamiMetal.WebManagement.Controllers
{
    [Route("Collection")]
    public class CollectionController : Controller
    {
        private readonly ILogger<CollectionController> _logger;
        private readonly RemoteServiceOptions _remoteServiceOptions;

        public CollectionController(ILogger<CollectionController> logger,
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
        public async Task<IActionResult> DataGridAsync(SearchCollectionDto input)
        {
            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            var skipCount = input.SkipCount;
            try
            {
                input.SkipCount = (input.SkipCount - 1) * input.MaxResultCount;
                var request = new RestRequest("api/app/collection", Method.Get)
                    .AddObject(input)
                    ;

                response = await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.ToString());
            }

            PagedResultDto<CollectionDto> result = new PagedResultDto<CollectionDto>(0, new List<CollectionDto>());

            if (response != null && response.StatusCode.Equals(HttpStatusCode.OK) && !response.Content.IsNullOrWhiteSpace())
            {
                result = JsonConvert.DeserializeObject<PagedResultDto<CollectionDto>>(response.Content);
            }

            if (result != null)
            {
                result.SkipCount = skipCount;
                result.MaxResultCount = input.MaxResultCount;
            }

            return PartialView("_DataGrid", result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Form(Guid id)
        {
            CollectionDto result = new CollectionDto();

            if (id.Equals(Guid.Empty))
            {
                return PartialView("_Form", result);
            }

            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                var request = new RestRequest($"api/app/collection/{id}", Method.Get)
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
                result = JsonConvert.DeserializeObject<CollectionDto>(response.Content);
            }

            return PartialView("_Form", result);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(CreateCollectionDto dto)
        {
            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                var request = new RestRequest("api/app/collection/", Method.Post)
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
                return Ok(response?.Content);
            }
            else
            {
                return BadRequest(response?.Content);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCollectionDto dto)
        {
            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                var request = new RestRequest($"api/app/collection/{id}", Method.Put)
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
                return Ok(response?.Content);
            }
            else
            {
                return BadRequest(response?.Content);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = new RestClient(_remoteServiceOptions.Default.BaseUrl);
            RestResponse response = null;
            try
            {
                var request = new RestRequest($"api/app/collection/{id}", Method.Delete);

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
