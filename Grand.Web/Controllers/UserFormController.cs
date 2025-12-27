using Grand.Domain.Common;
using Grand.Services.Common;
using Grand.Web.Models.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Grand.Web.Controllers
{
    public partial class UserFormController : BasePublicController
    {
        private readonly IUserFormService _userFormService;

        public UserFormController(IUserFormService userFormService)
        {
            _userFormService = userFormService;
        }

        public virtual IActionResult Index()
        {
            var model = new UserFormModel();
            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Index(UserFormModel model)
        {
            if (ModelState.IsValid)
            {
                var userForm = new UserForm
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message,
                    CreatedOnUtc = DateTime.UtcNow
                };

                await _userFormService.InsertUserForm(userForm);
                model.Result = true;
                ModelState.Clear();
            }

            return View(model);
        }

        public virtual async Task<IActionResult> List()
        {
            var forms = await _userFormService.GetAllUserForms();
            return View(forms);
        }
    }
}