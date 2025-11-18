using UnityEngine;

public class Saturn : MonoBehaviour
{
    public Transform sunTransform;

    public float rotationSpeed = 100f;
    public float orbitSpeed = 9f;

    public Vector3 selfAxis = Vector3.up;
    public Vector3 orbitAxis = Vector3.up;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(26.7f, 0f, 0f);
    }

    private void Update()
    {
        if (sunTransform == null) return;

        transform.Rotate(selfAxis, rotationSpeed * Time.deltaTime, Space.Self);
        transform.RotateAround(sunTransform.position, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}