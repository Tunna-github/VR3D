using System.Collections.Generic;
using UnityEngine;

public class PlanetCameraScript : MonoBehaviour
{
    private string planetName;

    private Transform followPlanet;
    private Transform cameraPosition;

    private Vector3 offset;

    private void Awake() {
        planetName = this.gameObject.name.Substring(0, this.gameObject.name.Length - 6);
        Debug.Log("Planet Name: " + planetName);
    }
}
