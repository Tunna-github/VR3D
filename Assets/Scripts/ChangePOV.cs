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

    [SerializeField] bool SunPOV = false;
    [SerializeField] bool MercuryPOV = false;
    [SerializeField] bool VenusPOV = false;
    [SerializeField] bool EarthPOV = false;
    [SerializeField] bool MoonPOV = false;
    [SerializeField] bool MarsPOV = false;
    [SerializeField] bool JupiterPOV = false;
    [SerializeField] bool SaturnPOV = false;
    [SerializeField] bool UranusPOV = false;
    [SerializeField] bool NeptunePOV = false;
    [SerializeField] bool OriginalCamera = false;


    private void OnValidate() {
        if (SunPOV) {
            ChangeToSunPOV();
            SunPOV = false;
        }
        else if (MercuryPOV) {
            ChangeToMercuryPOV();
            MercuryPOV = false;
        }
        else if (VenusPOV) {
            ChangeToVenusPOV();
            VenusPOV = false;
        }
        else if (EarthPOV) {
            ChangeToEarthPOV();
            EarthPOV = false;
        }
        else if (MoonPOV) {
            ChangeToMoonPOV();
            MoonPOV = false;
        }
        else if (MarsPOV) {
            ChangeToMarsPOV();
            MarsPOV = false;
        }
        else if (JupiterPOV) {
            ChangeToJupiterPOV();
            JupiterPOV = false;
        }
        else if (SaturnPOV) {
            ChangeToSaturnPOV();
            SaturnPOV = false;
        }
        else if (UranusPOV) {
            ChangeToUranusPOV();
            UranusPOV = false;
        }
        else if (NeptunePOV) {
            ChangeToNeptunePOV();
            NeptunePOV = false;
        }
        else if (OriginalCamera) {
            ChangeToOriginalPOV();
            OriginalCamera = false;
        }
    }

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
                xrOrigin.rotation = sunCamera.rotation;
                break;
            case "Mercury":
                xrOrigin.position = mercuryCamera.position;
                xrOrigin.rotation = mercuryCamera.rotation;
                break;
            case "Venus":
                xrOrigin.position = venusCamera.position;
                xrOrigin.rotation = venusCamera.rotation;
                break;
            case "Earth":
                xrOrigin.position = earthCamera.position;
                xrOrigin.rotation = earthCamera.rotation;
                break;
            case "Moon":
                xrOrigin.position = moonCamera.position;
                xrOrigin.rotation = moonCamera.rotation;
                break;
            case "Mars":
                xrOrigin.position = marsCamera.position;
                xrOrigin.rotation = marsCamera.rotation;
                break;
            case "Jupiter":
                xrOrigin.position = jupiterCamera.position;
                xrOrigin.rotation = jupiterCamera.rotation;
                break;
            case "Saturn":
                xrOrigin.position = saturnCamera.position;
                xrOrigin.rotation = saturnCamera.rotation;
                break;
            case "Uranus":
                xrOrigin.position = uranusCamera.position;
                xrOrigin.rotation = uranusCamera.rotation;
                break;
            case "Neptune":
                xrOrigin.position = neptuneCamera.position;
                xrOrigin.rotation = neptuneCamera.rotation;
                break;
            case "Origin":
                xrOrigin.position = originalCamera.position;
                xrOrigin.rotation = originalCamera.rotation;
                break;
            default:
                Debug.Log("Something went wrong!");
                break;
        }
    }
}
