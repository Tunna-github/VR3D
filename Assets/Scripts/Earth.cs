using UnityEngine;

public class Earth : MonoBehaviour
{
    public Transform sunTransform;

    public float rotationSpeed = 50f;
    public float orbitSpeed = 10f;

    private float originalOrbitalSpeed;
    private float originalRotationSpeed;

    public Vector3 selfAxis = Vector3.up;
    public Vector3 orbitAxis = Vector3.up;

    private void Start()
    {
        originalOrbitalSpeed = orbitSpeed;
        originalRotationSpeed = rotationSpeed;

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

    public void SetOrbitalSpeed(float speed) {
        orbitSpeed = speed;
    }

    public void SetRotationSpeed(float speed) {
        rotationSpeed = speed;
    }

    public void ReturnToOriginalOrbitalSpeed() {
        orbitSpeed = originalOrbitalSpeed;
    }

    public void ReturnToOriginalRotationSpeed() {
        rotationSpeed = originalRotationSpeed;
    }
    public void Reset() {
        ReturnToOriginalOrbitalSpeed();
        ReturnToOriginalRotationSpeed();
        transform.rotation = Quaternion.Euler(23.5f, 0f, 0f);
    }
}