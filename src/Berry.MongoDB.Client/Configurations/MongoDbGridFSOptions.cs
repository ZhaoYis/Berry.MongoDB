using System;
using System.ComponentModel.DataAnnotations;

namespace Berry.MongoDB.Configurations
{
    /// <summary>
    /// MongoDbGridFSOptions
    /// </summary>
    public class MongoDbGridFSOptions
    {
        public const int DefaultChunkSizeBytes = 1048576;
        public const int DefaultBatchSize = 1048576;

        /// <summary>
        /// GridFS默认块大小（以字节为单位）。系统默认1MB
        /// </summary>
        [Range(0, int.MaxValue)]
        public int ChunkSizeBytes { get; set; } = DefaultChunkSizeBytes;

        /// <summary>
        /// GridFS默认批处理大小（以字节为单位）。系统默认1MB
        /// </summary>
        [Range(0, int.MaxValue)]
        public int BatchSize { get; set; } = DefaultBatchSize;

        /// <summary>
        /// 文件上传时是否禁用MD5计算
        /// </summary>
        public bool DisableMD5 { get; set; }

        /// <summary>
        /// 获取或设置一个指示返回的流是否支持寻求的值
        /// </summary>
        public bool Seekable { get; set; }
    }
}
