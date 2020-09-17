using System;
using Abp.Notifications;
using FintrakERPIMSDemo.Dto;

namespace FintrakERPIMSDemo.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}