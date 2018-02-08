using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Shared.DataService
{
    public static class HttpClient
    {
        private static System.Net.Http.HttpClient  _client => new System.Net.Http.HttpClient
        {
            Timeout = new TimeSpan(0, 0, 0, 30),
        };

        public static (T Result, Error Error) GetDataURLAsync<T>(string url) where T: class
        {
            try
            {
                Uri myUri = new Uri(url);
                var message = _client.GetAsync(myUri);
                var responce = message.Result;

                var tryAnswer = responce.Content.ReadAsStringAsync();
                tryAnswer.Wait();
                var answer = tryAnswer.Result;

                Console.WriteLine(answer);
                if (responce.StatusCode == HttpStatusCode.OK)
                {
                    var js = JsonConvert.DeserializeObject<T>(answer);
                    return (js, null);
                }
                else
                {
                    return (null, new Error() { Title = "Server Error", Text = "responce.StatusCode" });
                }
            }
            catch (Exception ex)
            {
                return (null, new Error() { Title = "Error", Text = ex.Message });
            }
            return (null,null);
        }
        

    }
}
