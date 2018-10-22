﻿//
//  Copyright 2018  AppRopio
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Firebase.Messaging;

namespace AppRopio.Base.Droid.FCM
{
    [Preserve(AllMembers = true)]
    [Service]
    [IntentFilter(new string[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class ARFirebaseMessagingService : FirebaseMessagingService
    {
        public ARFirebaseMessagingService()
        {
        }

        protected ARFirebaseMessagingService(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Verbose(this.PackageName, "On push message received");

            System.Diagnostics.Debug.WriteLine(message: $"On push message received", category: this.PackageName);

            base.OnMessageReceived(message);

            ParseRemoteMessage(message);
        }

        private void ParseRemoteMessage(RemoteMessage message)
        {
            var data = message.Data;
            var notification = message.GetNotification();

            data.TryGetValue(PushConstants.PUSH_DEEPLINK_KEY, out var deeplink);
            data.TryGetValue(PushConstants.PUSH_TITLE_KEY, out var title);
            data.TryGetValue(PushConstants.PUSH_BODY_KEY, out var body);

            SheduleNotification(notification?.Title ?? title, notification?.Body ?? body, message.MessageId, deeplink);
        }

        private void SheduleNotification(string title, string message, string id, string deeplink)
        {
            EnsureIconResourceSet();

            var notificationIntent = new Intent(Application.Context, FcmSettings.Instance.ActivityType); // Application.Context.PackageManager.GetLaunchIntentForPackage(PackageName);
            notificationIntent.SetFlags(ActivityFlags.SingleTop);
            notificationIntent.SetAction(Guid.NewGuid().ToString());

            if (!deeplink.IsNullOrEmpty())
                notificationIntent.PutExtra(PushConstants.PUSH_DEEPLINK_KEY, deeplink);

            var notificationPendingIntent = PendingIntent.GetActivity(Application.Context, 2, notificationIntent, PendingIntentFlags.UpdateCurrent);

            var notificationBuilder = new NotificationCompat.Builder(Application.Context)
                .SetAutoCancel(true)
                .SetContentIntent(notificationPendingIntent)
                .SetContentTitle(title ?? PackageName)
                .SetContentText(message)
                .SetSmallIcon(FcmSettings.Instance.IconResourceId)
                .SetChannelId(PackageName)
                .SetPriority((int)NotificationPriority.High)
                .SetColor(Color.ParseColor(FcmSettings.Instance.ColorHex).ToArgb())
                .SetStyle(new NotificationCompat.BigTextStyle().BigText(message).SetBigContentTitle(title))
                .SetDefaults((int)NotificationDefaults.All)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
                .SetVibrate(new long[] { 300 });

            var notification = notificationBuilder.Build();

            notification.Flags = NotificationFlags.AutoCancel;

            var notificationManager = (NotificationManager)Application.Context.GetSystemService(NotificationService);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(PackageName, "Main channel", NotificationImportance.Default);
                notificationManager.CreateNotificationChannel(channel);
            }

            notificationManager.Notify(id.GetHashCode(), notification);
        }

        private void EnsureIconResourceSet()
        {
            if (FcmSettings.Instance.IconResourceId == 0)
            {
                FcmSettings.Instance.IconResourceId = Application.Context.ApplicationInfo.Icon;
            }
        }
    }
}