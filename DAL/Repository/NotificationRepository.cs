using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class NotificationRepository : GenericDataRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}
