using Businesses.Interfaces;
using Businesses.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

[Authorize]


public class AdminController(IMemberService memberService, IProjectService projectService) : Controller
{
    private readonly IMemberService _memberService = memberService;
    private readonly IProjectService _projectService = projectService;

    public IActionResult Index()
    {
        return View();
    }

    [Route("projects")]
    public async Task<IActionResult> Projects()
    {
        var projects = await _projectService.GetAllProjects();

        var viewModel = new ProjectsViewModel
        {
            Projects = await _projectService.GetAllProjects()
        };
        return View(viewModel);
    }

    [Route("members")]
    public async Task<IActionResult> Members()
    {
        var viewModel = new MembersViewModel
        {
            Members = await _memberService.GetAllMembers(),
        };
        return View(viewModel);
    }

}
