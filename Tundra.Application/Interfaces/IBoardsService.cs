using System.Threading.Tasks;
using Tundra.Application.Models;

namespace Tundra.Application.Interfaces
{
    public interface IBoardsService
    {
        Task<Card> CreateCardAsync(string cardName, string cardDescription, string columnId);
        Task<string> GetBoardsAsync();
        Task<string> GetColumnsAsync(string boardId);
    }
}
