namespace NotificationApi.Models
{
    public class NotificationResponse
    {
        public string companyId { get; set; } = string.Empty;
        public string[] notifications { get; set; } = new string[0];
    }
}
