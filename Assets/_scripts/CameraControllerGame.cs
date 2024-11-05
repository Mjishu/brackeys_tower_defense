using UnityEngine;

public class CameraControllerGame : MonoBehaviour
{
    [Header("Camera movement settings")]
    private bool doMovement = true;
    public float panSpeed = 30f;
    public float panBorderThicknessWidth = Screen.width / 15;
    public float panBorderThicknessHeight = Screen.height / 15;

    [Header("Camera Bounds")]
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minX = -75f;
    public float maxX = 125f;
    public float minZ = -50f;
    public float maxZ = 125f;

    void Update()//!@todo: switch this to new input system
    {
        if (GameManager.gameOver)
        {
            this.enabled = false;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThicknessHeight)
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.forward, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThicknessHeight)
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.back, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThicknessWidth)
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.right, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThicknessWidth)
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.left, Space.World);
        }

        float scrollStrength = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;
        position.y -= scrollStrength * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.z = Mathf.Clamp(position.z, minZ, maxZ);

        transform.position = position;
    }
}
