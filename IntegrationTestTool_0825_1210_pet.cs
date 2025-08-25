// 代码生成时间: 2025-08-25 12:10:46
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntegrationTestProject
{
    // 定义一个继承自WebApplicationFactory的类用于创建和配置测试服务器环境
    public class TestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // 可以添加额外的测试配置，例如数据库的mocking或者测试数据
        }
    }

    // 定义一个集成测试类
    [TestFixture]
    public class IntegrationTests
    {
        private readonly HttpClient _client;
        private readonly ILogger<IntegrationTests> _logger;

        // 在测试类的构造函数中初始化HttpClient和Logger
        public IntegrationTests()
        {
            var factory = new TestWebApplicationFactory<Startup>();
            _client = factory.CreateClient();
            _logger = factory.Services.GetRequiredService<ILogger<IntegrationTests>>();
        }

        // 测试结束时释放资源
        [TearDown]
        public async Task TearDownAsync()
        {
            await _client.DisposeAsync();
        }

        // 定义一个测试方法，检查特定端点的响应状态码
        [Test]
        public async Task CheckEndpointStatusCodeAsync()
        {
            // 发送请求
            var response = await _client.GetAsync("/api/values");

            // 检查响应状态码是否为200 OK
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // 记录日志
            _logger.LogInformation("Test CheckEndpointStatusCodeAsync completed successfully.");
        }

        // 定义一个测试方法，检查特定端点的响应内容
        [Test]
        public async Task CheckEndpointResponseContentAsync()
        {
            // 发送请求
            var response = await _client.GetAsync("/api/values");

            // 确保响应状态码为200 OK
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // 读取响应内容
            var content = await response.Content.ReadAsStringAsync();

            // 检查内容是否符合预期
            Assert.IsNotNull(content);
            Assert.Greater(content.Length, 0);

            // 记录日志
            _logger.LogInformation("Test CheckEndpointResponseContentAsync completed successfully.");
        }
    }
}
