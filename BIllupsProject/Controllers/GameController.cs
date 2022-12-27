using BIllupsProject.Interfaces;
using BIllupsProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace BllupsProject;

[ApiController]
public class GameController : ControllerBase
{
    private IGameService _gameService;
    private IChoiceService _choiceService;

    public GameController(IGameService gameService, IChoiceService choiceService)
    {
        _gameService = gameService;
        _choiceService = choiceService;
    }

    [Route("choices"), HttpGet]
    public List<Choice> GetChoices()
    {
        try
        {
            return _choiceService.GetChoices();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [Route("choice"), HttpGet]
    public async Task<Choice> GetChoiceAsync()
    {
        try
        {
            return await _choiceService.GetChoiceAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [Route("play"), HttpPost]
    public async Task<PlayResponse> PlayAsync(PlayRequest play)
    {
        try
        {
            var choice = await _choiceService.GetChoiceByIdAsync(play.Player);
            var computerChoice = await _choiceService.GetChoiceAsync();
            return _gameService.PlayGame(choice, computerChoice);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}