using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Text;
using SharedLogic.Models.OrderModel;

namespace SharedLogic
{
    public static class ConsoleLogic
    {
        public const string uri = "https://api-dev.channelengine.net/api/v2/";
        public const string apiKey = "&apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        public const string queryOrder = "orders?statuses=IN_PROGRESS";
        public const string queryStock = "offer/stock?skus=001201-S&stockLocationIds=2";

        public static void GetAllOrder()
        {
            HttpClient client = new HttpClient();           

            client.BaseAddress = new Uri(uri);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(uri + queryOrder + apiKey).Result;

            if (response.IsSuccessStatusCode)
            {   
                var resultJsonString = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Models.OrderModel.Root>(resultJsonString);

                Console.WriteLine("Total Contents {0}:\n\n\n", result.Content.Count());

                for (int i = 0; i < result.Content.Count(); i++)
                {

                    Console.WriteLine("Content {0}:\n", i + 1);
                    Console.WriteLine("---------------------\n\n");

                    Console.WriteLine("ChannelCustomerNo: {0}", result.Content[i].ChannelCustomerNo);
                    Console.WriteLine("ChannelId: {0}", result.Content[i].ChannelId);
                    Console.WriteLine("ChannelName: {0}", result.Content[i].ChannelName);
                    Console.WriteLine("ChannelOrderNo: {0}", result.Content[i].ChannelOrderNo);
                    Console.WriteLine("ChannelOrderSupport: {0}", result.Content[i].ChannelOrderSupport);
                    Console.WriteLine("CompanyRegistrationNo: {0}", result.Content[i].CompanyRegistrationNo);
                    Console.WriteLine("CreatedAt: {0}", result.Content[i].CreatedAt);
                    Console.WriteLine("CurrencyCode: {0}", result.Content[i].CurrencyCode);
                    Console.WriteLine("PaymentMethod: {0}", result.Content[i].PaymentMethod);
                    Console.WriteLine("Status: {0}", result.Content[i].Status);
                    Console.WriteLine("________________________________________________________\n\n");

                    Console.WriteLine("BillingAddress:\n");
                    Console.WriteLine("City: {0}", result.Content[i].BillingAddress.City);
                    Console.WriteLine("CompanyName: {0}", result.Content[i].BillingAddress.CompanyName);
                    Console.WriteLine("CountryIso: {0}", result.Content[i].BillingAddress.CountryIso);
                    Console.WriteLine("FirstName: {0}", result.Content[i].BillingAddress.FirstName);
                    Console.WriteLine("Gender: {0}", result.Content[i].BillingAddress.Gender);
                    Console.WriteLine("HouseNr: {0}", result.Content[i].BillingAddress.HouseNr);
                    Console.WriteLine("HouseNrAddition: {0}", result.Content[i].BillingAddress.HouseNrAddition);
                    Console.WriteLine("LastName: {0}", result.Content[i].BillingAddress.LastName);
                    Console.WriteLine("Line1: {0}", result.Content[i].BillingAddress.Line1);
                    Console.WriteLine("Line2: {0}", result.Content[i].BillingAddress.Line2);
                    Console.WriteLine("Line3: {0}", result.Content[i].BillingAddress.Line3);
                    Console.WriteLine("Original: {0}", result.Content[i].BillingAddress.Original);
                    Console.WriteLine("Region: {0}", result.Content[i].BillingAddress.Region);
                    Console.WriteLine("StreetName: {0}", result.Content[i].BillingAddress.StreetName);
                    Console.WriteLine("ZipCode: {0}", result.Content[i].BillingAddress.ZipCode);
                    Console.WriteLine("________________________________________________________\n\n");

                    Console.WriteLine("ShippingAddress:\n");
                    Console.WriteLine("City: {0}", result.Content[i].ShippingAddress.City);
                    Console.WriteLine("CompanyName: {0}", result.Content[i].ShippingAddress.CompanyName);
                    Console.WriteLine("CountryIso: {0}", result.Content[i].ShippingAddress.CountryIso);
                    Console.WriteLine("FirstName: {0}", result.Content[i].ShippingAddress.FirstName);
                    Console.WriteLine("Gender: {0}", result.Content[i].ShippingAddress.Gender);
                    Console.WriteLine("HouseNr: {0}", result.Content[i].ShippingAddress.HouseNr);
                    Console.WriteLine("HouseNrAddition: {0}", result.Content[i].ShippingAddress.HouseNrAddition);
                    Console.WriteLine("LastName: {0}", result.Content[i].ShippingAddress.LastName);
                    Console.WriteLine("Line1: {0}", result.Content[i].ShippingAddress.Line1);
                    Console.WriteLine("Line2: {0}", result.Content[i].ShippingAddress.Line2);
                    Console.WriteLine("Line3: {0}", result.Content[i].ShippingAddress.Line3);
                    Console.WriteLine("Original: {0}", result.Content[i].ShippingAddress.Original);
                    Console.WriteLine("Region: {0}", result.Content[i].ShippingAddress.Region);
                    Console.WriteLine("StreetName: {0}", result.Content[i].ShippingAddress.StreetName);
                    Console.WriteLine("ZipCode: {0}", result.Content[i].ShippingAddress.ZipCode);
                    Console.WriteLine("________________________________________________________\n\n");

                    Console.WriteLine("Lines\n");
                    foreach (var item in result.Content[i].Lines)
                    {
                        Console.WriteLine("BundleProductMerchantProductNo: {0}", item.BundleProductMerchantProductNo);
                        Console.WriteLine("CancellationRequestedQuantity: {0}", item.CancellationRequestedQuantity);
                        Console.WriteLine("ChannelProductNo: {0}", item.ChannelProductNo);
                        Console.WriteLine("Condition: {0}", item.Condition);
                        Console.WriteLine("Description: {0}", item.Description);
                        Console.WriteLine("ExpectedDeliveryDate: {0}", item.ExpectedDeliveryDate);
                        Console.WriteLine("ExtraData: {0}", item.ExtraData);
                        Console.WriteLine("FeeFixed: {0}", item.FeeFixed);
                        Console.WriteLine("FeeRate: {0}", item.FeeRate);
                        Console.WriteLine("Gtin: {0}", item.Gtin);
                        Console.WriteLine("IsFulfillmentByMarketplace: {0}", item.IsFulfillmentByMarketplace);
                        Console.WriteLine("LineTotalInclVat: {0}", item.LineTotalInclVat);
                        Console.WriteLine("LineVat: {0}", item.LineVat);
                        Console.WriteLine("MerchantProductNo: {0}", item.MerchantProductNo);
                        Console.WriteLine("OriginalFeeFixed: {0}", item.OriginalFeeFixed);
                        Console.WriteLine("OriginalLineTotalInclVat: {0}", item.OriginalLineTotalInclVat);
                        Console.WriteLine("OriginalLineVat: {0}", item.OriginalLineVat);
                        Console.WriteLine("OriginalUnitPriceInclVat: {0}", item.OriginalUnitPriceInclVat);
                        Console.WriteLine("OriginalUnitVat: {0}", item.OriginalUnitVat);
                        Console.WriteLine("Quantity: {0}", item.Quantity);
                        Console.WriteLine("Status: {0}", item.Status);
                        Console.WriteLine("UnitPriceInclVat: {0}", item.UnitPriceInclVat);
                        Console.WriteLine("UnitVat: {0}", item.UnitVat);                     
                    }
                    Console.WriteLine("________________________________________________________\n\n");

                    Console.WriteLine("ExtraData");
                    Console.WriteLine("Extra Data: {0}", result.Content[i].Extra_Data);

                    Console.WriteLine("\n\n=====================================================================\n\n");

                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            client.Dispose();
        }

        public static int GetTopProducts(int top)
        {
            HttpClient client = new HttpClient();
            var lines = new List<Models.OrderModel.Line>();
            IEnumerable<Models.OrderModel.Line> baseList = Enumerable.Empty<Models.OrderModel.Line>();

            client.BaseAddress = new Uri(uri);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(uri + queryOrder + apiKey).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultJsonString = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Models.OrderModel.Root>(resultJsonString);               
                
                Console.WriteLine("\n================= Ordered {0} =========================\n",top);

                for (int j=0;j<result.Content.Count(); j++)
                {
                    for(int h=0;h< result.Content[j].Lines.Count();h++)
                    {
                        lines.Add(result.Content[j].Lines[h]);           
                    }
                }
               
                foreach (var line in lines)
                {
                   baseList = (from p in lines orderby p.Quantity descending select p).Take(top);      // Use LINQ to get top 5 desc result        
                }              

                foreach (var d in baseList)
                {
                    Console.WriteLine("ChannelProductNo: {0}", d.ChannelProductNo);
                    Console.WriteLine("Description: {0}", d.Description);
                    Console.WriteLine("Gtin: {0}", d.Gtin);
                    Console.WriteLine("Quantity: {0}", d.Quantity);
                    Console.WriteLine("\n");                    
                }
                client.Dispose();
                return top;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                client.Dispose();
                return 0;
            }
           
        }

        public static void UpdateStock()
        {
            HttpClient client = new HttpClient();
            const string queryapiKey = "?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";

            client.BaseAddress = new Uri(uri);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(uri + queryStock + apiKey).Result;

            if (response.IsSuccessStatusCode)
            {
                var resultJsonString = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Models.OfferModel.Root>(resultJsonString);

                foreach (var item in result.Content)
                {
                    item.Stock = 25;
                    item.UpdatedAt = DateTime.Now;
                };               

                var json = JsonConvert.SerializeObject(result.Content);

                var PutUri = $"{uri}offer{queryapiKey}";

                var httpContent =  new StringContent(json);

                using (client)
                {
                    Console.WriteLine("\n=====================\n");
                    Console.WriteLine("... Posting data ...");
                    Console.WriteLine("\n=====================\n");

                    HttpResponseMessage newResponse = client.PutAsync(PutUri, httpContent).Result;

                    var newModel = response.Content.ReadAsStringAsync().Result;
                    var newResult = JsonConvert.DeserializeObject<Models.OfferModel.Root>(newModel);

                    if (newResponse.StatusCode == HttpStatusCode.OK)
                    {
                        foreach (var i in newResult.Content)
                        {
                            Console.WriteLine("MerchantProductNo: {0}", i.MerchantProductNo);
                            Console.WriteLine("Stock: {0}", i.Stock);
                            Console.WriteLine("StockLocationId: {0}", i.StockLocationId);
                            Console.WriteLine("UpdatedAt: {0}", i.UpdatedAt);
                        }
                        Console.WriteLine("\n\nSuccessfully posted!\n\n");
                    }
                    else
                    {
                        Console.WriteLine("there was a problem...");
                        Console.WriteLine(newResponse.StatusCode);
                    }
                }

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            client.Dispose();
        }


    }
}
