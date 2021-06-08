using EventWarez.Data;
using EventWarez.Models.Show;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Services
{
    public class ShowService
    {
        private readonly Guid _userId;
        public ShowService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShow(ShowCreate model)
        {
            var entity = new Show()
            {
                OwnerId = _userId,
                Feature = model.Feature,
                ShowTime = model.ShowTime
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShowListItem> GetShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Shows
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ShowListItem
                        {
                            ShowId = e.ShowId,
                            Feature = e.Feature,
                            ShowTime = e.ShowTime
                        }
                        );
                return query.ToArray();
            }
        }

    }
}
