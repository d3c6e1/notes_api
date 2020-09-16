using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Notes.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NotesContext(
                serviceProvider.GetRequiredService<DbContextOptions>()))
            {
                if (context.Notes.Any())
                {
                    return;
                }

                context.Notes.Add(new Note { Id = 1, Content = "Welcome", LastUpdate = DateTime.Now});
                context.SaveChanges();
            }
        }
    }
}
