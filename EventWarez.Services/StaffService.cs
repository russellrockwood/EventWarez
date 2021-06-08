using EventWarez.Data;
using EventWarez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Services
{
    public class StaffService
    {
        public bool CreateStaff(StaffCreate model)
        {
            var entity =
              new Staff()
              {
                 FirstName = model.FirstName,
                 LastName = model.LastName,
                 Department = model.Department,
                 AccessLevel = model.AccessLevel
              };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Staff.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StaffDetail> GetStaffDetails()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Staff
                        .Select(
                            e => new StaffDetail 
                            {
                                StaffId = e.StaffId,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Department = e.Department,
                                AccessLevel = e.AccessLevel
                            }
                        );
                return query.ToArray();
            }
        }

        public StaffDetail GetStaffById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Staff
                        .Single(e => e.StaffId == id);
                return
                    new StaffDetail
                    {
                        StaffId = entity.StaffId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Department = entity.Department,
                        AccessLevel = entity.AccessLevel
                    };


            }
        }

        public bool UpdateStaff(StaffDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Staff
                        .Single(e => e.StaffId == model.StaffId);

                
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Department = model.Department;
                entity.AccessLevel = model.AccessLevel;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletStaff(int staffId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Staff
                        .Single(e => e.StaffId == staffId);

                ctx.Staff.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
