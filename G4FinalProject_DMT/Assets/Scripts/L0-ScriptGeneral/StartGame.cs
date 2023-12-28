using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource click;

    public void StartMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Play()
    {
        click.Play();
        Invoke("StartMenu", 0.5f);
    }

    public void clickSound()
    {
        click.Play();
    }

} 