using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ChangePOV : MonoBehaviour
{
    public Transform sunCamera;
    public Transform mercuryCamera;
    public Transform venusCamera;
    public Transform earthCamera;
    public Transform moonCamera;
    public Transform marsCamera;
    public Transform jupiterCamera;
    public Transform saturnCamera;
    public Transform uranusCamera;
    public Transform neptuneCamera;
    public Transform originalCamera;

    //[SerializeField] bool SunPOV = false;
    //[SerializeField] bool MercuryPOV = false;
    //[SerializeField] bool VenusPOV = false;
    //[SerializeField] bool EarthPOV = false;
    //[SerializeField] bool MoonPOV = false;
    //[SerializeField] bool MarsPOV = false;
    //[SerializeField] bool JupiterPOV = false;
    //[SerializeField] bool SaturnPOV = false;
    //[SerializeField] bool UranusPOV = false;
    //[SerializeField] bool NeptunePOV = false;
    //[SerializeField] bool OriginalCamera = true;

    //private List<bool> povBools = new List<bool>();

    public Transform xrOrigin;
    private string currentPOV = "Origin";

    [ContextMenu("Change to Sun POV")]
    public void ChangeToSunPOV() {
        currentPOV = "Sun";
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
            case "Sun":
                xrOrigin.position = sunCamera.position;
                break;
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
                xrOrigin.position = originalCamera.position;
                break;
            default:
                Debug.Log("Something went wrong!");
                break;
        }
    }
}
