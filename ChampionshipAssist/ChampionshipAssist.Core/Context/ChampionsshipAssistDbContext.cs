using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChampionshipAssist.Core.Context
{
    public class ChampionsshipAssistDbContext : IdentityDbContext
    {
        public ChampionsshipAssistDbContext(DbContextOptions<ChampionsshipAssistDbContext> options)
            : base(options)
        {
        }
    }
}