using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class NotificationContentRepository : GenericDataRepository<NotificationContent>, INotificationContentRepository
    {
        public NotificationContentRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}
