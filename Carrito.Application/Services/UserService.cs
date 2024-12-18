using AutoMapper;
using Carrito.Application.DTOs;
using Carrito.Application.Interfaces.Services;
using Carrito.Application.Interfaces.UnitOfWork;
using Carrito.Domain.Entities;

namespace Carrito.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateUserDto> CreateUserAsync(UserDto dto)
        {
            if (dto == null)
                throw new ArgumentException("El usuario no puede ser nulo.");

            var user = _mapper.Map<User>(dto);
            await _unitOfWork.UsersRepository.CreateAsync(user);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CreateUserDto>(user);
        }

        public async Task<List<UserCartDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UsersRepository.GetAllAsync();
            var userDtos = _mapper.Map<List<UserCartDto>>(users);
            return userDtos;
        }

        public async Task<UserCartDto> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.UsersRepository.GetByIdAsync(id);
            return user != null ? _mapper.Map<UserCartDto>(user) : null;
        }

    }
}
