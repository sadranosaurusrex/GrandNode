using Grand.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grand.Services.Common
{
    public partial interface IUserFormService
    {
        Task InsertUserForm(UserForm userForm);
        Task<IList<UserForm>> GetAllUserForms();
    }
}