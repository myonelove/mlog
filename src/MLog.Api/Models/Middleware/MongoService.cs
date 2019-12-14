using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MLog.Api.Models.Middleware
{
    /// <summary>
    /// 注册MongoClient
    /// </summary>
    public static class MongoService
    {
        /// <summary>
        /// 注册Mongo Client 服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddMongoClientService(this IServiceCollection services, IConfiguration configuration)
        { 
            MongoClient client = new MongoClient(configuration["MongoConn"]);
            services.AddSingleton<MongoClient>(client); 
            return services;
        }

    }
}
