using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedLogic.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace SharedLogic
{
    public class AppLogic
    {
        public const string uri = "https://api-dev.channelengine.net/api/v2/";
        public const string apiKey = "&apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        public const string queryOrder = "orders?statuses=IN_PROGRESS";
        public const string queryStock = "offer/stock?skus=001201-S&stockLocationIds=2";

        public static async Task<List<Content>> GetAllOrder()
        {

            Root root = new Root();
            List<string> model = new List<string>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(uri);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllOrder using HttpClient  
                HttpResponseMessage response = await client.GetAsync(uri + queryOrder + apiKey);

                //Checking the response is successful or not which is sent using HttpClient  
                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var resultJsonString = await response.Content.ReadAsStringAsync();

                    //Deserializing the response recieved from web api and storing into the Root list  
                    root = JsonConvert.DeserializeObject<Root>(resultJsonString);               
                   
                }               
                  return new List<Content>(root.Content);
            }
        }

        public static async Task<IEnumerable<Line>> GetTopProducts(int top)
        {            
            HttpClient client = new HttpClient();
            var lines = new List<Models.OrderModel.Line>();
            IEnumerable<Models.OrderModel.Line> baseList = Enumerable.Empty<Models.OrderModel.Line>();

            client.BaseAddress = new Uri(uri);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(uri + queryOrder + apiKey).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultJsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Models.OrderModel.Root>(resultJsonString);                

                for (int j = 0; j < result.Content.Count(); j++)
                {
                    for (int h = 0; h < result.Content[j].Lines.Count(); h++)
                    {
                        lines.Add(result.Content[j].Lines[h]);
                    }
                }

                foreach (var line in lines)
                {
                    baseList = (from p in lines orderby p.Quantity descending select p).Take(top);         
                }
              
                client.Dispose();
                return baseList;
            }
            else
            {              
                client.Dispose();
                return null;
            }
        }

        public static async Task<List<Models.OfferModel.Content>> GetOldStock()
        {          
            HttpClient client = new HttpClient();           

            client.BaseAddress = new Uri(uri);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(uri + queryStock + apiKey).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultJsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Models.OfferModel.Root>(resultJsonString);                
                return result.Content;               
            }
            return null;
        }

        public static async Task<List<Models.OfferModel.Content>> UpdateStock(string Stock)
        {
            List<Models.OfferModel.Content> newOffer = new List<Models.OfferModel.Content>();
            HttpClient client = new HttpClient();
            const string queryapiKey = "?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";

            client.BaseAddress = new Uri(uri);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(uri + queryStock + apiKey).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultJsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Models.OfferModel.Root>(resultJsonString);

                foreach (var item in result.Content)
                {
                    item.Stock = Convert.ToInt32(Stock);
                    item.UpdatedAt = DateTime.Now;
                };

                var json = JsonConvert.SerializeObject(result.Content);

                var PutUri = $"{uri}offer{queryapiKey}";

                var httpContent = new StringContent(json);

                using (client)
                {              
                    HttpResponseMessage newResponse = client.PutAsync(PutUri, httpContent).Result;

                    var newModel = response.Content.ReadAsStringAsync().Result;
                    var newResult = JsonConvert.DeserializeObject<Models.OfferModel.Root>(newModel);

                    if (newResponse.StatusCode == HttpStatusCode.OK)
                    {
                        newOffer = newResult.Content;                                    
                    }
                    else
                    {
                        throw new Exception($"{newResponse.StatusCode}");                        
                    }
                }
                return newOffer;
            }
            else
            {
                throw new Exception($"Status Code = { (int)response.StatusCode} And Reason Phrase : { response.ReasonPhrase}");                
            }           
        }
    }
}
