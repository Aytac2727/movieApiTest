using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using MovieApp;

namespace MovieApp
{
    public class Program
    {
        static void Main(string[] args)
        {
          
            GetMovie();
            GetOneMovie();
            Console.ReadLine();
        }

        public static async void GetMovie()
        {
            string baseUrl = "http://www.omdbapi.com/?apikey=729623cd&Season=&i=tt0306414";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            if (content != null)
                            {
                                Console.WriteLine("data------------{0}", JObject.Parse(data)["Episodes"]);
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }

        public static async void GetOneMovie()
        {
            string searchMovie = Console.ReadLine();
            string baseUrl = "http://www.omdbapi.com/?apikey=729623cd&t="+ searchMovie;

            try
            {
                using(HttpClient client = new HttpClient())
                {
                    using(HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using(HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if(data != null)
                            {
                                var dataObj = JObject.Parse(data);
                                MovieItem movieItem = new MovieItem(title: $"{dataObj["Title"]}", year: $"{dataObj["Year"]}",genre: $"{dataObj["Genre"]}",plot: $"{dataObj["Plot"]}",actors: $"{dataObj["Actors"]}");
                                Console.WriteLine("Movie Title: {0}, Movie Year: {1}, Movie Genre: {2} Movie Plot: {3}, Movie Actors: {4}", movieItem.Title, movieItem.Year, movieItem.Genre,movieItem.Plot,movieItem.Actors);
                            }
                            else
                            {
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
