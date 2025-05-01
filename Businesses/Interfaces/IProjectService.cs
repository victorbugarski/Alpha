using Data.Entities;
using Domain.Models;

namespace Businesses.Interfaces
{
    public interface IProjectService
    {
        Task CreateAsync(AddProjectForm form);
        Task<IEnumerable<ProjectEntity>> GetAllProjects();
        Task UpdateAsync(EditProjectForm form);
        Task<bool> DeleteAsync(int Id);
    }
}
