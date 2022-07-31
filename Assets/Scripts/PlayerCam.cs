using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    [Header("Values")]
    public float mouseSensitivity = 150f;
    float xRotation;
    float yRotation;

    [Header("Refs")]
    public Transform orientaion;

    [Header("Constants")]
    const string MOUSE_X = "Mouse X";
    const string MOUSE_Y = "Mouse Y";


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        float mouseX = Input.GetAxisRaw(MOUSE_X) * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxisRaw(MOUSE_Y) * Time.deltaTime * mouseSensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientaion.rotation = Quaternion.Euler(0, yRotation, 0);
    }

}
