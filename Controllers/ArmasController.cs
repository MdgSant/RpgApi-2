using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _context;

        public ArmasController(DataContext context)
        {
            _context = context;
        }

        private static List<Armas> armas = new List<Armas>()
        {
            new Armas() { Id = 1, Nome = "Rabaddon", Dano = 10},
            new Armas() { Id = 2, Nome = "Rei destruido", Dano = 10},
            new Armas() { Id = 3, Nome = "Cutelo Negro", Dano = 10},
            new Armas() { Id = 4, Nome = "Mascara de Liandry", Dano = 10},
            new Armas() { Id = 5, Nome = "LeBron James", Dano = 10},
            new Armas() { Id = 6, Nome = "Faquinha de cortar pão", Dano = 10},
            new Armas() { Id = 7, Nome = "Chinelo de mãe", Dano = 10}
        };

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Armas> lista = await _context.TB_ARMAS.ToListAsync();
                return Ok(lista);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(Armas novaArma)
        {
            try
            {
                if(novaArma.Dano == 0)
                    throw new Exception("O dano da arma nao pode ser 0");


                Personagem p = await _context.TB_PERSONAGENS.FirstOrDefaultAsync(p => p.Id == novaArma.PersonagemId);
                if (p == null)
                    throw new Exception("Nao existe personagem com o ID informado");


                Armas buscaArma = await _context.TB_ARMAS.FirstOrDefaultAsync(a => a.PersonagemId == novaArma.PersonagemId);

                if (buscaArma != null)
                    throw new Exception("O Personagem selecionado ja contem uma arma atribuida a ele");

                await _context.TB_ARMAS.AddAsync(novaArma);
                await _context.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Armas p = await _context.TB_ARMAS.FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                return Ok (p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }    

        [HttpPut]
        public async Task<IActionResult> Update(Armas novaArma)
        {
            try
            {
                if(novaArma.Dano > 100)
                {
                    throw new Exception("Dano não pode ser maior que 100");
                }
                _context.TB_ARMAS.Update(novaArma);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Armas pRemover = await _context.TB_ARMAS.FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_ARMAS.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}