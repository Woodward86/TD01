using UnityEngine;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerStats_Temp))]
public class PlayerController_Temp : MonoBehaviour
{
    //setup
    protected Rigidbody rb;
    protected Collider coll;
    protected PlayerStats_Temp stats;

    //camera setup
    Transform mainCamera;
    public float cameraSmooth = 1.0f;
    public Vector3 cameraOffset;
    public Quaternion cameraRotation;

    //movement
    private Vector3 velocity = Vector3.zero;

    //interaction collider
    public Collider interactColl;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        stats = GetComponent<PlayerStats_Temp>();
        mainCamera = Camera.main.transform;

        interactColl.enabled = false;
    }


    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        velocity = (moveHorizontal + moveVertical).normalized * stats.walkSpeed;

        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Interact();
        }
        else if (!Input.GetKeyDown(KeyCode.X))
        {
            interactColl.enabled = false;
        }
                
        MoveCamera();

    }


    void MoveCamera()
    {
        mainCamera.position += (transform.position + cameraOffset - mainCamera.position) * cameraSmooth * Time.deltaTime;
        mainCamera.transform.rotation = cameraRotation;
    }


    void Interact()
    {
        interactColl.enabled = true;
    }





}
