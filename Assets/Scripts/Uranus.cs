using UnityEngine;

public class Uranus : MonoBehaviour
{
    public Transform sunTransform;

    public float rotationSpeed = -60f;  
    public float orbitSpeed = 6.8f;

    public Vector3 selfAxis = Vector3.up;
    public Vector3 orbitAxis = Vector3.up;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(97f, 0f, 0f);
    }

    private void Update()
    {
        if (sunTransform == null) return;

        transform.Rotate(selfAxis, rotationSpeed * Time.deltaTime, Space.Self);
        transform.RotateAround(sunTransform.position, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}