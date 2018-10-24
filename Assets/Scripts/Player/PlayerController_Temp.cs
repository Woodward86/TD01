using UnityEngine;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerController_Temp : MonoBehaviour
{
    //setup
    protected Rigidbody rb;
    protected Collider coll;
    protected Inventory inventory;
    protected PlayerStats stats;

    //camera setup
    Transform mainCamera;
    public float cameraSmooth = 1.0f;
    public Vector3 cameraOffset;
    public Quaternion cameraRotation;

    //movement
    private Vector3 velocity = Vector3.zero;

    //aim
    public Transform ld;

    //TODO: Interact collider should probably be replaced with a box collider on the front of the character
    //interaction collider
    public Collider interactColl;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        inventory = GetComponent<Inventory>();
        stats = GetComponent<PlayerStats>();
        mainCamera = Camera.main.transform;

        interactColl.enabled = false;
    }


    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        velocity = (moveHorizontal + moveVertical).normalized * stats.walkSpeed.GetValue();

        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }

        //TODO: Will need to be fixed to work with multiple cameras
        MouseLook();

        //TODO: All the KeyCodes will need to be replaced with variables to be ready for multi player
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        else if (!Input.GetKeyDown(KeyCode.E))
        {
            interactColl.enabled = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory.consumables[0].Use(stats);
            inventory.Remove(inventory.consumables[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory.consumables[1].Use(stats);
            inventory.Remove(inventory.consumables[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventory.consumables[2].Use(stats);
            inventory.Remove(inventory.consumables[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            inventory.consumables[3].Use(stats);
            inventory.Remove(inventory.consumables[3]);
        }

        MoveCamera();
    }

    //TODO: will need to be fixed to work with multiple cameras
    void MoveCamera()
    {
        mainCamera.position += (transform.position + cameraOffset - mainCamera.position) * cameraSmooth * Time.deltaTime;
        mainCamera.transform.rotation = cameraRotation;
    }


    void Interact()
    {
        interactColl.enabled = true;
    }

    //TODO: decide which of these mouse looks to use
    void MouseLook()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            ld.transform.LookAt(new Vector3(pointToLook.x, ld.transform.position.y, pointToLook.z));
        }

        // below is the direct rotation of the character
        //if (groundPlane.Raycast(cameraRay, out rayLength))
        //{
        //    Vector3 pointToLook = cameraRay.GetPoint(rayLength) - transform.position;
        //    pointToLook.y = 0f;
        //    Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

        //    Quaternion newRotation = Quaternion.LookRotation(pointToLook);

        //    rb.MoveRotation(newRotation);
        //}
    }

}
