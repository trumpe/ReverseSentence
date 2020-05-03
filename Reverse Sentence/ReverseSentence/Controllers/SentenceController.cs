using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sentence.DataAccess.Models;
using Sentence.DataAccess.Repository;

namespace ReverseSentence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentenceController : ControllerBase
    {
        private readonly SentenceRepository _repository;

        public SentenceController(SentenceRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public string GetLastSentence()
        {
            return _repository.GetLast().ReversedSentence;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        
        public IActionResult CreateSentence([FromBody]SentenceModel sentence)
        {
            

            List<string> words = new List<string>();
            words = sentence.ReversedSentence.Split(" ").ToList();
            words.Reverse();
            sentence.ReversedSentence = "";
            foreach (var word in words)
            {
                sentence.ReversedSentence += word + " ";
            }
            _repository.Add(sentence);
            return Created("api/Sentence/posts", sentence);

        }

    }
}