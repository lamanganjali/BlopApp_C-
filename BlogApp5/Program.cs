using System;


class Notification
{
    public int NotificationID { get; set; }
    public string Message { get; set; }

    public virtual void DisplayNotification()
    {
        Console.WriteLine($"Notification: {Message}");
    }
}

class NewPostNotification : Notification
{
    public string PostTitle { get; set; }
    public override void DisplayNotification()
    {
        Console.WriteLine($"New Post Alert: {PostTitle}, Message: {Message}");
    }
}


class NewCommentNotification : Notification
{
    public string CommentAuthor { get; set; }
    public override void DisplayNotification()
    {
        Console.WriteLine($"New Comment Alert by {CommentAuthor}, Message: {Message}");
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Notification[] notifications = new Notification[3];
            notifications[0] = new NewPostNotification { NotificationID = 1, Message = "New post created!", PostTitle = "OOP Concepts" };
            notifications[1] = new NewCommentNotification { NotificationID = 2, Message = "Commented on your post.", CommentAuthor = "Alice" };
            notifications[2] = new NewPostNotification { NotificationID = 3, Message = "New post created!", PostTitle = "Inheritance in C#" };

            foreach (var notification in notifications)
            {
                notification.DisplayNotification();
            }

            Notification[] emptyNotifications = new Notification[0];
            if (emptyNotifications.Length == 0) throw new Exception("No notifications available.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

