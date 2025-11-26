using UnityEngine;

public class Jupiter : MonoBehaviour
{
    public Transform sunTransform;

    public float rotationSpeed = 120f;  
    public float orbitSpeed = 13f;

    public Vector3 selfAxis = Vector3.up;
    public Vector3 orbitAxis = Vector3.up;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(3f, 0f, 0f);
    }

    private void FixedUpdate()
    {
        if (sunTransform == null) return;

        transform.Rotate(selfAxis, rotationSpeed * Time.deltaTime, Space.Self);
        transform.RotateAround(sunTransform.position, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}