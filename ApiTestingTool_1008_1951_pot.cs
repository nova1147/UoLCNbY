// 代码生成时间: 2025-10-08 19:51:53
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiTestingTool
{
    /// <summary>
    /// API测试工具
    /// </summary>
    public class ApiTestingTool
    {
        private readonly HttpClient _httpClient;

        public ApiTestingTool()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// 发送GET请求
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <returns>响应内容</returns>
        public async Task<string> SendGetRequestAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // 处理请求异常
                return $"Error: {e.Message}";
            }
        }

        /// <summary>
        /// 发送POST请求
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <param name="content">请求内容</param>
        /// <returns>响应内容</returns>
        public async Task<string> SendPostRequestAsync(string url, string content)
        {
            try
            {
                HttpContent httpContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                // 处理请求异常
                return $"Error: {e.Message}";
            }
        }
    }
}
