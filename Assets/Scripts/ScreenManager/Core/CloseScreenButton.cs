﻿using ScreenManager.Events;
using SimpleBus.Extensions;
using UnityEngine;

namespace ScreenManager.Core
{
    public class CloseScreenButton : MonoBehaviour
    {
        [SerializeField]
        private UIScreen _screen;

        public void Close()
        {
            CloseScreenByGuidEvent.Create(_screen.Guid).Publish(EventStreams.UserInterface);
        }
    }
}
