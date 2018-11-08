using UnityEngine;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerController : MonoBehaviour
{
    //setup
    protected Rigidbody rb;
    protected Collider coll;
    protected Inventory inventory;
    protected PlayerStats stats;

    //input type
    public bool useController;

    //movement
    private Vector3 velocity = Vector3.zero;

    //aim
    public Transform fd;
    public Transform pg;

    //interaction collider
    public Collider interactColl;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        inventory = GetComponent<Inventory>();
        stats = GetComponent<PlayerStats>();

        interactColl.enabled = false;
    }

    //TODO: need to refactor this
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
        TwinStick();
        //AllLeftStick(xMove, zMove);

        // Weapon attack
        if (inventory.currentEquipment[4] != null)
        {
            //TODO: This Find() call needs to replaced with something more performant
            GameObject weaponGO = GameObject.Find(inventory.currentEquipment[4].name);
            Weapon weapon = weaponGO.GetComponent<Weapon>();

            if (Input.GetButtonDown("Fire1"))
            {
                // Do ranged attack
                if (inventory.currentEquipment[4].isRanged)
                {
                    weapon.Shoot();
                }
                // Do melee attack
                else
                {
                    weapon.Strike();
                }
            }
        }


        //TODO: All the KeyCodes will need to be replaced with variables to be ready for multi player
        if (Input.GetKey(KeyCode.E))
        {
            Interact();
        }
        else if (!Input.GetKey(KeyCode.E))
        {
            interactColl.enabled = false;
        }
        
        //use consumables
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
    }


    void Interact()
    {
        interactColl.enabled = true;
    }


    void TwinStick()
    {
        if (!useController)
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

                fd.transform.LookAt(new Vector3(pointToLook.x, fd.transform.position.y, pointToLook.z));
                pg.transform.LookAt(new Vector3(pointToLook.x, pg.transform.position.y, pointToLook.z));
            }
        }
        //TODO: This all needs to be fine tuned a lot, right now the right control still feels bad, and to snappy
        else
        {
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * Input.GetAxisRaw("RVertical");
            if (playerDirection.sqrMagnitude > 0.0f)
            {
                fd.transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                pg.transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
        }

    }


    void AllLeftStick(float xMove, float zMove)
    {
        Vector3 playerDirection = Vector3.right * xMove + Vector3.forward * zMove;
        if (playerDirection.sqrMagnitude > 0.0f)
        {
            fd.transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }

        //TODO: The condition between -45 and 45 doesn't seem to work quite right
        if (fd.transform.rotation.y >= -45f && fd.transform.rotation.eulerAngles.y <= 45f)
        {
            pg.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (fd.transform.rotation.eulerAngles.y >= 45f && fd.transform.rotation.eulerAngles.y <= 135f)
        {
            pg.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (fd.transform.rotation.eulerAngles.y >= 135f && fd.transform.rotation.eulerAngles.y <= 225f)
        {
            pg.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (fd.transform.rotation.eulerAngles.y >= 225f && fd.transform.rotation.eulerAngles.y <= 315f)
        {
            pg.rotation = Quaternion.Euler(0, 270, 0);
        }
    }
}
