using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContol : MonoBehaviour
{
    float mouseSensitivity;
    float verticalRotation = 0f;

    public GameObject crossHair;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseSensitivity = PlayerPrefs.GetFloat("Sensitivity", 100);
        UnityEngine.Debug.Log(mouseSensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        crossHair.transform.position = Input.mousePosition;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        transform.parent.transform.Rotate(Vector3.up * mouseX);
    }
}
