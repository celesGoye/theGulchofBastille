﻿using System;
using UnityEngine.Events;

public class UIEventListener
{
    private static UIEventListener _instance;

    public static UIEventListener Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new UIEventListener();
            }
            return _instance;
        }
    }

    #region DELEGATE
    public delegate void StatusBarChangeHandler(float current, float total);
    public delegate void SimpleEventHandler();
    #endregion

    #region EVENTS
    public event StatusBarChangeHandler hpChangeHandler;
    public event StatusBarChangeHandler dpChangeHandler;
    public event SimpleEventHandler fullscreenSwitchHandler;
    // public event Action pauseMenuHandler;
    #endregion

    #region INTERFACE TO OUTER SCRIPTS
    public void OnHpChange(float current, float total)
    {
        hpChangeHandler?.Invoke(current, total);
    }

    public void OnDpChange(float current, float total)
    {
        dpChangeHandler?.Invoke(current, total);
    }

    public void OnFullscreenSwitch(){
        fullscreenSwitchHandler.Invoke();
    }

    // public void OnPauseMenu()
    // {
    //     pauseMenuHandler?.Invoke();
    // }
    #endregion
}
