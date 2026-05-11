using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private Transform visualTransform;
    [SerializeField] private float bobHeight = 0.12f;
    [SerializeField] private float bobSpeed = 3f;
    [SerializeField] private float flipSpeed = 5f;
    [SerializeField] private float minFlipScaleX = 0.35f;

    private Vector3 visualStartLocalPosition;
    private Vector3 visualStartLocalScale;
    private float animationTimeOffset;

    private void Awake()
    {
        if (visualTransform == null)
        {
            return;
        }

        visualStartLocalPosition = visualTransform.localPosition;
        visualStartLocalScale = visualTransform.localScale;
        animationTimeOffset = Random.Range(0f, 10f);
    }

    private void Update()
    {
        if (visualTransform == null)
        {
            return;
        }

        float animationTime = Time.time + animationTimeOffset;
        float bobOffset = Mathf.Sin(animationTime * bobSpeed) * bobHeight;
        visualTransform.localPosition = visualStartLocalPosition + Vector3.up * bobOffset;

        float flipProgress = (Mathf.Sin(animationTime * flipSpeed) + 1f) * 0.5f;
        float flipScaleX = Mathf.Lerp(minFlipScaleX, 1f, flipProgress);
        visualTransform.localScale = new Vector3(
            visualStartLocalScale.x * flipScaleX,
            visualStartLocalScale.y,
            visualStartLocalScale.z
        );
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
