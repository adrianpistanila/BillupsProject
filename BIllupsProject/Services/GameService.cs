using BIllupsProject.Interfaces;
using BIllupsProject.Models;

namespace BIllupsProject.Services
{
    public class GameService : IGameService
    {
        private ChoiceTypes _computerChoice;

        public PlayResponse PlayGame(Choice choice, Choice computerChoice)
        {
            ChoiceTypes playerChoice = ConvertChoiceNameToEnum(choice.Name);
            _computerChoice = ConvertChoiceNameToEnum(computerChoice.Name);

            GameOutcomeTypes gameOutcome;
            switch (playerChoice)
            {
                case ChoiceTypes.rock:
                    gameOutcome = PlayRock();
                    break;
                case ChoiceTypes.paper:
                    gameOutcome = PlayPaper();
                    break;
                case ChoiceTypes.scissors:
                    gameOutcome = PlayScissors();
                    break;
                case ChoiceTypes.lizard:
                    gameOutcome = PlayLizard();
                    break;
                case ChoiceTypes.spock:
                    gameOutcome = PlaySpock();
                    break;
                default:
                    throw new ArgumentException("Invalid player choice provided!");
            }

            PlayResponse response = new PlayResponse()
            {
                Results = gameOutcome.ToString(),
                Player = choice.Id,
                Computer = computerChoice.Id
            };

            return response;
        }

        private GameOutcomeTypes PlaySpock()
        {
            switch (_computerChoice)
            {
                case ChoiceTypes.rock:
                    return GameOutcomeTypes.win;
                case ChoiceTypes.paper:
                    return GameOutcomeTypes.lose;
                case ChoiceTypes.scissors:
                    return GameOutcomeTypes.win;
                case ChoiceTypes.lizard:
                    return GameOutcomeTypes.lose;
                case ChoiceTypes.spock:
                    return GameOutcomeTypes.tie;
                default: throw new ArgumentException("Invalid game outcome!");
            }
        }

        private GameOutcomeTypes PlayLizard()
        {
            switch (_computerChoice)
            {
                case ChoiceTypes.rock:
                    return GameOutcomeTypes.lose;
                case ChoiceTypes.paper:
                    return GameOutcomeTypes.win;
                case ChoiceTypes.scissors:
                    return GameOutcomeTypes.lose;
                case ChoiceTypes.lizard:
                    return GameOutcomeTypes.tie;
                case ChoiceTypes.spock:
                    return GameOutcomeTypes.win;
                default: throw new ArgumentException("Invalid game outcome!");
            }
        }

        private GameOutcomeTypes PlayScissors()
        {
            switch (_computerChoice)
            {
                case ChoiceTypes.rock:
                    return GameOutcomeTypes.lose;
                case ChoiceTypes.paper:
                    return GameOutcomeTypes.win;
                case ChoiceTypes.scissors:
                    return GameOutcomeTypes.tie;
                case ChoiceTypes.lizard:
                    return GameOutcomeTypes.win;
                case ChoiceTypes.spock:
                    return GameOutcomeTypes.lose;
                default: throw new ArgumentException("Invalid game outcome!");
            }
        }

        private GameOutcomeTypes PlayPaper()
        {
            switch (_computerChoice)
            {
                case ChoiceTypes.rock:
                    return GameOutcomeTypes.win;
                case ChoiceTypes.paper:
                    return GameOutcomeTypes.tie;
                case ChoiceTypes.scissors:
                    return GameOutcomeTypes.lose;
                case ChoiceTypes.lizard:
                    return GameOutcomeTypes.lose;
                case ChoiceTypes.spock:
                    return GameOutcomeTypes.win;
                default: throw new ArgumentException("Invalid game outcome!");
            }
        }

        private GameOutcomeTypes PlayRock()
        {
            switch (_computerChoice)
            {
                case ChoiceTypes.rock:
                    return GameOutcomeTypes.tie;
                case ChoiceTypes.paper:
                    return GameOutcomeTypes.lose;
                case ChoiceTypes.scissors:
                    return GameOutcomeTypes.win;
                case ChoiceTypes.lizard:
                    return GameOutcomeTypes.win;
                case ChoiceTypes.spock:
                    return GameOutcomeTypes.lose;
                default: throw new ArgumentException("Invalid game outcome!");
            }
        }

        private ChoiceTypes ConvertChoiceNameToEnum(string choiceName)
        {
            if (Enum.TryParse(choiceName, out ChoiceTypes choice))
            {
                return choice;
            }

            throw new ArgumentException("Invalid choice provided!");
        }
    }
}
