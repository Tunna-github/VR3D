using UnityEngine;

public class Moon : MonoBehaviour {
    public Transform earthTransform;

    public float rotationSpeed = 10/2f;
    public float orbitSpeed = 13.0f/2;

    private float originalOrbitalSpeed;
    private float originalRotationSpeed;

    public Vector3 selfAxis = Vector3.up;
    public Vector3 orbitAxis = Vector3.up;

    private void Start() {
        originalOrbitalSpeed = orbitSpeed;
        originalRotationSpeed = rotationSpeed;

        transform.rotation = Quaternion.Euler(6.7f, 0f, 0f);
    }

    private void FixedUpdate() {
        if (earthTransform == null) {
            Debug.LogWarning("Cant find Earth transform");
            return;
        }

        transform.Rotate(selfAxis, rotationSpeed * Time.deltaTime, Space.Self);

        transform.RotateAround(earthTransform.position, orbitAxis, orbitSpeed * Time.deltaTime);
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
        transform.rotation = Quaternion.Euler(6.7f, 0f, 0f);
    }
}
