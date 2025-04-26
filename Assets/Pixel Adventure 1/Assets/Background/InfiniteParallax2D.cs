using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class InfiniteParallax2D : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxSpeed = 0.5f;

    private Material material;
    private Vector2 offset = Vector2.zero;
    private Vector3 lastCameraPosition;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        lastCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        Vector3 delta = cameraTransform.position - lastCameraPosition;
        offset.x += delta.x * parallaxSpeed;
        offset.y += delta.y * parallaxSpeed;

        material.mainTextureOffset = offset;
        lastCameraPosition = cameraTransform.position;
    }
}
