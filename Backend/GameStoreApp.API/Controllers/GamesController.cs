using Microsoft.AspNetCore.Mvc;
using GameStoreApp.Application.DTOs;
using GameStoreApp.Application.Services;

namespace GameStoreApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly GameService _gameService;
    public GamesController(GameService gameService)//injecting GAMESERVICE
    {
        _gameService = gameService;
    }
    [HttpGet]//get
    public async Task<ActionResult<IEnumerable<GameDto>>> GetAll() // gets all games as dtos
    {
        var games = await _gameService.GetAllAsync();
        return Ok(games);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<GameDto>> GetById(int id)//get by ID
    {
        var game = await _gameService.GetByIdAsync(id);
        if (game == null)
            return NotFound();
        return Ok(game);
    }
    [HttpPost]
    public async Task<ActionResult> Create(GameDto dto)//creates a new game
    {
        var game = await _gameService.AddAsync(dto);
        var gameDto = new GameDto
        {
            Id = game.Id,
            Title = game.Title,
            Price = game.Price,
            Description = game.Description,
            ReleaseYear = game.ReleaseYear,
            GenreId = game.GenreId,//här ghar vi genre id och under name för input/(output
            GenreName = game.Genre?.Name ?? ""
        };
        return CreatedAtAction(nameof(GetById), new { id = game.Id }, gameDto);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, GameDto dto)//updates a existing game
    {
        await _gameService.UpdateAsync(id, dto);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)//delets a game by ID
    {
        await _gameService.DeleteAsync(id);
        return NoContent();
    }
}