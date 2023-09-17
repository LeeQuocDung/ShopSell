using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebShop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //// Tạo và cấu hình MapperConfiguration
            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<AutoMapperProfile>(); // Thêm profile bạn đã tạo vào cấu hình
            //});

            //IMapper mapper = config.CreateMapper();
            //// Đăng ký mapper trong DI container (nếu sử dụng)

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
        }
    }
}
