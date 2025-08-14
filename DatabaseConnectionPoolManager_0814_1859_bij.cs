// 代码生成时间: 2025-08-14 18:59:07
using System;
using System.Collections.Concurrent;
using System.Data.Common;
using System.Data;
# FIXME: 处理边界情况
using System.Threading.Tasks;

namespace DatabaseConnectionPoolManagement
{
    /// <summary>
    /// Provides a basic implementation of a database connection pool.
    /// </summary>
    public class DatabaseConnectionPoolManager
    {
        private readonly ConcurrentBag<DbConnection> _pool;
        private readonly string _connectionString;
        private readonly int _maxPoolSize;
        private readonly Type _connectionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnectionPoolManager"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        /// <param name="maxPoolSize">The maximum number of connections to keep in the pool.</param>
        public DatabaseConnectionPoolManager(string connectionString, int maxPoolSize)
        {
# NOTE: 重要实现细节
            _connectionString = connectionString;
            _maxPoolSize = maxPoolSize;
            _pool = new ConcurrentBag<DbConnection>();

            // Determine the type of connection based on the connection string.
            // This is a simplification and in real-world scenarios, you would use
# TODO: 优化性能
            // a more robust method to determine the type.
            if (connectionString.Contains("Server=") && connectionString.Contains("Database="))
            {
                _connectionType = typeof(System.Data.SqlClient.SqlConnection);
            }
            else
            {
# FIXME: 处理边界情况
                _connectionType = typeof(MySql.Data.MySqlClient.MySqlConnection);
            }
        }

        /// <summary>
        /// Gets a connection from the pool or creates a new one if the pool is empty.
        /// </summary>
        /// <returns>A database connection.</returns>
        public DbConnection GetConnection()
# 改进用户体验
        {
            if (_pool.TryTake(out DbConnection connection))
            {
                if (connection.State != ConnectionState.Open)
# FIXME: 处理边界情况
                {
                    connection.Open();
                }
                return connection;
            }
# 改进用户体验
            else if (_pool.Count < _maxPoolSize)
            {
                var newConnection = (DbConnection)Activator.CreateInstance(_connectionType);
                newConnection.ConnectionString = _connectionString;
                newConnection.Open();
                _pool.Add(newConnection);
                return newConnection;
            }
            else
            {
                throw new InvalidOperationException("Connection pool has reached its maximum size and cannot provide more connections.");
            }
        }

        /// <summary>
# 优化算法效率
        /// Returns a connection to the pool.
        /// </summary>
        /// <param name="connection">The connection to return to the pool.</param>
        public void ReturnConnection(DbConnection connection)
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                throw new ArgumentException("Connection cannot be null and must be closed before returning to the pool.", nameof(connection));
            }
            connection.Close();
# 优化算法效率
            _pool.Add(connection);
        }

        /// <summary>
        /// Clears the pool by closing all connections and removing them from the pool.
        /// </summary>
        public void ClearPool()
        {
            foreach (var connection in _pool)
            {
                connection.Close();
            }
            _pool.Clear();
        }

        // Destructor to ensure all connections are closed when the manager is disposed.
        ~DatabaseConnectionPoolManager()
        {
            ClearPool();
        }
# 优化算法效率
    }
}
