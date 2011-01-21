using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;

namespace ECommerce2010.Core
{
    public class UserSession : IUserSession
    {
        private IWebContext _webContext;

        public UserSession()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public bool LoggedIn
        {
            get
            {
                return _webContext.LoggedIn;
            }
            set
            {
                _webContext.LoggedIn = value;
            }
        }

        public User CurrentMember
        {
            get
            {
                return _webContext.CurrentUser;
            }
            set
            {
                _webContext.CurrentUser = value;
            }
        }

        public string Username
        {
            get
            {
                return _webContext.Username;
            }

            set
            {
                _webContext.Username = value;
            }
        }
        public Role RoleCurrentUser
        {
            get { return _webContext.RoleCurrentUser; }
            set { _webContext.RoleCurrentUser = value; }
        }
        public DateTime TimeUserLogin
        {
            get { return _webContext.TimeUserLogin; }
            set { _webContext.TimeUserLogin = value; }
        }

        public List<YourCarts> ListCart
        {
            get { return _webContext.ListCart; }
            set { _webContext.ListCart = value; }
        }
    }
}
