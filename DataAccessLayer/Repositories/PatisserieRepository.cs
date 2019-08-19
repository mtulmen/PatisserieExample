using DataAccessLayer.MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PatisserieRepository
    {
        public Cake Find(int id)
        {
            Model1 ctx = new Model1();
            //  Cake entity = ctx.Cakes.Where(c => c.Id == id).FirstOrDefault();
            Cake entity = ctx.Set<Cake>().Find(id);
            return entity;
        }

        public List<Cake> List()
        {
            Model1 ctx = new Model1();
            return ctx.Set<Cake>().ToList();
        }

        public void Add(Cake entity)
        {
            Model1 ctx = new Model1();
            ctx.Set<Cake>().Add(entity);
            ctx.SaveChanges();
        }

        public void Update(Cake entity)
        {
            Model1 ctx = new Model1();
            ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
