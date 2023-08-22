using Catalogo_de_Carros.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalogo_de_Carros.Services
{
    public class RestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public List<Car> Items { get; private set; }

        public RestService()
        {
            _client = new HttpClient( );
            _client.DefaultRequestHeaders.Add("X-Api-Key", "sOwAmLTrQl3uz09s/lm5gw==TlqmFQ5pLr3SHv6w");
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Car>> GetCarrosPelaMarca(string marca)
        {
            var items = new List<Car>();

            Uri uri = new Uri(string.Format($"https://api.api-ninjas.com/v1/cars?limit=30&make={marca}", string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<Car>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
