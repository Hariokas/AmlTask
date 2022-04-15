using NotificationApi.Models;
using System.Text.Json;

namespace NotificationApi.Controllers
{
    public class NotificationController
    {
        private static string[] CalculateNotificationDates(Notification notification)
        {
            if (notification.NotificationDays != null && notification.CanReceiveNotifications)
            {
                int ArraySize = notification.NotificationDays.Length;
                int[] DaysToSendNotifications = notification.NotificationDays;

                DateTime dateTime = DateTime.Now;
                string[] calculatedDatesResult = new string[ArraySize];

                for (int i = 0; i < ArraySize; i++)
                {
                    if (dateTime.Day <= DaysToSendNotifications[i])
                    {
                        calculatedDatesResult[i] = new DateTime(dateTime.Year, dateTime.Month, notification.NotificationDays[i]).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        calculatedDatesResult[i] = new DateTime(dateTime.Year, dateTime.Month + 1, notification.NotificationDays[i]).ToString("yyyy-MM-dd");
                    }
                }
                Array.Sort(calculatedDatesResult);
                return calculatedDatesResult;

            }
            return new string[0];
        }

        public static string FormattedJsonResponse(Notification notification)
        {
            NotificationResponse responseObj = new NotificationResponse();
            responseObj.companyId = notification.CompanyId;
            responseObj.notifications = CalculateNotificationDates(notification);

            return JsonSerializer.Serialize(responseObj);
        }
    }
}
