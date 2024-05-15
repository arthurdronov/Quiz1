using Quiz.Domain.Entities;
using Quiz.Domain.Interfaces;
using Quiz.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Infra.Data.Repositories
{
	public class PerfilRepository : IPerfilRepository
	{
		private readonly ApplicationDbContext _perfilContext;
        public PerfilRepository(ApplicationDbContext perfilContext)
        {
            _perfilContext = perfilContext;
        }
        public async Task<User> GetByIdAsync(int? id)
		{
			return await _perfilContext.Users.FindAsync(id);
		}
	}
}
