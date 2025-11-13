using UnityEngine;

public class EarthOrbit : MonoBehaviour
{
    public Transform sunTransform;

    public float rotationSpeed = 50f;

    public float orbitSpeed = 10f;

    public Vector3 selfAxis = Vector3.up;
    public Vector3 orbitAxis = Vector3.up;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(23.5f, 0f, 0f);
    }

    private void Update()
    {
        if (sunTransform == null)
        {
            Debug.LogWarning("Cant find Sun transform");
            return;
        }

        transform.Rotate(selfAxis, rotationSpeed * Time.deltaTime, Space.Self);

        transform.RotateAround(sunTransform.position, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}
