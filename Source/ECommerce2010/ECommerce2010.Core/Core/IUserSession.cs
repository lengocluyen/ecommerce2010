using System;

namespace ECommerce2010.Core
{
    public interface IUserSession
    {
        bool LoggedIn { get; set; }
        string Username { get; set; }
        User CurrentMember { get; set; }
        Role RoleCurrentUser { get; set; }
        DateTime TimeUserLogin { get; set; }
    }
}
