using DB.Models;
using Logic.Extensions;
using Logic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Logic.Repository
{
    public class SkillsRepository : Repository<Yetenekler>, ISkillsRepository
    {
        public override IList<Yetenekler> Where(Expression<Func<Yetenekler, bool>> predicate)
        {
            return _context.Yetenekler.Where(predicate).Include("Kategori").ToList();
        }

        public override bool Update(Yetenekler model)
        {
            return _context.UpdateEntity(model, nameof(model.EklemeTarihi), nameof(model.DegisimTarihi)) > 0;
        }
    }
}