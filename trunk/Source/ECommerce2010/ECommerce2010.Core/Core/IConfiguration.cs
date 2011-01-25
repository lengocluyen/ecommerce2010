namespace ECommerce2010.Core
{
    public interface IConfiguration
    {
        int ItemperPageAdmin { get; }
        int ItemperPageUser { get; }
        string RootURL { get; }
        string AdminSiteURL { get; }
        string EmailAdmin { get; }
    }
}