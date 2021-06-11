﻿using EventWarez.Data;
using EventWarez.Models;
using EventWarez.Models.Show;
using EventWarez.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Services
{
    public class ShowService
    {
        public bool CreateShow(ShowCreate model)
        {
            var entity = new Show()
            {
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

        public ShowDetail GetShowById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shows
                    .Single(e => e.ShowId == id);
                return
                    new ShowDetail
                    {
                        ShowId = entity.ShowId,
                        Feature = entity.Feature,
                        ShowTime = entity.ShowTime
                    };
            }
        }

        public bool UpdateShow(ShowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shows
                    .Single(e => e.ShowId == model.ShowId);

                entity.Feature = model.Feature;
                entity.ShowTime = model.ShowTime;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShow(int showId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shows
                    .Single(e => e.ShowId == showId);

                ctx.Shows.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //
        public bool SellOut(int showId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shows
                    .Single(e => e.ShowId == showId);
                entity.IsSoldOut = false;
                entity.IsSoldOut = true;
                return ctx.SaveChanges() == 1;
            }
        }
        //
    }


}

