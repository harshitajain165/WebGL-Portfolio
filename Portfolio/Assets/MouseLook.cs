using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour


{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 12f;
   
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("MouseX") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("MouseY") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //clamping is done in order to ensure that the camera field of view does not go beyond a certain range i.e. in this case to ensure that is does not go behind the player
        
        transform.localRotation = Quaternion.Euler(xRotation, transform.rotation.y, transform.rotation.z);

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
