// 代码生成时间: 2025-08-26 19:00:38
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// 定义一个控制器来处理图表生成的请求
[ApiController]
[Route("[controller]/[action]"]
public class InteractiveChartController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string DefaultChartUrl = "https://quickchart.io";

    public InteractiveChartController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: 生成图表
    [HttpGet]
    public async Task<IActionResult> GenerateChart(string chartType, [FromQuery] JObject options)
    {
        try
        {
            // 构造请求图表的URL
            var requestUrl = $