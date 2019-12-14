using MLog.Api.Models;
using MLog.Api.Models.Request;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLog.Api.Services
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public class UserService
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<BsonDocument> _coll;

        /// <summary>
        /// 用户服务
        /// </summary>
        /// <param name="client"></param>
        public UserService(MongoClient client)
        {
            _client = client;
            _db = _client.GetDatabase(Database.ManagerDb);
            _coll = _db.GetCollection<BsonDocument>("user");
       
            
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BasicsResponse<UserResponse> Login(LoginModel model)
        {
              
            FilterDefinitionBuilder<BsonDocument> builderFilter = Builders<BsonDocument>.Filter; 
            FilterDefinition<BsonDocument> filter = builderFilter.And(builderFilter.Eq("NickName", model.Account),builderFilter.Eq("Password",model.Password)); 
            
            var ret = _coll.Find(filter).FirstOrDefault();
             
            UserResponse user = new UserResponse()
            {
                NickName = ret.GetElement("NickName").Value.AsString,
                Email = ret.GetElement("Email").Value.AsString,
                Id = ret.GetElement("_id").Value.AsObjectId,
                Mobile = ret.GetElement("Mobile").Value.AsString
            };
             
            return new BasicsResponse<UserResponse>( Models.Enums.ECode.Ok, user);
           
        }

        /// <summary>
        /// 注册一个用户
        /// </summary>
        /// <param name="request"></param>
        public void Register(RegisterUserRequest request)
        { 
            _coll.InsertOne(request.ToBsonDocument()); 
        }
    }
}
