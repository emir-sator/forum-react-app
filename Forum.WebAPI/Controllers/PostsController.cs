using Forum.WebAPI.Database;
using Forum.WebAPI.Dto;
using Forum.WebAPI.Repositories.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forum.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsRepository _postsRepository;
        public PostsController(IPostsRepository postsRepository) : base()
        {
            _postsRepository = postsRepository;
        }

        //[Authorize]
        [HttpGet]
        public async Task<List<PostsDto>> Get()
        {
            return await _postsRepository.GetPosts();
        }

        //[Authorize]
        [HttpGet("{userId}")]
        public async Task<List<PostsDto>> GetPostsByUser(int userId)
        {
            return await _postsRepository.GetPostsByUser(userId);
        }
    }
}
