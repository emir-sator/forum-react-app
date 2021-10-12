using Newtonsoft.Json;

namespace Forum.WebAPI.Dto
{
    public  class UsersDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        [System.Text.Json.Serialization.JsonIgnore]
        public string Password { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; } 
    }
}
