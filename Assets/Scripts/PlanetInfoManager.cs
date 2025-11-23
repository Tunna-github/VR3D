using UnityEngine;
using TMPro;

public class PlanetInfoManager : MonoBehaviour
{
    // Tham chiếu đến các đối tượng Text trong InfoPanel (Kéo thả từ Inspector)
    public TextMeshProUGUI planetNameText;
    public TextMeshProUGUI descriptionText;

    // Hàm công khai để nhận dữ liệu từ PlanetButtonData
    public void UpdatePlanetInfo(string name, string description)
    {
        if (planetNameText != null)
        {
            planetNameText.text = name;
        }

        if (descriptionText != null)
        {
            // Thay thế \n bằng ký tự xuống dòng thực tế
            descriptionText.text = description.Replace("\\n", "\n");
        }
    }
}