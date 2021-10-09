using Berry.MongoDB.Exceptions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Berry.MongoDB.Configurations
{
    /// <summary>
    /// MongoDbOptions
    /// </summary>
    public class MongoDbOptions
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// MongoDB主机地址.格式：host:port
        /// </summary>
        [NotNull]
        public IEnumerable<string> Hosts { get; set; }

        /// <summary>
        /// 默认连接的数据库名称
        /// </summary>
        public string DefaultDatabaseName { get; set; }

        /// <summary>
        /// 其他可选配置项目
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// GridFS相关选项
        /// </summary>
        public MongoDbGridFSOptions GridFSOptions { get; set; }

        public override string ToString()
        {
            if (!this.Hosts.Any()) throw new MongoHostNotFoundException();

            if (string.IsNullOrEmpty(this.UserName) || string.IsNullOrEmpty(this.Password))
            {
                return $"mongodb://{string.Join(",", this.Hosts)}/{this.DefaultDatabaseName}{this.Options}";
            }

            return $"mongodb://{this.UserName}:{this.Password}@{string.Join(",", this.Hosts)}/{this.DefaultDatabaseName}{this.Options}";
        }
    }
}
