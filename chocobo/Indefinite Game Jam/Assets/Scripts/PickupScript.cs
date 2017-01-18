using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour {

    public enum PickupTypes { Banana, Poison }
    public PickupTypes pickup;

    public float pickupSpeedModifier;

    void Awake()
    {
        switch(pickup)
        {
            case PickupTypes.Banana:
                pickupSpeedModifier = .1f;
                break;
            case PickupTypes.Poison:
                pickupSpeedModifier = -0.2f;
                break;
            default:
                pickupSpeedModifier = 0;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") { if (other.GetComponent<PlayerMovement>().MovementSpeed > 0.5f) { other.GetComponent<PlayerMovement>().MovementSpeed += pickupSpeedModifier; } }
    }
}
