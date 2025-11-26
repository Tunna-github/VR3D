using UnityEngine;

public class EclipseScript : MonoBehaviour
{
    public Earth earthScript;
    public Moon moonScript;

    public Transform earth;
    public Transform moon;
    public Transform earthAndMoon;

    private void Start() {
        if (earthScript == null || moonScript == null) {
            Debug.LogError("EarthScript or MoonScript reference is missing.");
        }
    }

    [ContextMenu("Solar Eclipse")]
    public void SolarEclipse() {
        Eclipse(70f);
        ChangePOV.Instance.ChangeToSolarEclipsePOV();
        ShadowCasting("Cast");
    }

    [ContextMenu("Lunar Eclipse")]
    public void LunarEclipse() {
        Eclipse(-70f);
        ChangePOV.Instance.ChangeToLunarEclipsePOV();
        ShadowCasting("Cast");
    }

    private void Eclipse(float moonPosition) {
        StopRotationAndOrbital();

        earthAndMoon.position = new Vector3(0, 100, -100);
        earthAndMoon.rotation = Quaternion.identity;

        earth.localRotation = Quaternion.Euler(0, 0, 0);
        earth.localPosition = new Vector3(0, 0, 0);

        moon.localRotation = Quaternion.Euler(0, 0, 0);
        moon.localPosition = new Vector3(moonPosition, 0, 0);
    }

    [ContextMenu("Stop Eclipse")]
    public void StopEclipse() {
        if (earthScript != null) {
            earthScript.Reset();
        }
        if (moonScript != null) {
            moonScript.Reset();
        }

        //HUBScript.Instance.EnableHUB();
        //ChangePOV.Instance.ChangeToEarthPOV();
        ShadowCasting("Uncast");
    }

    private void ShadowCasting(string type) {
        MeshRenderer moonMeshRender = moon.GetComponent<MeshRenderer>();
        MeshRenderer earthMeshRender = earth.GetComponent<MeshRenderer>();

        int layer = type == "Cast" ? 1 : 0;
        moonMeshRender.renderingLayerMask = 1u << layer;
        earthMeshRender.renderingLayerMask = 1u << layer;
    }

    private void StopRotationAndOrbital() {
        earthScript.SetOrbitalSpeed(0);
        earthScript.SetRotationSpeed(0);

        moonScript.SetOrbitalSpeed(0);
        moonScript.SetRotationSpeed(0);
    }
}
