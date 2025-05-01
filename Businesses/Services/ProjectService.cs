using System;
using Businesses.Interfaces;
using Data.Contexts;
using Data.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Businesses.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DataContext _context;

        public ProjectService(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(AddProjectForm form)
        {
            var project = new ProjectEntity
            {
                ProjectName = form.ProjectName,
                ClientName = form.ClientName,
                Description = form.Description,
                StartDate = DateTime.Parse(form.StartDate),
                EndDate = DateTime.Parse(form.EndDate),
                Budget = decimal.Parse(form.Budget)
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectEntity>> GetAllProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        //UPDATE

        public async Task UpdateAsync(EditProjectForm form)
        {
            var project = await _context.Projects.FindAsync(form.Id);

            if (project == null)
            {
                Console.WriteLine($"No project found with ID {form.Id}");
                return;
            }

            project.ProjectName = form.ProjectName;
            project.ClientName = form.ClientName;
            project.Description = form.Description;
            project.StartDate = DateTime.Parse(form.StartDate);
            project.EndDate = DateTime.Parse(form.EndDate);
            project.Budget = decimal.Parse(form.Budget);

            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }



        //Denna kod är genererad av Chat gpt. Koden börjar med att den söker efter ett projekt med id i databasen. Finns projektet i databasen så tas det bort och den sparar det som ändrats och då returnerar den true. skulle inte projektet finnas så skickas istället false tillbaka.
        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
