using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    [SerializeField] private int zoomedOutOrthographicSize;
    [SerializeField] private Transform landerStartPositionTransform;
    [SerializeField] private Transform cameraStartTargetTransform;



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
        return zoomedOutOrthographicSize;
    }


    public Transform GetCameraStartTargetTransform()
    {
        return cameraStartTargetTransform;
    }
}
