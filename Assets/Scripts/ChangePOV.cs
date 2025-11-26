using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ChangePOV : MonoBehaviour
{
    public static ChangePOV Instance { get; private set; }

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
    public Transform solarEclipseCamera;
    public Transform lunarEclipseCamera;
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

    [Header("Eclipse Scripts")]
    public EclipseScript eclipseScript;


    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnValidate() {
        if (SunPOV) {
            ChangeToSunPOV();
        }
        else if (MercuryPOV) {
            ChangeToMercuryPOV();
        }
        else if (VenusPOV) {
            ChangeToVenusPOV();
        }
        else if (EarthPOV) {
            ChangeToEarthPOV();
        }
        else if (MoonPOV) {
            ChangeToMoonPOV();
        }
        else if (MarsPOV) {
            ChangeToMarsPOV();
        }
        else if (JupiterPOV) {
            ChangeToJupiterPOV();
        }
        else if (SaturnPOV) {
            ChangeToSaturnPOV();
        }
        else if (UranusPOV) {
            ChangeToUranusPOV();
        }
        else if (NeptunePOV) {
            ChangeToNeptunePOV();
        }
        else if (OriginalCamera) {
            ChangeToOriginalPOV();
        }
    }

    public Transform xrOrigin;
    private string currentPOV = "Origin";

    [ContextMenu("Change to Sun POV")]
    public void ChangeToSunPOV() {
        EclipseHandler();

        currentPOV = "Sun";
        xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
        HUBScript.Instance.RotateWhenFollowing();
        SunPOV = false;
    }

    [ContextMenu("Change to Mercury POV")]
    public void ChangeToMercuryPOV() {
        EclipseHandler();

        currentPOV = "Mercury";
        xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
        HUBScript.Instance.RotateWhenFollowing();
        MercuryPOV = false;
    }

    [ContextMenu("Change to Venus POV")]
    public void ChangeToVenusPOV() {
        EclipseHandler();

        currentPOV = "Venus";
        xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
        HUBScript.Instance.RotateWhenFollowing();
        VenusPOV = false;
    }

    [ContextMenu("Change to Earth POV")]
    public void ChangeToEarthPOV() {
        EclipseHandler();

        currentPOV = "Earth";
        xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
        HUBScript.Instance.RotateWhenFollowing();
        EarthPOV = false;
    }

    [ContextMenu("Change to Moon POV")]
    public void ChangeToMoonPOV() {
        EclipseHandler();

        currentPOV = "Moon";
        xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
        HUBScript.Instance.RotateWhenFollowing();
        MoonPOV = false;
    }

    [ContextMenu("Change to Mars POV")]
    public void ChangeToMarsPOV() {
        EclipseHandler();

        currentPOV = "Mars";
        xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
        HUBScript.Instance.RotateWhenFollowing();
        MarsPOV = false;
    }

    [ContextMenu("Change to Jupiter POV")]
    public void ChangeToJupiterPOV() {
        EclipseHandler();

        currentPOV = "Jupiter";
        xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
        HUBScript.Instance.RotateWhenFollowing();
        JupiterPOV = false;
    }

    [ContextMenu("Change to Saturn POV")]
    public void ChangeToSaturnPOV() {
        EclipseHandler();

        currentPOV = "Saturn";
        xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
        HUBScript.Instance.RotateWhenFollowing();
        SaturnPOV = false;
    }

    [ContextMenu("Change to Uranus POV")]
    public void ChangeToUranusPOV() {
        EclipseHandler();

        currentPOV = "Uranus";
        xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
        HUBScript.Instance.RotateWhenFollowing();
        UranusPOV = false;
    }

    [ContextMenu("Change to Neptune POV")]
    public void ChangeToNeptunePOV() {
        EclipseHandler();

        currentPOV = "Neptune";
        xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
        HUBScript.Instance.RotateWhenFollowing();
        NeptunePOV = false;
    }

    [ContextMenu("Change to Original POV")]
    public void ChangeToOriginalPOV() {
        EclipseHandler();
        currentPOV = "Origin";
        xrOrigin.rotation = originalCamera.rotation;
        HUBScript.Instance.RotateWhenNotFollowing();
        OriginalCamera = false;
    }

    public void ChangeToSolarEclipsePOV() {
        currentPOV = "Solar Eclipse";
        xrOrigin.position = solarEclipseCamera.position;
        xrOrigin.rotation = solarEclipseCamera.rotation;
        HUBScript.Instance.RotateWhenSolarEclispe();
    }

    public void ChangeToLunarEclipsePOV() {
        currentPOV = "Lunar Eclipse";
        xrOrigin.position = lunarEclipseCamera.position;
        xrOrigin.rotation = lunarEclipseCamera.rotation;
        HUBScript.Instance.RotateWhenSolarEclispe();
    }

    private void LateUpdate() {
        switch (currentPOV) {
            case "Sun":
                xrOrigin.position = sunCamera.position;
                //xrOrigin.rotation = sunCamera.rotation;
                break;
            case "Mercury":
                xrOrigin.position = mercuryCamera.position;
                //xrOrigin.rotation = xrOrigin.rotation = Quaternion.identity;
                break;
            case "Venus":
                xrOrigin.position = venusCamera.position;
                //xrOrigin.rotation = venusCamera.rotation;
                break;
            case "Earth":
                xrOrigin.position = earthCamera.position;
                //xrOrigin.rotation = earthCamera.rotation;
                break;
            case "Moon":
                xrOrigin.position = moonCamera.position;
                //xrOrigin.rotation = moonCamera.rotation;
                break;
            case "Mars":
                xrOrigin.position = marsCamera.position;
                //xrOrigin.rotation = marsCamera.rotation;
                break;
            case "Jupiter":
                xrOrigin.position = jupiterCamera.position;
                //xrOrigin.rotation = jupiterCamera.rotation;
                break;
            case "Saturn":
                xrOrigin.position = saturnCamera.position;
                //xrOrigin.rotation = saturnCamera.rotation;
                break;
            case "Uranus":
                xrOrigin.position = uranusCamera.position;
                //xrOrigin.rotation = uranusCamera.rotation;
                break;
            case "Neptune":
                xrOrigin.position = neptuneCamera.position;
                //xrOrigin.rotation = neptuneCamera.rotation;
                break;
            case "Origin":
                xrOrigin.position = originalCamera.position;
                //xrOrigin.rotation = originalCamera.rotation;
                break;
            case "Solar Eclipse":
                break;
            case "Lunar Eclipse":
                break;
            default:
                Debug.Log("Something went wrong!");
                break;
        }
    }

    private void EclipseHandler() {
        if (currentPOV == "Solar Eclipse" || currentPOV == "Lunar Eclipse") {
            eclipseScript.StopEclipse();
        }
    }
}
