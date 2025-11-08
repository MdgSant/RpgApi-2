using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RpgApi.Models.Enuns;
using RpgApi.Models;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExercicioController : Controller
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        //Métodos deverão ser construidos aqui

        [HttpGet("GetByName/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            List<Personagem> ListaFinal = personagens.FindAll(p => p.Nome == nome);
            if (ListaFinal.Count == 0)
            {
                return BadRequest("Nome nao encontrado");
            }
            return Ok(ListaFinal);
        }

        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {
            List<Personagem> listaFinal = personagens.Where(p => p.Classe != ClasseEnum.Cavaleiro).OrderByDescending(p => p.PontosVida).ToList();
            return Ok(listaFinal);
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            return Ok("Quantidade de personagens: " + personagens.Count + "\nSomatoria das inteligencias: " + personagens.Sum(p => p.Inteligencia));
        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem novoPersonagem)
        {
            if (novoPersonagem.Defesa < 10 || novoPersonagem.Inteligencia > 30)
                return BadRequest("Não é possivel criar um personagem com menos de 10 de defesa ou mais de 30 em inteligencia");

            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem novoPersonagem)
        {
            if (novoPersonagem.Classe == ClasseEnum.Mago && novoPersonagem.Inteligencia < 35)
                return BadRequest("Nao é possivel criar um mago com menos de 35 de inteligencia");

            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpGet("GetByClasse/{id}")]
        public IActionResult GetByClasse(int id)
        {
        if (id == 1)
        {
        var cavaleiros = personagens.Where(p => p.Classe == ClasseEnum.Cavaleiro).ToList();
        return Ok(cavaleiros);
        }
        else if (id == 2)
        {
        var magos = personagens.Where(p => p.Classe == ClasseEnum.Mago).ToList();
        return Ok(magos);
        }
        else if (id == 3)
        {
        var clerigos = personagens.Where(p => p.Classe == ClasseEnum.Clerigo).ToList();
        return Ok(clerigos);
        }

        return BadRequest("Classe inválida");
}
        

        
    }
}