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
            client.BaseAddress = new Uri(settings.Value.BaseUrl);
        }

        public async Task CreateCardAsync(Card card)
        {
            var stringRequest = JsonConvert.SerializeObject(card);
            var requestContent = new StringContent(stringRequest, Encoding.UTF8, "application/json");
            await client.PostAsync($"cards?idList={settings.ColumnId}&key={settings.ApiKey}&token={settings.ApiToken}", requestContent);
        }
    }
}
