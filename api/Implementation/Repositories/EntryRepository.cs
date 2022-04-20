using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Application;
using api.Entities;
using api.Interface.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace api.Implementation.Repositories
{
    public class EntryRepository:IEntryRepository
    {
        private readonly ApplicationContext _context;

        public EntryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Entry> CreateEntry(Entry entry)
        {
            await _context.Entries.AddAsync(entry);
            await _context.SaveChangesAsync();
            return entry;
        }

        public void SaveChanges()
        {
             _context.SaveChanges();
        }

        public async Task<Entry> UpdateEntry(Entry entry)
        {
            _context.Entries.Update(entry);
            await _context.SaveChangesAsync();
            return entry;
        }

        public async Task<IList<Entry>> GetEntriesByExpression(Expression<Func<Entry, bool>> expression)
        {
            return await _context.Entries.Where(expression).Include(E => E.Game)
                .Include(E => E.Initial)
                .Include(E => E.Player).ToListAsync();
        }

        public async Task<IList<Entry>> GetEntries()
        {
            return await _context.Entries.
                Include(E => E.Game)
                .Include(E => E.Initial)
                .Include(E => E.Player).ToListAsync();
        }

        public async Task<Entry> GetEntry(Expression<Func<Entry, bool>> expression)
        {
            return await _context.Entries.Include(E => E.Game)
                .Include(E => E.Initial)
                .Include(E => E.Player)
                .Where(expression).SingleOrDefaultAsync();
        }
    }
}