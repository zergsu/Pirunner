using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitvity = 150f;

    public Transform orientaion;

    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        if(!GameManager.instance.gamePaused)
		{
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitvity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvity * Time.deltaTime;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        }

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);//rotate cam 
        orientaion.rotation = Quaternion.Euler(0, yRotation, 0);// rotate orientaion
    }
}
