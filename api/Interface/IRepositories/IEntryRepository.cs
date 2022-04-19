using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Entities;

namespace api.Interface.IRepositories
{
    public interface IEntryRepository
    {
        public Task<Entry> CreateEntry(Entry entry);
        public Task<Entry> UpdateEntry(Entry entry);
        public Task<IList<Entry>> GetEntriesByExpression(Expression<Func<Entry, bool>> expression);
        public Task<IList<Entry>> GetEntries();
        public Task<Entry> GetEntry(Expression<Func<Entry, bool>> expression);
    }
}