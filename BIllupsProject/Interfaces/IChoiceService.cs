using BIllupsProject.Models;

namespace BIllupsProject.Interfaces
{
    public interface IChoiceService
    {
        public List<Choice> GetChoices();
        public Task<Choice> GetChoiceAsync();
        public Task<Choice?> GetChoiceByIdAsync(int choiceId);
    }
}
