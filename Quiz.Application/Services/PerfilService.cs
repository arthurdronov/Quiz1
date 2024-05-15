using AutoMapper;
using Quiz.Application.DTOs;
using Quiz.Application.Interfaces;
using Quiz.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Services
{
	public class PerfilService : IPerfilService
	{
		private readonly IPerfilRepository _perfilRepository;
		private readonly IMapper _mapper;
        public PerfilService(IPerfilRepository perfilRepository, IMapper mapper)
        {
            _perfilRepository = perfilRepository;
			_mapper = mapper;
        }
        public async Task<UserDTO> GetById(int? id)
		{
			var perfil = await _perfilRepository.GetByIdAsync(id);
			return _mapper.Map<UserDTO>(perfil);
		}
	}
}
