using UnityEngine;

public class CameraController : MonoBehaviour
{   
    Transform mainCamera;
    public float cameraSmooth = 1.0f;
    public Vector3 cameraOffset;
    public Quaternion cameraRotation;

    //TODO: probably wont work with multiple cameras

    void Update ()
    {
        mainCamera = Camera.main.transform;
        MoveCamera();	
	}


    void MoveCamera()
    {
        mainCamera.position += (transform.position + cameraOffset - mainCamera.position) * cameraSmooth * Time.deltaTime;
        mainCamera.transform.rotation = cameraRotation;
    }
}
