using Forum.WebAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebAPI.Repositories.Posts
{
    public interface IPostsRepository
    {
        Task<List<PostsDto>> GetPosts();
        Task<List<PostsDto>> GetPostsByUser(int Id);
    }
}
