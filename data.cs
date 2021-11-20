using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace COP4365Project3
{
    public class data
    {
        string ticker;
        string startDate;
        string endDate;
        string interval;

        public data(string ticker, string start, string end, string interval)
        {
            this.ticker = ticker;
            startDate = start;
            endDate = end;
            this.interval = interval;
        }
        public void url()
        {
            string url_part1 = "https://yh-finance.p.rapidapi.com/stock/v2/get-chart?";
            string url = url_part1 + "interval=" + interval + "&" + "symbol=" + ticker + "&" + "region=US" 
                           + "&" + "period1=" +endDate + "&" +"period2=" + startDate;

            Console.WriteLine(url);
        }

        public JsonClass getJsonClassObj()
        {
            //from url: 
            string url_part1 = "https://yh-finance.p.rapidapi.com/stock/v2/get-chart?";
            string url = url_part1 + "interval=" + interval + "&" + "symbol=" + ticker + "&" + "region=US"
                           + "&" + "period1=" + endDate + "&" + "period2=" + startDate;


            //create client
            var client = new RestClient(url);
            //create request
            var request = new RestRequest(Method.GET);



            //add stuff to request header
            request.AddHeader("x-rapidapi-key", "f1407ffcd5msh250c8cde3235ed4p1072ccjsn12d793e69372");
            request.AddHeader("x-rapidapi-host", "yh-finance.p.rapidapi.com");

            //client request data and store response?
            //if using execute<t> get the response 
            IRestResponse response = client.Execute(request);

            //Console.WriteLine(response.Content);
            var content = response.Content;

            var data = JsonConvert.DeserializeObject<JsonClass>(content);

            //return json file as obj.
            return data;
        }

    }
}
