using Quiz.Application.DTOs;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Interfaces
{
	public interface IPerfilService
	{
		public Task<UserDTO> GetById(int? id);
	}
}
