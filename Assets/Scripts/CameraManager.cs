using TMPro;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private TMP_Text cameraText;
    private Camera[] cameras;
    private int currentCameraIndex;

    void Start()
    {
        Camera[] allCameras = FindObjectsByType<Camera>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID);
        cameras = new Camera[allCameras.Length];
        cameras[0] = Camera.main;
        int index = 1;
        foreach (Camera cam in allCameras)
        {
            if (cam != Camera.main)
            {
                cameras[index] = cam;
                index++;
            }
        }
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(cam == Camera.main);
        }

        cameraText.text = "Camera:\n" + Camera.main.name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CycleCamera();
        }
    }

    void CycleCamera()
    {
        cameras[currentCameraIndex].gameObject.SetActive(false);
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;
        cameras[currentCameraIndex].gameObject.SetActive(true);
        cameraText.text = "Camera:\n" + cameras[currentCameraIndex].name;
    }
}
