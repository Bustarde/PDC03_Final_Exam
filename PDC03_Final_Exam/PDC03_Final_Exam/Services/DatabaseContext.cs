using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.IO;
using PDC03_Final_Exam.Model;

namespace PDC03_Final_Exam.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<AnimalModel> Animal { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Animal.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
