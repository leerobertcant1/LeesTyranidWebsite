﻿using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using DataManager.Abstractions;
using DataManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcUi.Models;
using Tyranids.MvcUi.Models;
using TyranidsApi.Abstractions;
using TyranidsApi.Static_Values;

namespace MvcUi.Controllers
{

    /* 
     * TO DO - Update Git Ignore.
     * TO DO - use API project to get the data.
     * TO DO - start dynamically adding items to the UI.
     * TO DO - Integrate security on API calls.
     * TO DO - Look at mentioned advanced features.
     */


    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IJsonService _jsonService;

        public HomeController(IApiService apiService, IJsonService jsonService)
        {
            _apiService = apiService;
            _jsonService = jsonService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HQ()
        {
            //Need to debug 2 at once.
            var response =  GetApiData(@"http://localhost:50125/api/Models?entityTypeEnum=Classification");

            return View();
        }

        public IActionResult Troops()
        {
            return View();
        }

        public IActionResult Elites()
        {
            return View();
        }

        public IActionResult FastAttack()
        {
            return View();
        }

        public IActionResult HeavySupport()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<ApiModel> GetApiData(string endPoint)
        {
            try
            {
                var response = await _apiService.GetDataAsync(endPoint);

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiModel { ErrorMessage = "An error occcured", IsError = true };
                }
                else
                {
                    var asyncResult = response.Content.ReadAsStringAsync().Result;

                    return new ApiModel { IsError = false, Response = _jsonService.ConvertJsonList<ModelModel>(asyncResult) };
                }
            }
            catch (Exception exception)
            {
                return new ApiModel { ErrorMessage = "An error occcured", IsError = true };
            }
        }
    }
}
