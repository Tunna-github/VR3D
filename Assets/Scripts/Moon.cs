using UnityEngine;

public class Moon : MonoBehaviour {
    public Transform earthTransform;

    public float rotationSpeed = 10f;      // Moon's self rotation (slow)
    public float orbitSpeed = 13.0f;       // Moon orbit speed around Earth

    public Vector3 selfAxis = Vector3.up;
    public Vector3 orbitAxis = Vector3.up;

    private void Start() {
        // Moon rotation tilt (approx 6.7 degrees)
        transform.rotation = Quaternion.Euler(6.7f, 0f, 0f);
    }

    private void Update() {
        if (earthTransform == null) {
            Debug.LogWarning("Cant find Earth transform");
            return;
        }

        // Rotate on its axis
        transform.Rotate(selfAxis, rotationSpeed * Time.deltaTime, Space.Self);

        // Orbit around Earth
        transform.RotateAround(earthTransform.position, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}
