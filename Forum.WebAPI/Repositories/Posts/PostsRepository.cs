using AutoMapper;
using Forum.WebAPI.Database;
using Forum.WebAPI.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Forum.WebAPI.Repositories.Posts
{
    public class PostsRepository : IPostsRepository
    {

        private readonly ForumDBContext _context;
        private readonly IMapper _mapper;



        public PostsRepository(ForumDBContext context,IMapper mapper) : base()
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PostsDto>> GetPosts()
        {
            var list = await _context.Posts.ToListAsync();

            return _mapper.Map<List<PostsDto>>(list);
        }

        public async Task<List<PostsDto>> GetPostsByUser(int userId)
        {

            var list = await _context.Posts.Where(p => p.UserId == userId).ToListAsync();

            return _mapper.Map<List<PostsDto>>(list);
        }
    }
}
