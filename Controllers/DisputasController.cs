using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisputasController : ControllerBase
    {
        private readonly DataContext _context;

        public DisputasController(DataContext context)
        {
            _context = context;
        }    


    [HttpDelete("ApagarDisputas")]
    public async Task<IActionResult> DeleteAsync()
    {
        try
        {
            List<Disputa> disputas = await _context.TB_DISPUTAS.ToListAsync();

        _context.TB_DISPUTAS.RemoveRange(disputas);
        await _context.SaveChangesAsync();

        return Ok("Disputas apagadas");
        }   
        catch (System.Exception ex)
        {   
        return BadRequest(ex.Message);
        }
    }


    [HttpGet("Listar")]
    public async Task<IActionResult> ListarAsync()
    {   
        try
        {
        List<Disputa> disputas = await _context.TB_DISPUTAS.ToListAsync();

        return Ok(disputas);
        }
        catch (System.Exception ex)
        {
        return BadRequest(ex.Message);
        }
    }

    }





}