using Quiz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Interfaces
{
    public interface ILoginRepository
    {
        public Task<User> GetByLoginAsync(string login);
    }
}
