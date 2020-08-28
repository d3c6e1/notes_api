using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Notes.Models
{
    public class NotesContext : DbContext
    {

        public NotesContext(DbContextOptions options)
            : base(options)
        {
        }
        
        public DbSet<Note> Notes { get; set; }
    }
}
