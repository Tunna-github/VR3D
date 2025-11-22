using UnityEngine;

public class HUBScript : MonoBehaviour
{
    public Transform xrOrigin;
    public Vector3 offset = new Vector3(-50f, 0f, 0.5f);

    private void LateUpdate() {
        transform.position = xrOrigin.position + offset;
    }
}
