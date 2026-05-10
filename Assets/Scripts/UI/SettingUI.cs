using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] Button settingButton;


    private void Awake()
    {
        settingButton.onClick.AddListener(() =>
        {
            GameManager.Instance.PauseUnpauseGame();
        });
    }
}
