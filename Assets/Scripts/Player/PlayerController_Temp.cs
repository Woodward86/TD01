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

    //TODO: Interact collider should probably be replaced with a box collider on the from of the character
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
