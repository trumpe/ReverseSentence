using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Sentence.DataAccess.Models;
namespace Sentence.DataAccess
{
    public class SentenceContext : DbContext
    {
        public SentenceContext(DbContextOptions<SentenceContext> options) : base(options)
        {

        }
        public DbSet<SentenceModel>Sentences{get; set;}
    }
}
