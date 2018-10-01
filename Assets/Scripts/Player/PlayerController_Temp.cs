using UnityEngine;

//TODO: set up camera follow to work with cloned Player
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController_Temp : MonoBehaviour
{

    protected Rigidbody rb;
    protected Collider coll;
    Transform mainCamera;
    public float cameraSmooth = 1.0f;
    public Vector3 cameraOffset;

    public float walkSpeed = 6f;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        mainCamera = Camera.main.transform;
    }


    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        velocity = (moveHorizontal + moveVertical).normalized * walkSpeed;

        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }

        MoveCamera();

    }


    void MoveCamera()
    {
        mainCamera.position += (transform.position + cameraOffset - mainCamera.position) * cameraSmooth * Time.deltaTime;
    }





}
