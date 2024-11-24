using UnityEngine;

public class HandleMovement : MonoBehaviour
{
    public Rigidbody playerRigidbody;

    public void OnHandleReleased(Vector3 handVelocity)
    {
        // Apply the hand's velocity to the player Rigidbody
        playerRigidbody.AddForce(handVelocity, ForceMode.VelocityChange);
    }
}