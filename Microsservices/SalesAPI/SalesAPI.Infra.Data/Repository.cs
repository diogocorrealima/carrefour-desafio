using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using SalesAPI.Domain.Core;
using SalesAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Infra.Data
{
    public abstract class Repository<T> : IRepository<T>, IUnitOfWork
         where T : class
    {
        protected readonly MongoContext<T> _context;
        private readonly IConfiguration _configuration;

        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
            _context = new MongoContext<T>(configuration);
        }
    

        #region Sync

        public void Add(T obj)
        {
            _context.Collection.InsertOne(obj);
        }

        public void Update(Expression<Func<T, bool>> expression, T obj)
        {
            _context.Collection.ReplaceOne(expression, obj);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            _context.Collection.FindOneAndDelete(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Collection.Find(_ => true).ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Collection.Find(predicate).ToList();
        }

        #endregion Sync

        #region Async

        public async Task AddASync(T obj)
        {
            await _context.Collection.InsertOneAsync(obj);
        }

        public async Task UpdateAsync(Expression<Func<T, bool>> expression, T obj)
        {
            await _context.Collection.ReplaceOneAsync(expression, obj);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            await _context.Collection.FindOneAndDeleteAsync(predicate);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return (await _context.Collection.FindAsync(predicate)).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await _context.Collection.FindAsync(_ => true)).ToList();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Async

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task<bool> Commit()
        {
            return await Task.FromResult(true);
        }
    }
}
