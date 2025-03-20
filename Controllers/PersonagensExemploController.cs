using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagensExemploController : ControllerBase
    {
         private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };
        [HttpGet("Get")]//rota
        public IActionResult GetFirst()
        {
            //metodo que retorna o 1 personagem
            Personagem p = personagens[0];
            return Ok(p);
        }

        [HttpGet("GetAll")]//rota
        public IActionResult Get()
        {
            //metodo que retorna todos os personagens 
            return Ok(personagens);
        }

        [HttpGet("{id}")] //rota
        public IActionResult GetSingle(int id)
        {
            //metodo para puxar personagem por id 
            return Ok(personagens.FirstOrDefault(pe => pe.Id == id));
        }

        [HttpPost]//rota que vai receber informação 
         public IActionResult AddPersonagem(Personagem novoPersonagem)
        {
            //metodo que vai adicionar um novo personagem
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpGet("GetOrdenado")] //rota 
        public IActionResult GetOrdem()
        {
            //metodo que vai order a lista por força em ordem crescente 
            List<Personagem> listaFinal = personagens.OrderBy(p => p.Forca).ToList();
            return Ok(listaFinal);
        }

        [HttpGet("GetContagem")]
        public IActionResult GetQuantidade()
        {
            //conta os itens da lista
            return Ok("Quantidade de personagens: " + personagens.Count);
        }

        [HttpGet("GetSomaForca")]
        public IActionResult GetSomaForca()
        {
            //Somando valores da forca comum entre objetos de uma lista
            return Ok(personagens.Sum(p => p.Forca));
        }

        [HttpGet("GetSemCavaleiro")]
        public IActionResult GetSemCavaleiro()
        {
            //Filtrando dados de uma lista de acordo com critérios
            List<Personagem> listaBusca = personagens.FindAll(p => p.Classe != ClasseEnum.Cavaleiro);
            return Ok(listaBusca);
        }

        [HttpGet("GetByNomeAproximado/{nome}")]
        public IActionResult GetByNomeAproximado(string nome)
        {
            //Busca por nome aproximado
            List<Personagem> listaBusca = personagens.FindAll(p => p.Nome.Contains(nome));
            return Ok(listaBusca);
        }

        [HttpGet("GetRemovendoMago")]
        public IActionResult GetRemovendoMago()
        {
            //Filtrando um personagem por algum critério e removendo o mesmo da lista
            Personagem pRemove = personagens.Find(p => p.Classe == ClasseEnum.Mago);
            personagens.Remove(pRemove);
            return Ok("Personagem removido: " + pRemove.Nome);
        }

        [HttpGet("GetByForca/{forca}")]
        public IActionResult Get(int forca)
        {
            //filtra por força
            List<Personagem> listaFinal = personagens.FindAll(p => p.Forca == forca);
            return Ok(listaFinal);
        }

        //EXEMPLO DE METODO POST COM VALIDAÇÃO DE PROPRIEDADES 
        [HttpPost]
        public IActionResult AddPersonagemNovo(Personagem novoPersonagem)
        {
            if (novoPersonagem.Inteligencia == 0)
                return BadRequest("Inteligência nao pode ter valor igual a 0");

            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }
    }
}