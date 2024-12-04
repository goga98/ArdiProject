using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces;
using Insurance.Persistence.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Insurance.Persistence.Repositories
{
    public class PolicyRepository : BaseRepository<InsurancePolicy>, IPolicyRepository
    {
        public PolicyRepository(InsuranceDbContext context, IConfiguration configuration)
            : base(context, configuration) { }

        public async Task<IEnumerable<InsurancePolicy>> GetByInsuredIdAsync(int insuredId)
        {
            // Using Dapper
            const string sql = "SELECT * FROM Policies WHERE InsuredId = @InsuredId";
            return await _connection.QueryAsync<InsurancePolicy>(sql, new { InsuredId = insuredId });
        }
    }
}
