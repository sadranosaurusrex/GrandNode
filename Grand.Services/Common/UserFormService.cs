using Grand.Domain.Common;
using Grand.Domain.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grand.Services.Common
{
    public partial class UserFormService : IUserFormService
    {
        private readonly IRepository<UserForm> _userFormRepository;

        public UserFormService(IRepository<UserForm> userFormRepository)
        {
            _userFormRepository = userFormRepository;
        }

        public virtual async Task InsertUserForm(UserForm userForm)
        {
            await _userFormRepository.InsertAsync(userForm);
        }

        public virtual async Task<IList<UserForm>> GetAllUserForms()
        {
            return await _userFormRepository.Collection.Find(x => true).ToListAsync();
        }
    }
}