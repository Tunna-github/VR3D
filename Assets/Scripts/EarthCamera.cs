using System.Runtime.CompilerServices;
using UnityEngine;

public class EarthCamera : MonoBehaviour
{
    public Transform earthPosition;
    public Transform earthCameraPosition;

    private Vector3 offset;
    
    private void Start()
    {
        offset = earthCameraPosition.position - earthPosition.position;
    }

    private void LateUpdate()
    {
        earthCameraPosition.position = earthPosition.position + offset;
    }

}
