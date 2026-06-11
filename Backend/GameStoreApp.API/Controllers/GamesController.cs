using Microsoft.AspNetCore.Mvc;
using GameStoreApp.Application.DTOs;
using GameStoreApp.Application.Interfaces;

namespace GameStoreApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;
    public GamesController(IGameService gameService)//injecting IGAMESERVICE
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
        var created = await _gameService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, GameDto dto)//updates a existing game
    {
        var updated = await _gameService.UpdateAsync(id, dto);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)//delets a game by ID
    {
        var deleted = await _gameService.DeleteAsync(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}