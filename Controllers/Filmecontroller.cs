using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq; 
using Filmes_Teste.Models; 

[Route("api/[controller]")]
[ApiController]
public class FilmeController : ControllerBase
{
    private List<Filme> Filmes = new List<Filme>();
    // GET
    [HttpGet("{id}", Name = "Get")]
    public ActionResult<Filme> Get(int id)
    {
        var movie = Filmes.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        return movie;
    }

    // PUT
    [HttpPut("{id}")]
    public ActionResult Put(int id, Filme filme)
    {
        var existingMovie = Filmes.FirstOrDefault(m => m.Id == id);
        if (existingMovie == null)
        {
            return NotFound();
        }
        existingMovie.Nome = filme.Nome;
        existingMovie.DataLancamento = filme.DataLancamento; 
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var movie = Filmes.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        Filmes.Remove(movie);
        return NoContent();
    }
}
