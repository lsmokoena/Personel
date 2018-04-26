using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class NotificationTypeRepository : GenericDataRepository<NotificationType>, INotificationTypeRepository
    {
        public NotificationTypeRepository(PersonelContext context, Serilog.ILogger logger) : base(context, logger)
        {
        }
    }
}
