using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Flutter.Support.Repository
{
   public abstract class AbstractDenormalizer
    {
        protected IConnectionStringResolver ConnectionStringResolver { get; }

        public AbstractDenormalizer(IConnectionStringResolver connectionStringResolver)
        {
            ConnectionStringResolver = connectionStringResolver;
        }

        protected DbConnection GetConnection()
        {
            return new SqlConnection(ConnectionStringResolver.GetConnectionString());
        }


        protected bool TryInsertRecord(Func<IDbConnection, bool> action)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    return action(connection);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)  //主键冲突，忽略即可；出现这种情况，是因为同一个消息的重复处理
                {
                    return false;
                }
                throw new IOException("Insert record failed.", ex);
            }
        }
        protected async Task TryInsertRecordAsync(Func<IDbConnection, Task<long>> action)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    await action(connection);
                    return;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)  //主键冲突，忽略即可；出现这种情况，是因为同一个消息的重复处理
                {
                    return;
                }
                throw new IOException("Insert record failed.", ex);
            }
        }
        protected bool TryUpdateRecord(Func<IDbConnection, bool> action)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    return action(connection);
                }
            }
            catch (SqlException ex)
            {
                throw new IOException("Update record failed.", ex);
            }
        }
        protected async Task TryUpdateRecordAsync(Func<IDbConnection, Task<int>> action)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    await action(connection);
                }
            }
            catch (SqlException ex)
            {
                throw new IOException("Update record failed.", ex);
            }
        }

        protected async Task TryUpdateRecordAsync(Func<IDbConnection, Task<bool>> action)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    await action(connection);
                    return;
                }
            }
            catch (SqlException ex)
            {
                throw new IOException("Update record failed.", ex);
            }
        }
        protected void TryTransaction(Action<IDbConnection, IDbTransaction> action)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    action(connection, transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        protected async Task TryTransactionAsync(Func<IDbConnection, IDbTransaction, Task> action)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    await action(transaction.Connection, transaction).ConfigureAwait(false);
                    await Task.Run(() => transaction.Commit()).ConfigureAwait(false);
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
