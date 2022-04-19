using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Entities;
using api.Interface.IRepositories;

namespace api.Implementation.Repositories
{
    public class EntryRepository:IEntryRepository
    {
        public Task<Entry> CreateEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public Task<Entry> UpdateEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Entry>> GetEntriesByExpression(Expression<Func<Entry, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Entry>> GetEntries()
        {
            throw new NotImplementedException();
        }

        public Task<Entry> GetEntry(Expression<Func<Entry, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}