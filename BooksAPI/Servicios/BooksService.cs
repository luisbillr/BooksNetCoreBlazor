using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BooksAPI.Servicios.Entidades;
using Newtonsoft.Json;
namespace BooksAPI.Servicios
{
    public class BooksService
    {
        private static string BASEAPIUrl { get; set; } = "https://fakerestapi.azurewebsites.net/";
      
        private static List<Book> books = new List<Book>();
        private static Book Book = new Book();
       
        public static async Task<IEnumerable<Book>> Get(int id = -1)
        {
             HttpResponseMessage HttpResponseMessage = new HttpResponseMessage();
             HttpRequestMessage HttpRequestMessage = new HttpRequestMessage();
            HttpClient HttpClient = new HttpClient();
            try
            {
                HttpClient.BaseAddress = new Uri(BASEAPIUrl);
                HttpClient.DefaultRequestHeaders.Clear();
                HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (id <= 0)
                {
                    HttpResponseMessage = await HttpClient.GetAsync("api/v1/Books");
                }
                else
                {
                    HttpResponseMessage = await HttpClient.GetAsync("api/v1/Books/?id=" + id);
                }

                var Response = HttpResponseMessage.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Book>>(Response);

            }
            catch (Exception ex)
            {

                throw;
            }

            return books;
        }

        public static async Task<string> Post(Book book)
        {
            HttpResponseMessage HttpResponseMessage = new HttpResponseMessage();
            HttpRequestMessage HttpRequestMessage = new HttpRequestMessage();
            HttpClient HttpClient = new HttpClient();
            string Response = "";
            try
            {
                Uri posturi = new Uri(BASEAPIUrl + "/api/v1/Books");
                var jsonData = JsonConvert.SerializeObject(book);
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpRequestMessage.RequestUri = posturi;
                HttpRequestMessage.Content = content;
                if (book.id <= 0)
                {
                    HttpRequestMessage.Method = HttpMethod.Post;
                    HttpResponseMessage = await HttpClient.SendAsync(HttpRequestMessage);
                }
                //Evaluar respuesta

                Response = HttpResponseMessage.StatusCode.ToString();

            }
            catch (Exception ex)
            {
                Response = ex.Message;
                throw;
            }
            return Response;
        }
        public static async Task<string> Put(Book book)
        {
            HttpResponseMessage HttpResponseMessage = new HttpResponseMessage();
            HttpRequestMessage HttpRequestMessage = new HttpRequestMessage();
            HttpClient HttpClient = new HttpClient();
            string Response = "";
            try
            {
                Uri posturi = new Uri(BASEAPIUrl + "/api/v1/Books/" + book.id);
                var jsonData = JsonConvert.SerializeObject(book);
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpRequestMessage.RequestUri = posturi;
                HttpRequestMessage.Content = content;
                if (book.id > 0)
                {
                    HttpRequestMessage.Method = HttpMethod.Put;
                    HttpResponseMessage = await HttpClient.SendAsync(HttpRequestMessage);
                }
                //Evaluar respuesta

                Response = HttpResponseMessage.StatusCode.ToString();

            }
            catch (Exception ex)
            {
                Response = ex.Message;
                throw;
            }
            return Response;
        }
        public static async Task<string> Delete(int idBook)
        {
            HttpResponseMessage HttpResponseMessage = new HttpResponseMessage();
            HttpRequestMessage HttpRequestMessage = new HttpRequestMessage();
            HttpClient HttpClient = new HttpClient();
            string Response = "";
            try
            {
                Uri posturi = new Uri(BASEAPIUrl + "/api/v1/Books/" + idBook);
                var jsonData = JsonConvert.SerializeObject(new { id = idBook });
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpRequestMessage.RequestUri = posturi;
                HttpRequestMessage.Content = content;
                if (idBook > 0)
                {
                    HttpRequestMessage.Method = HttpMethod.Delete;
                    HttpResponseMessage = await HttpClient.SendAsync(HttpRequestMessage);
                }
                //Evaluar respuesta

                Response = HttpResponseMessage.StatusCode.ToString();

            }
            catch (Exception ex)
            {
                Response = ex.Message;
                throw;
            }
            return Response;
        }
    }
}
