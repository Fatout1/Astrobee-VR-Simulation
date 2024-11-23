using UnityEngine;
using UnityEngine.InputSystem;

public class VRHandAnimator : MonoBehaviour
{
    public Animator animator; // Drag your hand Animator here
    public InputActionProperty gripAction; // Assign the grip action from the Input Action Asset
    public InputActionProperty triggerAction; // Assign the trigger action

    void Update()
    {
        // Read input values (0 to 1) from the actions
        float gripValue = gripAction.action.ReadValue<float>();
        float triggerValue = triggerAction.action.ReadValue<float>();

        // Set the values in the Animator
        animator.SetFloat("Grip", gripValue);
        animator.SetFloat("Trigger", triggerValue);
    }
}
