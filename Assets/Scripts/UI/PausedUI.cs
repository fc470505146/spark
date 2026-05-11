using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PausedUI : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button joystickToggleButton;
    [SerializeField] GameObject joystickRoot;
    [SerializeField] TextMeshProUGUI joystickToggleButtonText;

    private bool isJoystickVisible = false;


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
            isJoystickVisible = !isJoystickVisible;
            ApplyJoystickVisibility();
        });
    }


    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;

        ApplyJoystickVisibility();
        Hide();
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

    private void ApplyJoystickVisibility()
    {
        joystickRoot.SetActive(isJoystickVisible);
        joystickToggleButtonText.text = isJoystickVisible ? "隐藏手柄" : "显示手柄";
    }
}
