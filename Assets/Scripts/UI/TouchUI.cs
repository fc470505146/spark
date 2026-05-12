using System;
using UnityEngine;

public class TouchUI : MonoBehaviour
{
    [SerializeField] GameObject joystickGameobject;
    [SerializeField] GameObject arrowButtonGameObject;

    private void Start()
    {
        SettingManager.Instance.OnTouchStateChanged += SettingManager_OnTouchStateChanged;

        ApplyTouchState(SettingManager.Instance.GetTouchState());
    }

    private void SettingManager_OnTouchStateChanged(object sender, SettingManager.OnTouchStateChangedEvenArgs e)
    {
        ApplyTouchState(e.touchState);
    }
    private void ApplyTouchState(SettingManager.TouchState touchState)
    {

        switch (touchState)
        {
            case SettingManager.TouchState.ArrowButton:
                SetActiveArrowButton(true);
                SetActiveJoyStick(false);
                break;
            case SettingManager.TouchState.joystick:
                SetActiveArrowButton(false);
                SetActiveJoyStick(true);
                break;
            default:
                SetActiveArrowButton(false);
                SetActiveJoyStick(false);
                break;
        }
    }

    public void SetActiveJoyStick(bool active)
    {
        joystickGameobject.SetActive(active);
    }

    public void SetActiveArrowButton(bool active)
    {
        arrowButtonGameObject.SetActive(active);
    }
}
