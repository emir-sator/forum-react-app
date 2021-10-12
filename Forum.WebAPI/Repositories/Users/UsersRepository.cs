using AutoMapper;
using Forum.WebAPI.Database;
using Forum.WebAPI.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Forum.WebAPI.Repositories.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ForumDBContext _context;
        private readonly IMapper _mapper;

        public UsersRepository(ForumDBContext context,IMapper mapper) : base()
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UsersDto>> GetUsers()
        {
            var list = await _context.Users.ToListAsync();

            return _mapper.Map<List<UsersDto>>(list);
        }

        public async Task<UsersDto> GetByUsername(string username)
        {
            var query = _context.Users.AsQueryable();
            if (username != null)
            {
                query = query.Where(u => u.Username == username);
            }
            var user = await query.FirstOrDefaultAsync();
            return _mapper.Map<UsersDto>(user);

        }

        public async Task<UsersDto> GetById(int id)
        {
            var user =await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<UsersDto>(user);
        }

        public async Task<List<UsersDto>> SearchUsers(string searchTerm)
        {
            var query = _context.Users.AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(u => u.Name.ToLower().Contains(searchTerm.ToLower())|| u.Username.ToLower().Contains(searchTerm.ToLower()));
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<UsersDto>>(list);
        }
    }
}
