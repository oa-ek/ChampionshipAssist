using ChampionshipAssist.Core.Context;
using ChampionshipAssist.Core.Entities;
using ChampionshipAssist.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipAssist.Repositories.Repos
{
    public class UserRepository : IUserRepository
    {
        private ChampionsshipAssistDbContext _context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityUser> roleManager;

        public UserRepository(ChampionsshipAssistDbContext context)
        {
            _context = context;
        }
        public void Add(User obj)
        {
            _context.Users.Add(obj);
            Save();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(User obj)
        {
            _context.Users.Update(obj);
        }
    }
}
