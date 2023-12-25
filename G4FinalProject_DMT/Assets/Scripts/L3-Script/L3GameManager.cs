using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject terminateButton;
    public GameObject continueButton;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ExitLevel();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        terminateButton.SetActive(false);
        continueButton.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        continueButton.SetActive(false);
        terminateButton.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
