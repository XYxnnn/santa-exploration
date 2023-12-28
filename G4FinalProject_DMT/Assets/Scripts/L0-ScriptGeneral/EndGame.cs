using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public AudioSource click;

    public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Play()
    {
        click.Play();
        Invoke("OnExitGame", 1.0f);
    }

    public void clickSound()
    {
        click.Play();
    }

}