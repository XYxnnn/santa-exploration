using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayGame : MonoBehaviour
{
    public AudioSource click;

    public void Replay()
    {
        SceneManager.LoadScene("1-StartGame");
    }

    public void Play()
    {
        click.Play();
        Invoke("Replay", 0.5f);
    }

    public void clickSound()
    {
        click.Play();
    }
}
