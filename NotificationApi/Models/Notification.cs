using System.ComponentModel.DataAnnotations;
public class Notification
{
    private string? _country;
    private string? _size;
    [Key]
    public long Id { get; set; }
    [Required]
    public string? CompanyName { get; set; }
    [Required]
    public string? CompanyId { get; set; }
    [Required]
    public string? Country
    {
        get => _country;
        set => _country = value.ToLower();
    }
    [Required]
    public string? Size
    {
        get => _size;
        set => _size = value.ToLower();
    }
    public DateTime? CreatedDate { get; } = DateTime.Now;
    public int[] NotificationDays
    {
        get
        {
            switch (Country)
            {
                case "denmark":
                    {
                        return new int[] { 1, 5, 10, 15, 20 }; ;
                    }

                case "norway":
                    {
                        return new int[] { 1, 5, 10, 20 }; ;
                    }

                case "sweden":
                    {
                        return new int[] { 1, 7, 14, 28 }; ;
                    }

                case "finland":
                    {
                        return new int[] { 1, 5, 10, 15, 20 }; ;
                    }

                default:
                    return new int[0];
            }
        }
    }
    public bool CanReceiveNotifications
    {
        get
        {
            switch (Country)
            {
                case "denmark":
                    return true;

                case "norway":
                    return true;

                case "sweden":
                    if (Size == "small" || Size == "medium")
                        return true;
                    else
                        return false;

                case "finland":
                    if (Size == "large")
                        return true;
                    else
                        return false;

                default:
                    return false;
            }
        }
    }
}
