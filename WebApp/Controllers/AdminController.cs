using System.Threading.Tasks;
using Businesses.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

[Authorize]


public class AdminController(IMemberService memberService) : Controller
{
    private readonly IMemberService _memberService = memberService;

    public IActionResult Index()
    {
        return View();
    }

    [Route("projects")]
    public IActionResult Projects()
    {
        return View();
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
