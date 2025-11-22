using UnityEngine;

public class ChangePOV : MonoBehaviour
{
    public Transform mercuryCamera;
    public Transform venusCamera;
    public Transform earthCamera;
    public Transform moonCamera;
    public Transform marsCamera;
    public Transform jupiterCamera;
    public Transform saturnCamera;
    public Transform uranusCamera;
    public Transform neptuneCamera;

    public Transform xrOrigin;
    private Transform originalPosition;

    private string currentPOV = "Origin";

    private void Start() {
        originalPosition = xrOrigin;
    }

    [ContextMenu("Change to Mercury POV")]
    public void ChangeToMercuryPOV() {
        currentPOV = "Mercury";
    }

    [ContextMenu("Change to Venus POV")]
    public void ChangeToVenusPOV() {
        currentPOV = "Venus";
    }

    [ContextMenu("Change to Earth POV")]
    public void ChangeToEarthPOV() {
        currentPOV = "Earth";
    }

    [ContextMenu("Change to Moon POV")]
    public void ChangeToMoonPOV() {
        currentPOV = "Moon";
    }

    [ContextMenu("Change to Mars POV")]
    public void ChangeToMarsPOV() {
        currentPOV = "Mars";
    }

    [ContextMenu("Change to Jupiter POV")]
    public void ChangeToJupiterPOV() {
        currentPOV = "Jupiter";
    }

    [ContextMenu("Change to Saturn POV")]
    public void ChangeToSaturnPOV() {
        currentPOV = "Saturn";
    }

    [ContextMenu("Change to Uranus POV")]
    public void ChangeToUranusPOV() {
        currentPOV = "Uranus";
    }

    [ContextMenu("Change to Neptune POV")]
    public void ChangeToNeptunePOV() {
        currentPOV = "Neptune";
    }

    [ContextMenu("Change to Original POV")]
    public void ChangeToOriginalPOV() {
        currentPOV = "Origin";
    }

    private void LateUpdate() {
        switch (currentPOV) {
            case "Mercury":
                xrOrigin.position = mercuryCamera.position;
                break;
            case "Venus":
                xrOrigin.position = venusCamera.position;
                break;
            case "Earth":
                xrOrigin.position = earthCamera.position;
                break;
            case "Moon":
                xrOrigin.position = moonCamera.position;
                break;
            case "Mars":
                xrOrigin.position = marsCamera.position;
                break;
            case "Jupiter":
                xrOrigin.position = jupiterCamera.position;
                break;
            case "Saturn":
                xrOrigin.position = saturnCamera.position;
                break;
            case "Uranus":
                xrOrigin.position = uranusCamera.position;
                break;
            case "Neptune":
                xrOrigin.position = neptuneCamera.position;
                break;
            case "Origin":
                xrOrigin.position = originalPosition.position;
                break;
            default:
                Debug.Log("Something went wrong!");
                break;
        }
    }
}
