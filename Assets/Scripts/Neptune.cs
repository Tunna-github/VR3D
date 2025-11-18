using UnityEngine;

public class Neptune : MonoBehaviour
{
    public Transform sunTransform;

    public float rotationSpeed = 50f;
    public float orbitSpeed = 5.4f;

    public Vector3 selfAxis = Vector3.up;
    public Vector3 orbitAxis = Vector3.up;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(28f, 0f, 0f);
    }

    private void Update()
    {
        if (sunTransform == null) return;

        transform.Rotate(selfAxis, rotationSpeed * Time.deltaTime, Space.Self);
        transform.RotateAround(sunTransform.position, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}