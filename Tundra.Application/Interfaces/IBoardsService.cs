using System.Threading.Tasks;
using Tundra.Application.Models;

namespace Tundra.Application.Interfaces
{
    public interface IBoardsService
    {
        Task<Card> CreateCardAsync(Card card);
    }
}
