using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Businesses.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
namespace WebApp.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly DataContext _context;


        public ProjectsController(IProjectService projectService, DataContext context)
        {
            _projectService = projectService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProjectForm form)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                    );

                return BadRequest(new { success = false, errors });
            }

            await _projectService.CreateAsync(form);
            return Ok(new { success = true });
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditProjectForm form)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage).ToArray()
                    );

                return BadRequest(new { success = false, errors });
            }

            await _projectService.UpdateAsync(form);
            return Ok(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return NotFound();

            return Ok(new
            {
                id = project.Id,
                projectName = project.ProjectName,
                clientName = project.ClientName,
                description = project.Description,
                startDate = project.StartDate.ToString("yyyy-MM-dd"),
                endDate = project.EndDate.ToString("yyyy-MM-dd"),
                budget = project.Budget.ToString()
            });
        }


        //CHAT GPT
        //Denna metoden svara på POST förfrågan som skickas ifrån min site.js. Den tar emot ett id och använder sig utav projectService med metoden deleteAsync som tar bort ifrån databasen. Lyckas det så tas projektet bort och man får en success true. Skulle det misslyckas skickas istället en felkod 400 Bad Request med ett felmeddelande.
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectService.DeleteAsync(id);
            if (result)
                return Ok(new { success = true });

            return BadRequest(new { success = false, message = "Project not found" });
        }
    }
}
