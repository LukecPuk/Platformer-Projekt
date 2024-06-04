using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Activate the Main Menu screen
            mainMenuScreen.SetActive(true);

            // Deactivate the player object (assuming it has a PlayerController script)
            collision.gameObject.SetActive(false);

            // Reset the level after a delay (optional)
            Invoke("ResetLevel", 1.5f); // Change delay as needed
        }
    }

    private void ResetLevel()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
