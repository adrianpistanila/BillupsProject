using BIllupsProject.Interfaces;
using BIllupsProject.Models;
using RestSharp;

namespace BIllupsProject.Services
{
    public class ChoiceService : IChoiceService
    {
        private IConfiguration _configuration;

        public ChoiceService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Choice> GetChoices()
        {
            return _configuration.GetSection("Choices").Get<List<Choice>>();
        }

        public async Task<Choice> GetChoiceAsync()
        {
            RandomNumber randomNumber = await GetRandomNumberResultAsync();

            var choices = GetChoices();
            switch (randomNumber.Random_number)
            {
                case >= 0 and <= 20:
                    return choices.FirstOrDefault(x => x.Name == ChoiceTypes.rock.ToString());
                case > 20 and <= 40:
                    return choices.FirstOrDefault(x => x.Name == ChoiceTypes.paper.ToString());
                case > 40 and <= 60:
                    return choices.FirstOrDefault(x => x.Name == ChoiceTypes.scissors.ToString());
                case > 60 and <= 80:
                    return choices.FirstOrDefault(x => x.Name == ChoiceTypes.lizard.ToString());
                case > 80 and <= 100:
                    return choices.FirstOrDefault(x => x.Name == ChoiceTypes.spock.ToString());
                default:
                    return choices.FirstOrDefault();
            }
        }

        private async Task<RandomNumber> GetRandomNumberResultAsync()
        {
            var retryTimes = 3;
            for (int i = 0; i < retryTimes; i++)
            {
                try
                {
                    using var client = new RestClient("https://codechallenge.boohma.com");
                    return await client.GetJsonAsync<RandomNumber>("/random");
                }
                catch (Exception)
                {
                    await Task.Delay(500);
                }
            }

            var randomNumber = new RandomNumber() { Random_number = new Random().Next(0, 100) };
            return randomNumber;
        }

        public async Task<Choice?> GetChoiceByIdAsync(int choiceId)
        {
            var choice = _configuration.GetSection("Choices").Get<List<Choice>>().FirstOrDefault(x => x.Id == choiceId);
            return choice ?? throw new ArgumentException("Invalid choice provided!");
        }
    }
}
