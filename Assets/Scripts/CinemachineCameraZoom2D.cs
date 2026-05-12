using Unity.Cinemachine;
using UnityEngine;

public class CinemachineCameraZoom2D : MonoBehaviour
{
    public static CinemachineCameraZoom2D Instance { get; private set; }

    [SerializeField] private const float PC_NORMAL_ORTHOGRAPHIC_SIZE = 10f;
    [SerializeField] private const float PHONE_NORMAL_ORTHOGRAPHIC_SIZE = 20f;
    [SerializeField] private CinemachineCamera cinemachineCamera;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    [SerializeField] private float targetOrthographicSize = 10f;

    private void Update()
    {
        float zoomSpeed = 2f;
        cinemachineCamera.Lens.OrthographicSize = Mathf.Lerp(cinemachineCamera.Lens.OrthographicSize, targetOrthographicSize, zoomSpeed * Time.deltaTime);
    }

    public void SetTargetOrthographicSize(float targetOrthographicSize)
    {
        this.targetOrthographicSize = targetOrthographicSize;
    }


    public void SetNormalOrthographicSize()
    {
        if (Screen.width > Screen.height)
        {
            SetTargetOrthographicSize(PC_NORMAL_ORTHOGRAPHIC_SIZE);
        }
        else
        {
            SetTargetOrthographicSize(PHONE_NORMAL_ORTHOGRAPHIC_SIZE);

        }
    }


}
