using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public interface ISkillRepository
    {
        Skill Add(Skill skill);
        IEnumerable<Skill> GetAll();
        Skill GetById(int id);
        void Delete(Skill skill);
        void Update(Skill skill);
    }
}
