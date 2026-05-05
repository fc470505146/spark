using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statsTextMesh;
    [SerializeField] private GameObject speedLeftArrowGameObject;
    [SerializeField] private GameObject speedRightArrowGameObject;
    [SerializeField] private GameObject speedUpArrowGameObject;
    [SerializeField] private GameObject speedDownArrowGameObject;

    [SerializeField] private Image fuelBarImage;

    private void Update()
    {
        UpdateStatsTextMesh();
    }

    private void UpdateStatsTextMesh()
    {
        float speedDirectionDeadZone = 0.1f;
        speedUpArrowGameObject.SetActive(Lander.Instance.GetSpeedY() >= speedDirectionDeadZone);
        speedDownArrowGameObject.SetActive(Lander.Instance.GetSpeedY() < speedDirectionDeadZone);
        speedRightArrowGameObject.SetActive(Lander.Instance.GetSpeedX() >= speedDirectionDeadZone);
        speedLeftArrowGameObject.SetActive(Lander.Instance.GetSpeedX() < speedDirectionDeadZone);

        fuelBarImage.fillAmount = Lander.Instance.GetFuelAmountNormalized();
        statsTextMesh.text =
        GameManager.Instance.GetScore() + "\n"
        + Mathf.Round(GameManager.Instance.GetTime()) + "\n"
        + Mathf.Abs(Mathf.Round(Lander.Instance.GetSpeedX() * 10f)) + "\n"
        + Mathf.Abs(Mathf.Round(Lander.Instance.GetSpeedY() * 10f)) + "\n";
    }
}
