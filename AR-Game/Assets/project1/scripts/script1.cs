using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class script1 : MonoBehaviour
{
    public GameObject jumpUp;
    public int life;
    public Text lifeText;

    void Start()
    {
        // Initialize the UI Text with the initial life value
        UpdateLifeUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Debug.Log("End Game");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "object")
        {
            Debug.Log("Object hit");
            life--;
            UpdateLifeUI(); // Update the UI Text after decrementing life
        }
    }

    // Function to update the UI Text with the remaining life
    void UpdateLifeUI()
    {
        lifeText.text = "Life: " + life;
    }
}
