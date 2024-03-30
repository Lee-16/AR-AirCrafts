using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    // Function to reset the game
    public void ResetGame()
    {
        // Load the first scene in the build settings
        SceneManager.LoadScene(0);
    }
}
