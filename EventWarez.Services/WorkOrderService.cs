using EventWarez.Data;
using EventWarez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventWarez.Services
{
    public class WorkOrderService
    {
        public bool CreateWorkOrder(WorkOrderCreate model)
        {
            var entity =
                new WorkOrder()
                {
                    StaffId = model.StaffId,
                    ShowId = model.ShowId,
                    Department = model.Department,
                    CreatedUtc = DateTime.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.WorkOrders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<WorkOrderDetail> GetWorkOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .WorkOrders
                        .Select(
                            e =>
                                new WorkOrderDetail
                                {
                                    WorkOrderId = e.WorkOrderId,
                                    StaffId = e.StaffId,
                                    ShowId = e.ShowId,  
                                    Department = e.Department,
                                    CreatedUtc = e.CreatedUtc, 
                                    ModifiedUtc = e.ModifiedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public WorkOrderDetail GetWorkOrder(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkOrders
                        .Single(e => e.WorkOrderId == id);
                return
                    new WorkOrderDetail
                    {
                        WorkOrderId = entity.WorkOrderId,
                        StaffId = entity.StaffId,
                        ShowId = entity.ShowId,
                        Department = entity.Department,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateWorkOrder(WorkOrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkOrders
                        .Single(e => e.WorkOrderId == model.WorkOrderId);

                entity.StaffId = model.StaffId;
                entity.ShowId = model.ShowId;
                entity.Department = model.Department;
                entity.ModifiedUtc = DateTime.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWorkOrder(int workOrderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WorkOrders
                        .Single(e => e.WorkOrderId == workOrderId);

                ctx.WorkOrders.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
