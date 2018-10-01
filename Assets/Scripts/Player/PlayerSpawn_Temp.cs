using UnityEngine;

public class PlayerSpawn_Temp : MonoBehaviour
{

    public GameObject player;

    private bool isStarted = false;

    private void Start()
    {
        isStarted = true;
        Invoke("PlayerSpawn", .11f);
    }

    private void PlayerSpawn()
    {
        if(isStarted)
        {
            Instantiate(player, transform.position, Quaternion.identity);
        }
    }

}
