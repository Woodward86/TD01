using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //settings
    public GameObject pickupEffect;
    public float multiplier = 1f;
    public float duration = 5f;

    //instance created by power up
    protected GameObject toDestroy;

}
