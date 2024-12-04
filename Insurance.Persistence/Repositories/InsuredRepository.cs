using Insurance.Domain.Entities;
using Insurance.Domain.Interfaces;
using Insurance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Insurance.Persistence.Repositories
{
    public class InsuredRepository : BaseRepository<Insured>, IInsuredRepository
    {
        public InsuredRepository(InsuranceDbContext context, IConfiguration configuration)
            : base(context, configuration) { }

        public async Task<Insured> GetWithPoliciesAsync(int id)
        {
            // Using Entity Framework
            return await _context.Insureds
                .Include(i => i.Policies)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Insured>> GetAllWithPoliciesAsync()
        {
            // Using Dapper

            var insuredDict = new Dictionary<int, Insured>();
            try
            {
                const string sql = @"
            SELECT i.*, p.*
            FROM Insureds i
            LEFT JOIN Policies p ON i.Id = p.InsuredId";


                await _connection.QueryAsync<Insured, InsurancePolicy, Insured>(
                    sql,
                    (insured, policy) =>
                    {
                        if (!insuredDict.TryGetValue(insured.Id, out var existingInsured))
                        {
                            existingInsured = insured;
                            existingInsured.Policies = new List<InsurancePolicy>();
                            insuredDict.Add(insured.Id, existingInsured);
                        }

                        if (policy != null)
                        {
                            existingInsured.Policies.Add(policy);
                        }

                        return existingInsured;
                    },
                    splitOn: "Id");

            }

            catch(Exception ex) {
                throw new Exception(ex.Message);
            }

            return insuredDict.Values;

        }
    }
}
