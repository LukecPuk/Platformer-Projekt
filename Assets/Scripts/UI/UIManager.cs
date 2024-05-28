using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject mainMenuScreen;

    private void Awake()
    {
        // Ensure only the Main Menu screen is active at the start
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        mainMenuScreen.SetActive(true);

        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle pause screen visibility on Escape key press
            PauseGame(!pauseScreen.activeInHierarchy);
        }
    }

    // Activate Main Menu screen and hide others
    public void ActivateMainMenu()
    {
        mainMenuScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        Time.timeScale = 0; // Pause the game when returning to main menu
    }

    // Hide Main Menu screen to start the game
    public void StartGame()
    {
        mainMenuScreen.SetActive(false);
        Time.timeScale = 1; // Resume normal timescale when starting the game
    }

    // Activate game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        // Play game over sound
        // SoundManager.instance.PlaySound(gameOverSound);
    }

    // Restart the current level
    public void Restart()
    {
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    // Return to Main Menu
    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    // Quit the game
    public void Quit()
    {
        // Quit the application
        Application.Quit();

#if UNITY_EDITOR
        // If running in Unity Editor, stop playing
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // Toggle pause state of the game
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        Time.timeScale = status ? 0 : 1; // Set time scale to 0 when paused, 1 when unpaused
    }

    // Adjust sound volume
    public void SoundVolume()
    {
        // Adjust sound volume
        SoundManager.instance.ChangeSoundVolume(0.05f);
    }

    // Adjust music volume
    public void MusicVolume()
    {
        // Adjust music volume
        SoundManager.instance.ChangeMusicVolume(0.05f);
    }
}
