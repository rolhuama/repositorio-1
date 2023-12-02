using ColabManager360.Domain.Entities.Security.Models;

namespace ColabManager360.Domain.Entities.Account.Responses
{
    public  class MenuListResponse
    {
        public ICollection<MenuGroup> Groups { get; set; }
        public ICollection<Menu> Links { get; set; }
    }
}
