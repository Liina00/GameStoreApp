using GameStoreApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using GameStoreApp.Application.DTOs;

namespace GameStoreApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly GenreService _genreService;
    public GenresController(GenreService genreService)//injecting GenreService
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
        var genre = await _genreService.AddAsync(dto);
        var genreDto = new GenreDto
        {
            Id = genre.Id,
            Name = genre.Name
        };
        return CreatedAtAction(nameof(GetById), new { id = genre.Id }, genreDto);
    }
    [HttpPut("{id}")]//updates
    public async Task<ActionResult> Update(int id, GenreDto dto)
    {
        await _genreService.UpdateAsync(id, dto);
        return NoContent();
    }
    [HttpDelete("{id}")]//DELETE
    public async Task<ActionResult> Delete(int id)
    {
        await _genreService.DeleteAsync(id);
        return NoContent();
    }
}
