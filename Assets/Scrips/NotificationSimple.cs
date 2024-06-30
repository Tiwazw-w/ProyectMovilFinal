using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


using Unity.Notifications.Android;
using UnityEngine.Android;

public class NotificationSimple : MonoBehaviour
{
    public static NotificationSimple instance { get; private set; }
    private const string idCanal = "canalNotificacion";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);

        }
    }


    private void Start()
    {
        RequestAuhtorization();
        RegisterNotificationChannel();
        SendNotification("Por fin volviste", "Prodras llegar al final", 0f);
    }

    //Request authorization to send notifications
    public void RequestAuhtorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    //Register a Notification Channel
    public void RegisterNotificationChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel
        {
            Id = "default_channel",
            Name = "Default",
            Importance = Importance.Default,
            Description = "Notifications"
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }




    //Set Up Notification Template
    public void SendNotification(string title, string text, float fireTimeInHours)
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = DateTime.Now.AddMinutes(fireTimeInHours);
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }




    public void ButtonFunction()
    {
        SendNotification("Dummy Notification", "This is a sample Notification", 0);
    }

    void OnApplicationQuit()
    {
        SendNotification("Esto aun no termina", "Tu final ya esta escrito",  0.5f);
    }
}
