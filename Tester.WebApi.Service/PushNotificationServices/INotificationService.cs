using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using CorePush.Google;
using Microsoft.Extensions.Options;
using Tester.WebApi.Service.Models;
using Tester.WebApi.Service.PushNotification;

namespace Tester.WebApi.Service.PushNotificationServices
{
    public interface INotificationService
    {
        Task<ResponseModel> SendNotification(NotificationModel notificationModel);
    }
}
