using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AzureForum.Data.Models.Account;

namespace AzureForum.Account.Contracts
{
    public interface IUserService
    {
        Task<AzureForumUser> GetUserByIdAsync(string id);
        Task<AzureForumUser> GetUserByNameAsync(string userName);
    }
}
