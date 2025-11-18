using UnityEngine;

public class Venus : MonoBehaviour
{
    public Transform sunTransform;

    public float rotationSpeed = -6f;     
    public float orbitSpeed = 35f;

    public Vector3 selfAxis = Vector3.up;
    public Vector3 orbitAxis = Vector3.up;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(177f, 0f, 0f); 
    }

    private void Update()
    {
        if (sunTransform == null) return;

        transform.Rotate(selfAxis, rotationSpeed * Time.deltaTime, Space.Self);
        transform.RotateAround(sunTransform.position, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}