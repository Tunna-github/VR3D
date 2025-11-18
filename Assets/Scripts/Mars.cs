using UnityEngine;

public class Mars : MonoBehaviour
{
    public Transform sunTransform;

    public float rotationSpeed = 40f;
    public float orbitSpeed = 24f;

    public Vector3 selfAxis = Vector3.up;
    public Vector3 orbitAxis = Vector3.up;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(25.2f, 0f, 0f);
    }

    private void Update()
    {
        if (sunTransform == null) return;

        transform.Rotate(selfAxis, rotationSpeed * Time.deltaTime, Space.Self);
        transform.RotateAround(sunTransform.position, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}