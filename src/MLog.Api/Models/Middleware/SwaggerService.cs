using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Models.Middleware
{
    /// <summary>
    /// 注册Swagger服务
    /// </summary>
    public static class SwaggerService
    {
        /// <summary>
        /// 注册swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerSevice(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "log manager system api",
                    Description = "分布式日志管理系统",
                    Contact = new OpenApiContact
                    {
                        Email = "821582374@qq.com",
                        Name = "疯哥"
                    }
                });

                var basepath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlpath = Path.Combine(basepath, "MLog.Api.xml");
                options.IncludeXmlComments(xmlpath);

                //options.DocumentFilter<HiddenApiFilter>(); // 在接口类、方法标记属性 [HiddenApi]，可以阻止【Swagger文档】生成
                options.OperationFilter<AddHeaderOperationFilter>("correlationId", "Correlation Id for the request", false); // adds any string you like to the request headers - in this case, a correlation id
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                options.OperationFilter<SecurityRequirementsOperationFilter>();

                //token 令牌验证
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据在header里传输) 在下拉框输入 Bearer {token} (注意两者之间有空格)",
                    Name = "Authorization", //jwt 默认参数名称
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

            });

            return services;
        }

    }
}
