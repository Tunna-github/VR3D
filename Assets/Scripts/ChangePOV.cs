using UnityEngine;

public class ChangePOV : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;


    public Transform earthCamera;
    public Transform xrCamera;
    public Transform xrOrigin;

    private void Start()
    {
        originalPosition = xrOrigin.position;
        originalRotation = xrOrigin.rotation;
    }

    [ContextMenu("Earth POV")]
    public void SwitchToEarthPOV()
    {
        Vector3 cameraOffset = xrCamera.localPosition;

        xrOrigin.position = earthCamera.position; //- earthCamera.rotation * cameraOffset;
        xrOrigin.rotation = earthCamera.rotation;

    }

    [ContextMenu("Original POV")]
    public void SwitchToOriginalPOV()
    {
        xrOrigin.position = originalPosition;
        xrOrigin.rotation = originalRotation;
    }
}
