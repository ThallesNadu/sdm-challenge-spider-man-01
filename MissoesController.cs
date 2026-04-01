using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpiderNetApi.Models;

namespace SpiderNetApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MissoesController : ControllerBase
{
    private static List<MissaoAranha> _missoes = new List<MissaoAranha>();

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_missoes);
    }

    [HttpPost]
    public IActionResult Post([FromBody] MissaoAranha novaMissao)
    {
        if (novaMissao.NivelPerigo < 1 || novaMissao.NivelPerigo > 10)
        {
            return BadRequest("O Nível de Perigo deve ser um valor entre 1 e 10.");
        }

        _missoes.Add(novaMissao);
        return CreatedAtAction(nameof(Get), new { id = novaMissao.Id }, novaMissao);
    }
}