using System.Web;
using System.Web.Mvc;

namespace SignalRProject_Alamgir
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
