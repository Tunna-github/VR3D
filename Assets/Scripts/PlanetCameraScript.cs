using System.Collections.Generic;
using UnityEngine;

public class PlanetCameraScript : MonoBehaviour
{
    private string planetName;

    private Transform followPlanet;
    private Transform currentCamera;

    private Vector3 offset;

    private void Awake() {

        planetName = this.gameObject.name.Substring(0, this.gameObject.name.Length - 6).Trim();
        Debug.Log("Planet Name: " + planetName);

        followPlanet = GameObject.Find(planetName).transform;
        currentCamera = this.transform;

        offset = currentCamera.position - followPlanet.position;
    }

    private void Update() {
        currentCamera.position = followPlanet.position + offset;
    }
}
