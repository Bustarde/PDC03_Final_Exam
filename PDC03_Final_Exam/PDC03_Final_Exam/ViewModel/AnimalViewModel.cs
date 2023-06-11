using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.IO;

using System.Threading.Tasks;
using PDC03_Final_Exam.Model;
using PDC03_Final_Exam.Services;

namespace PDC03_Final_Exam.ViewModel
{
    public class AnimalViewModel
    {
        // Call Database
        private DatabaseContext getContext()
        {
            return new DatabaseContext();
        }

        // Insert Records
        public int InsertAnimal(AnimalModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Animal.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        // Retrieve Records
        public async Task<List<AnimalModel>> GetAllAnimals()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Animal.ToListAsync();
            return res;
        }

        // Delete Records
        public int DeleteAnimal(AnimalModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Animal.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        // Update Records
        public async Task<int> UpdateAnimal(AnimalModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Animal.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

    }
}
