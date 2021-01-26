using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Belfast5dayWeatherForecast.Models;

namespace Belfast5dayWeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Weather()
        {
            WeatherDetail();
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public string WeatherDetail()
        {
            string url = string.Format("https://www.metaweather.com/api/location/44544/");

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                Root weatherInfo = (new JavaScriptSerializer()).Deserialize<Root>(json);
                
                for (int i = 0; i < 6; i++)
                {
                    Session["id"+i] = weatherInfo.consolidated_weather[i].id;
                    Session["weather_state_name"+i] = weatherInfo.consolidated_weather[i].weather_state_name;
                    Session["weather_state_abbr"+i] = "https://www.metaweather.com/static/img/weather/" + weatherInfo.consolidated_weather[i].weather_state_abbr + ".svg";
                    Session["applicable_date"+i] = weatherInfo.consolidated_weather[i].applicable_date;
                }

                var jsonstring = "";
                return jsonstring;
            }               
        }
    }
}