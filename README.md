# mlog
## 日志管理系统 面向分布式日志管理系统开发的日志管理系统 
> 特点：  
> 1.走消息队列rabbitmq 
> 2.分布式项目管理 
> 3.接入简单 
> 4.统一管理日志，方便排查问题 
> 5.不用一台一台服务器翻bug 
> 6.mongodb 管理 
> 7.定时清理过期的日志 
> 8.日志分析 
> 9.邮件报警 ......


```c#
/**
Please see https://docs.hangfire.io for more information on using Hangfire. The
`Hangfire` meta-package is using SQL Server as a job storage and intended to run
in any OWIN-based web application when targeting full .NET Framework, or ASP.NET
Core web application on .NET Core.

+-----------------------------------------------------------------------------+
|  !!! DASHBOARD REQUIRES AUTH CONFIGURATION !!!                              |
+-----------------------------------------------------------------------------+

By default, ONLY LOCAL requests are allowed to access the Dashboard. Please
see the `Configuring Dashboard authorization` section in Hangfire documentation:
https://docs.hangfire.io/en/latest/configuration/using-dashboard.html#configuring-authorization

*/


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;

namespace MyWebApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(x => x.UseSqlServerStorage("<connection string>"));
            services.AddHangfireServer();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
        }
    }
}


Sample OWIN Startup class
-------------------------

using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyWebApplication.Startup))]

namespace MyWebApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("<name or connection string>");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
```