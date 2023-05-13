using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform target;
    public Camera mainCamera;
    [Range(0.1f, 5f)]
    public float mouseRotateSpeed = 0.8f;
    [Range(0.01f, 100)]
    public float slerpValue = 0.25f;

    private Quaternion cameraRot; 
    private float distanceBetweenCameraAndTarget;

    private float minXRotAngle = 10; 
    private float maxXRotAngle = 80; 

    private float rotX;
    private float rotY; 

    void Start()
    {
        distanceBetweenCameraAndTarget = Vector3.Distance(mainCamera.transform.position, target.position);
    }

    private void Update()
    {
        rotX += -Input.GetAxis("Mouse Y") * mouseRotateSpeed; 
        rotY += Input.GetAxis("Mouse X") * mouseRotateSpeed;

        if (rotX < minXRotAngle)
        {
            rotX = minXRotAngle;
        }
        else if (rotX > maxXRotAngle)
        {
            rotX = maxXRotAngle;
        }
    }
    private void LateUpdate()
    {

        Vector3 dir = new Vector3(0, 0, -distanceBetweenCameraAndTarget); 

        Quaternion newQ; 

        newQ = Quaternion.Euler(rotX, rotY, 0); 

        cameraRot = Quaternion.Slerp(cameraRot, newQ, slerpValue);  
        mainCamera.transform.position = target.position + cameraRot * dir;
        mainCamera.transform.LookAt(target.position);

    }

    public void SetCamPos()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        mainCamera.transform.position = new Vector3(0, 0, -distanceBetweenCameraAndTarget);
    }
}