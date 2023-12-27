using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject continueButton;
    public GameObject menuButton;
    public GameObject menu;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NextLevel();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        continueButton.SetActive(true);
        audio.Stop();
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        continueButton.SetActive(false);
        pauseButton.SetActive(true);
        audio.Play();
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
    }

    public void CloseMenu() 
    {
        menu.SetActive(false);
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("1-StartGame");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitLevel()
    {
#if UNITY_EDITOR
UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
