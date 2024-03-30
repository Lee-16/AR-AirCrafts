using UnityEngine;

public class JumpButton : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component of the character

    private bool isJumping = false; // Flag to track if the character is currently jumping

    void Start()
    {
        // Find the Animator component in the scene
        animator = GameObject.FindGameObjectWithTag("Jump").GetComponent<Animator>();
    }

    public void OnJumpButtonPressed()
    {
        // If the character is not already jumping
        if (!isJumping)
        {
            // Set the "isJumping" parameter to true to trigger the jump animation
            animator.SetBool("isJumping", true);
            // Set isJumping flag to true
            isJumping = true;
            // Invoke a method to reset isJumping flag after the jump animation finishes
            Invoke("ResetJumpFlag", 1.0f); // Adjust the delay as needed to match the jump animation duration
        }
    }

    void ResetJumpFlag()
    {
        // Set isJumping flag to false after the jump animation finishes
        animator.SetBool("isJumping", false);
        isJumping = false;
    }
}