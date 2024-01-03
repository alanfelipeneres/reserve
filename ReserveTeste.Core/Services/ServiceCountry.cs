using Newtonsoft.Json;
using ReserveTeste.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTeste.Core.Services
{
    public class ServiceCountry : IServiceCountry
    {
        public async Task<IEnumerable<CountryResponse>> GetCountryResponse()
        {
            var countries = CallApi().Result.Countries;
            List<CountryResponse> result = new List<CountryResponse>();

            //Obter pais com mais casos
            var countriesOrdened = countries.ToList().OrderByDescending(x => x.TotalConfirmed - x.NewRecovered).ToList();

            for (int i = 0; i < 10; i++)
            {
                result.Add(new CountryResponse
                {
                    Name = countriesOrdened[i].Name,
                    Count = countriesOrdened[i].TotalConfirmed - countriesOrdened[i].NewRecovered,
                    Ranking = i + 1
                });
            }

            return result;
        }

        public async Task<Root> CallApi()
        {
            Root countries = new Root();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Fazer a requisição GET para a API
                    HttpResponseMessage response = await client.GetAsync("https://dev.reserve.com.br/covid19api/summary");

                    // Verificar se a requisição foi bem-sucedida
                    if (response.IsSuccessStatusCode)
                    {
                        // Ler e mostrar os dados da resposta
                        string responseBody = await response.Content.ReadAsStringAsync();
                        countries = JsonConvert.DeserializeObject<Root>(responseBody);
                    }
                    else
                    {
                        Console.WriteLine("Falha na requisição: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }
            }

            return countries;
        }
    }
}
