using Microsoft.AspNetCore.Mvc;
using Domain.Models;

namespace WebApp.Controllers
{
    public class MembersController : Controller
    {
        [HttpPost]
        public IActionResult Add(AddMemberForm form)
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

            // Send data to memberService ska fixas med hjälp av crud i service för create
            return Ok(new { success = true });
        }


        [HttpPost]
        public IActionResult Edit(EditMemberForm form)
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

            // Send data to memberService ska fixas med hjälp av crud i service för update
            return Ok(new { success = true });
        }

    }
}
