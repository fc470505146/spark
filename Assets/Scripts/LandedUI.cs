using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LandedUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleTextMesh;
    [SerializeField] private TextMeshProUGUI statsTextMesh;
    [SerializeField] private Button nextButton;

    private void Awake()
    {
        nextButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }

    private void Start()
    {
        Lander.Instance.OnLanded += Lander_OnLanded;

        //需要在Start末位处理，不能在Awake中，因为Awake执行在Start前，如果在Awake中禁用了，Start就不会执行
        Hide();
    }

    private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e)
    {
        switch (e.landingType)
        {
            case Lander.LandingType.Success:
                titleTextMesh.text = "成功降落！";
                break;
            default:
                titleTextMesh.text = "<color=#ff0000>撞毁</color>";
                break;
        }
        statsTextMesh.text =
            e.landingSpeed.ToString("F2") + "\n" +
           e.dotVector.ToString("F2") + "\n" +
            "x" + e.scoreMultiplier + "\n" +
            e.score;

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
