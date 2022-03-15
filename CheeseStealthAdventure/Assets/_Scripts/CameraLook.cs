using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angleX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation = xRotation - moveY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //Debug.Log(moveX + " " + moveY);
        playerBody.Rotate(Vector3.up, angleX);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(xRotation, 0, 0), 0.5f);
    }
}
