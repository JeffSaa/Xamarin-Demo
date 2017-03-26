using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecyclerView_Xamarin
{
    class RestService
    {

        public static async Task<List<Book>> GetBooks()
        {
            HttpClient client = new HttpClient();
            var query = "http://jsonplaceholder.typicode.com/posts";
            var response = await client.GetAsync(query);
            List<Book> books = new List<Book>();
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                books = JsonConvert.DeserializeObject<List<Book>>(content);
            }
            return books;
        }

    }
}
