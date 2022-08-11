using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tundra.Application.Interfaces;
using Tundra.Application.Models;
using Tundra.Settings;

namespace Tundra.Trello.Services
{
    public class BoardsService : IBoardsService
    {
        private readonly TrelloSettings settings;
        private readonly HttpClient client;

        public BoardsService(IOptions<TrelloSettings> settings, HttpClient client)
        {
            this.client = client;
            this.settings = settings.Value;
        }
        public async Task<Card> CreateCardAsync(string cardName, string cardDescription)
        {
            client.BaseAddress = new Uri(settings.BaseUrl);
            var card = new Card
            {
                Name = cardName,
                Description = cardDescription
            };
            var stringRequest = JsonConvert.SerializeObject(card);
            var requestContent = new StringContent(stringRequest, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"cards?idList={settings.ColumnId}&key={settings.ApiKey}&token={settings.ApiToken}", requestContent);
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Card>(body);
        }
    }
}
