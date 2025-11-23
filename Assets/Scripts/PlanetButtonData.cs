using UnityEngine;
using UnityEngine.UI; // Cần thiết nếu Button là thành phần UI

public class PlanetButtonData : MonoBehaviour
{
    // Dữ liệu Hành tinh (Điền vào đây cho mỗi hành tinh trong Inspector)
    public string planetName = "Hành Tinh";
    [TextArea] // Cho phép nhập mô tả dài hơn
    public string planetDescription = "Thông tin chi tiết về hành tinh này.";

    // Tham chiếu đến PlanetInfoManager (Kéo đối tượng InfoPanel vào đây)
    public PlanetInfoManager infoManager;

    // Tham chiếu đến logic chuyển camera của bạn (Tùy chọn)
    public GameObject cameraChangeLogic;

    // Hàm được gọi khi Button này được nhấn (Gắn vào OnClick())
    public void OnClickShowInfoAndMove()
    {
        // 1. Cập nhật Bảng thông tin bên phải
        if (infoManager != null)
        {
            infoManager.UpdatePlanetInfo(planetName, planetDescription);
        }

        // 2. Kích hoạt logic chuyển camera (Nếu cần)
        // Nếu logic chuyển camera của bạn nằm trong script khác, bạn cần gọi nó ở đây.
        // Ví dụ: cameraChangeLogic.GetComponent<ChangePOVLogic>().ChangeCameraTo(planetName); 

        // Hoặc bạn có thể gọi logic chuyển camera cũ của bạn từ sự kiện OnClick() của Button.
    }
}