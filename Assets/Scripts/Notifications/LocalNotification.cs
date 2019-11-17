using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SimpleAndroidNotifications;
using UnityEngine;
using UnityEngine.Android;

public class LocalNotification : MonoBehaviour{

    private string title = "Quiz of Cybersport";
    private string content = "Не забывай соревноваться"+"\n"+"с друзьями!";

 private void OnApplicationQuit() {
    #if UNITY_ANDROID 
    //Увидомление каждые 10 сек.
            DateTime timeNotify = DateTime.Now.AddHours(6f);
            TimeSpan time = timeNotify - DateTime.Now;
            NotificationManager.SendWithAppIcon(time, title, content, Color.red, NotificationIcon.Heart);

    //Увидомление каждый 3й день
           DateTime timeNotifyDay = DateTime.Now.AddDays(3f);
            TimeSpan timeDay = timeNotifyDay - DateTime.Now;
            NotificationManager.SendWithAppIcon(timeDay, title, content, Color.red, NotificationIcon.Heart);
        #endif
}
    void OnApplicationPause(bool isPause) {
        #if UNITY_ANDROID 
        NotificationManager.CancelAll();
        if (isPause){
            DateTime timeNotify = DateTime.Now.AddHours(6f);
            TimeSpan time = timeNotify - DateTime.Now;
            NotificationManager.SendWithAppIcon(time, title, content, Color.red, NotificationIcon.Heart);
        }
        #endif
    }

}