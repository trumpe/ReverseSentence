using Sentence.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentence.DataAccess.Repository
{
    public class SentenceRepository
    {
        private readonly SentenceContext _context;

        public SentenceRepository(SentenceContext context)
        {
            _context = context;
            if (_context.Sentences.Count()==0)
            {
                _context.Sentences.AddRange(
                    new SentenceModel
                    {            
                        Id = 1,
                        ReversedSentence = "Bal Lab"
                    }
                    );
                _context.SaveChanges();
            }
        }
        public void Add(SentenceModel entity)
        {
            _context.Sentences.Add(entity);
            _context.SaveChanges();
        }

        public SentenceModel GetLast()
        {
            var lastSentence = _context.Sentences.ToList();            

            return lastSentence.Last(); 
        }
    }
}
