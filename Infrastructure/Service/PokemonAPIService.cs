﻿using Application.Service.Models;
using System.Net.Http.Json;
using System.Text;

namespace Infrastructure.Service
{
    public class PokemonAPIService
    {
        private readonly IHttpClientFactory _httpClientFactory = null!;
        public HttpClient pokeClient { get; set; }

        public PokemonAPIService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            string? httpClientName = "pokeHttpClient";
            pokeClient = _httpClientFactory.CreateClient(httpClientName ?? "");
        }
        public async Task<GetPokeByIdResponse> GetBerryAsync(int id)
        {
            return await pokeClient.GetFromJsonAsync<GetPokeByIdResponse>($"berry/{id}");
        }

        public async Task<string> PostBerryAsync(string code)
        {
            string json = "{'id':1,'code': '1234dse'}";
            string path = "berry";
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await pokeClient.PostAsync(path, content);
            return response.ReasonPhrase;
        }
    }
}
