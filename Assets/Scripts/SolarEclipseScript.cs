using UnityEngine;

public class SolarEclipseScript : MonoBehaviour
{
    public Transform earth;
    public Transform moon;
    public Transform earthAndMoon;

    [ContextMenu("Solar Eclipse")]
    public void SolarEclipse() {
        earthAndMoon.position = new Vector3(0, 100, -100);
        earthAndMoon.rotation = Quaternion.identity;
        earth.localPosition = new Vector3(0, 0, 0);
        moon.localPosition = new Vector3(70, 0, 0);
    }
}
