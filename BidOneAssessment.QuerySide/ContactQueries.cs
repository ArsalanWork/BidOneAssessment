using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BidOneAssessment.QuerySide
{
    public class ContactQueries : IContactQueries
    {
        private readonly string _connectionString;

        public ContactQueries(IOptions<Settings.ReadStoreSettings> databaseSettings)
        {
            _connectionString = !string.IsNullOrWhiteSpace(databaseSettings?.Value.ConnectionString) ? databaseSettings.Value.ConnectionString : throw new ArgumentNullException(nameof(databaseSettings));
        }

        public async Task<IEnumerable<ContactViewModel>> GetContactsAsync(int pageNumber, int pageSize)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var skip = pageSize * (pageNumber - 1);
                var fetch = pageSize;
                connection.Open();

                return await connection.QueryAsync<ContactViewModel>(@"
                    SELECT c.Id AS ContactId, c.FirstName, c.LastName, c.Email, c.Status, c.InterestedInCommunications
                    FROM contacts AS c
                    LIMIT @skip, @fetch", new { skip, fetch });
            }
        }
    }
}
