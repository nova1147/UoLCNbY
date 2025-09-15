// 代码生成时间: 2025-09-15 22:50:17
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

// 交互式图表生成器控制器
[Route("api/[controller]/[action]"])
[ApiController]
public class InteractiveChartGeneratorController : ControllerBase
{
    // 生成图表数据的示例方法
    [HttpGet]
    public IActionResult GenerateChartData()
    {
        try
        {
            // 模拟图表数据
            var chartData = new
            {
                Labels = new[] { "January", "February", "March", "April" },
                DataSets = new[]
                {
                    new {
                        Label = "Data Set 1",
                        Data = new[] { 10, 20, 30, 40 }
                    },
                    new {
                        Label = "Data Set 2",
                        Data = new[] { 15, 25, 35, 45 }
                    }
                }
            };

            // 将数据转换为JSON并返回
            return Ok(chartData);
        }
        catch (Exception ex)
        {
            // 错误处理
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    // 接收用户输入并根据输入生成图表的方法
    [HttpPost]
    public IActionResult GenerateChartFromInput([FromBody] JObject input)
    {
        try
        {
            // 从输入中提取数据
            var labels = input["Labels"].ToObject<List<string>>();
            var dataSets = input["DataSets"].ToObject<List<ChartDataSet>>();

            // 验证输入数据
            if (labels == null || dataSets == null)
            {
                return BadRequest("Invalid input data");
            }

            // 生成图表
            var chart = new ChartModel
            {
                Labels = labels,
                DataSets = dataSets
            };

            // 返回图表模型
            return Ok(chart);
        }
        catch (Exception ex)
        {
            // 错误处理
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

// 图表数据集模型
public class ChartDataSet
{
    public string Label { get; set; }
    public List<int> Data { get; set; }
}

// 图表模型
public class ChartModel
{
    public List<string> Labels { get; set; }
    public List<ChartDataSet> DataSets { get; set; }
}