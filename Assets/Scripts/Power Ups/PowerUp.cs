using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //settings
    public GameObject pickupEffect;
    public int multiplier = 1;
    public float duration = 5f;

    //instance created by power up
    protected GameObject toDestroy;

}
