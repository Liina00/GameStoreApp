using Microsoft.AspNetCore.Mvc;
using GameStoreApp.Application.DTOs;
using GameStoreApp.Application.Interfaces;

namespace GameStoreApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly IGenreService _genreService;
    public GenresController(IGenreService genreService)//injecting GenreService
    {
        _genreService = genreService;
    }
    [HttpGet]//get genres
    public async Task<ActionResult<IEnumerable<GenreDto>>> GetAll()
    {
        var genres = await _genreService.GetAllAsync();
        return Ok(genres);
    }
    [HttpGet("{id}")]//get by id
    public async Task<ActionResult<GenreDto>> GetById(int id)
    {
        var genre = await _genreService.GetByIdAsync(id);
        if (genre == null)
            return NotFound();

        return Ok(genre);
    }
    [HttpPost]
    public async Task<ActionResult> Create(GenreDto dto)
    {
        var created = await _genreService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    [HttpPut("{id}")]//updates
    public async Task<ActionResult> Update(int id, GenreDto dto)
    {
        var updated = await _genreService.UpdateAsync(id, dto);
        if (updated == null)
            return NotFound();
        return Ok(updated);
    }
    [HttpDelete("{id}")]//DELETE
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _genreService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
