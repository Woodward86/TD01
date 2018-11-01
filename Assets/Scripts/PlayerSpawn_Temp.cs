using UnityEngine;

public class PlayerSpawn_Temp : MonoBehaviour
{

    public GameObject player;

    private bool isStarted = false;

    private void Start()
    {
        isStarted = true;
        Invoke("PlayerSpawn", .1f);
    }

    private void PlayerSpawn()
    {
        if(isStarted)
        {
            Instantiate(player, player.transform.position, Quaternion.identity);
        }
    }

}
