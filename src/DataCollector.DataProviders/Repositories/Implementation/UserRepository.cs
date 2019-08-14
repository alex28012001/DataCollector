﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DataCollector.DataProviders.Repositories.Abstraction;
using DataCollector.Models.Entities;
using MongoDB.Driver;

namespace DataCollector.DataProviders.Repositories.Implementation
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString)
            : base(connectionString)
        {
        }

        public async Task BulkInsertAsync(IEnumerable<User> users)
        {
            var bulkCollection = new List<WriteModel<User>>();

            foreach (var user in users)
            {
                var insertModel = new InsertOneModel<User>(user);
                bulkCollection.Add(insertModel);
            }

            await _db.Users.BulkWriteAsync(bulkCollection);
        }
    }
}