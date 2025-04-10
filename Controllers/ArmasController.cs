using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models.Enuns;

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
      [HttpGet("GetAll")]
      public async Task<IActionResult> Get()
      {
        try
        {
            List<Arma> lista = await _context.TB_ARMAS.ToListAsync();
            return Ok (lista);
        }
        catch(System.Exception ex)
        {
            return BadRequest (ex.Message);
        }
      }

      [HttpPost]
        public async Task<IActionResult> Add(Arma novaArma){
            try{
                if(novaArma.Dano>15){
                    throw new Exception ("Dano da arma não pode ser maior que 15");
                }
                await _context.TB_ARMAS.AddAsync(novaArma);
                await _context.SaveChangesAsync();

                return Ok(novaArma);
            }
            catch (System.Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Arma novaArma){
            try{
                if (novaArma.Dano> 15){
                    throw new System.Exception ("Dano da arma não pode ser maior que 15");

                }
                _context.TB_ARMAS.Update(novaArma);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch(System.Exception ex){
                return BadRequest (ex.Message);
            }
        }

         [HttpGet("{id}")]
        public async Task<IActionResult>GetSingle(int id){
            try
            {
                Arma a = await _context.TB_ARMAS.FirstOrDefaultAsync(aBusca => aBusca.Id == id);

                return Ok (a);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            try
            {
                Arma aRemover = await _context.TB_ARMAS.FirstOrDefaultAsync(a=> a.Id == id);
                _context.TB_ARMAS.Remove(aRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }



    }
}