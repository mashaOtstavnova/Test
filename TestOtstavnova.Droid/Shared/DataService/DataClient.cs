using System;
using System.Collections.Generic;
using System.Text;
using Shared.Helpers;
using Shared.Models.JSON;

namespace Shared.DataService
{
    public static class DataClient
    {
        public static RootObject GetCurrency()
        {
            var result = HttpClient.GetDataURLAsync<RootObject>(URL.Currency);
            if (result.Result != null)
            {
                return result.Result;
            }
            else if(result.Error != null)
            {
                Console.WriteLine(result.Error.Title + " " + result.Error.Text);// можно в метод преедать метод который будет отображать ошибку
            }
            return null;
        }
    }
}
