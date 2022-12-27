using BIllupsProject.Models;

namespace BIllupsProject.Interfaces
{
    public interface IGameService
    {
        public PlayResponse PlayGame(Choice request, Choice computerChoice);
    }
}
