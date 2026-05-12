using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private int pc_zoomedOutOrthographicSize;
    [SerializeField] private int phone_zoomedOutOrthographicSize;
    [SerializeField] private Transform landerStartPositionTransform;
    [SerializeField] private Transform pc_cameraStartTargetTransform;
    [SerializeField] private Transform phone_cameraStartTargetTransform;



    public int GetLevelNumber()
    {
        return levelNumber;
   }

    public Vector3 GetLanderStartPosion()
    {
        return landerStartPositionTransform.position;
    }

    public int GetZoomedOutOrthographicSize()
    {
        if (Screen.width > Screen.height)
        {
            return pc_zoomedOutOrthographicSize;
        }
        else
        {
            return phone_zoomedOutOrthographicSize;
        }
    }


    public Transform GetCameraStartTargetTransform()
    {
        if (Screen.width > Screen.height)
        {

            return pc_cameraStartTargetTransform;
        }
        else
        {
            return phone_cameraStartTargetTransform;
        }

    }
}
