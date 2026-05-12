using System;
using UnityEngine;

public class SettingManager : MonoBehaviour
{

    public static SettingManager Instance { get; private set; }
    public enum TouchState
    {
        PC,
        ArrowButton,
        joystick,
    }

    public event EventHandler<OnTouchStateChangedEvenArgs> OnTouchStateChanged;
    public class OnTouchStateChangedEvenArgs : EventArgs
    {
        public TouchState touchState;
    }

    private TouchState touchState;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        if (Screen.height > Screen.width)
        {
            SetTouchState(TouchState.ArrowButton);
        }
        else
        {
            SetTouchState(TouchState.PC);
        }


    }


    public void SetTouchState(TouchState touchState)
    {
        this.touchState = touchState;
        OnTouchStateChanged?.Invoke(this, new OnTouchStateChangedEvenArgs
        {
            touchState = touchState
        });
    }

    public void NextTouchState()
    {
        switch (touchState)
        {
            case TouchState.PC:
                SetTouchState(TouchState.ArrowButton);
                break;

            case TouchState.ArrowButton:
                SetTouchState(TouchState.joystick);
                break;

            case TouchState.joystick:
                SetTouchState(TouchState.PC);
                break;
        }
    }

    public TouchState GetTouchState()
    {
        return touchState;
    }





}
