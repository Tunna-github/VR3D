using UnityEngine;

public class DebugDistance : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log($"Hit: {hit.collider.gameObject.name}");
                Debug.Log($"Distance: {Vector3.Distance(Camera.main.transform.position, hit.point)}");
            }
            else
            {
                Debug.Log("No hit - too far or no collider");
            }
        }
    }
}