using UnityEngine;

public class HUBScript : MonoBehaviour
{
    public static HUBScript Instance { get; private set; }

    public Transform xrOrigin;
    public Vector3 offset = new Vector3(-100f, 0f, 0f);
    public Vector3 solarEclipseOffset = new Vector3(0f, 0f, 100f);

    private bool isNormal = false;
    private bool isSolarEclipse = false;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void LateUpdate() {
        if (isNormal) {
            transform.position = xrOrigin.position + offset;
        }else if (isSolarEclipse) {
            transform.position = xrOrigin.position + solarEclipseOffset;
        }
    }

    public void RotateWhenFollowing() {
        isNormal = true;
        isSolarEclipse = false;

        transform.rotation = Quaternion.Euler(0f, -90f, 0f);
    }

    public void RotateWhenNotFollowing() {
        isNormal = true;
        isSolarEclipse = false;

        transform.rotation = Quaternion.Euler(0f, -90f, -90f);
    }

    public void RotateWhenSolarEclispe() {
        isNormal = false;
        isSolarEclipse = true;

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void DisableHUB() {
        this.gameObject.SetActive(false);
    }

    public void EnableHUB() {
        this.gameObject.SetActive(true);
    }
}
