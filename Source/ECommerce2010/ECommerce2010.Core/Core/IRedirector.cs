using System;
using StructureMap;

namespace ECommerce2010.Core
{
    public interface IRedirector
    {
        void GoToHomePage();
        void GotoLoginPage();
        void GoToErrorPage();
        void GotoAdminPage();
    }
}