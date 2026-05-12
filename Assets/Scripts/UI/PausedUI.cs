using System;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PausedUI : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button joystickToggleButton;
    [SerializeField] TextMeshProUGUI joystickToggleButtonText;



    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.UnPauseGame();
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            SceneLoader.LoadScene(SceneLoader.Scene.MainMenuScene);
        });

        joystickToggleButton.onClick.AddListener(() =>
        {
            SettingManager.Instance.NextTouchState();
        });
    }


    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
        SettingManager.Instance.OnTouchStateChanged += SettingManager_OnTouchStateChanged;
        ApplyTouchState(SettingManager.Instance.GetTouchState());

        Hide();
    }


    private void SettingManager_OnTouchStateChanged(object sender, SettingManager.OnTouchStateChangedEvenArgs e)
    {
        ApplyTouchState(e.touchState);
    }

    private void ApplyTouchState(SettingManager.TouchState touchState)
    {

        switch (touchState)
        {
            case SettingManager.TouchState.PC:
                joystickToggleButtonText.text = "方向按钮";
                break;

            case SettingManager.TouchState.ArrowButton:
                joystickToggleButtonText.text = "圆盘控制";
                break;

            case SettingManager.TouchState.joystick:
                joystickToggleButtonText.text = "隐藏触控";
                break;
        }
    }

    private void GameManager_OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnGamePaused(object sender, EventArgs e)
    {
        Show();
    }


    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
