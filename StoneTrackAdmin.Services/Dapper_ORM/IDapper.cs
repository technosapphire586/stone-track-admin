using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Services
{
    public interface IDapper : IDisposable
    {

        Task<IEnumerable<T>> GetAllAsync<T>(string query);
        Task<IEnumerable<T>> GetAllAsync<T>(string query, DynamicParameters parameters);
        Task ExecuteProcedure(string procedureName, DynamicParameters parameters);
        Task Delete(string query, DynamicParameters parameters);
        Task Update(string query, DynamicParameters parameters);
        Task ExecuteProcedure(string procedureName);
        Task<T> ExecuteProcedureFirstOrDefault<T>(string procedureName, DynamicParameters parameters);

        Task<IEnumerable<T>> ExecuteProcedure<T>(string procedureName, DynamicParameters parameters);
        Task<T> GetFirstOrDefaultAsync<T>(string query);
        Task<T> GetFirstOrDefaultAsync<T>(string query, DynamicParameters parameters);

        Task InsertDelete(string query, DynamicParameters parameters);
    }
}
