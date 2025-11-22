using UnityEngine;

public class HUBScript : MonoBehaviour
{
    public static HUBScript Instance { get; private set; }

    public Transform xrOrigin;
    public Vector3 offset = new Vector3(-50f, 0f, 0.5f);

    private bool isFollowing = false;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void LateUpdate() {
        if (!isFollowing) {
            transform.position = xrOrigin.position + offset;
        }
    }

    public void RotateWhenFollowing() {
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    public void RotateWhenNotFollowing() {
        transform.rotation = Quaternion.Euler(0f, -90f, -90f);
    }
}
