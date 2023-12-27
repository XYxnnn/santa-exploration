using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel3 : MonoBehaviour
{
    [SerializeField] private float currentLoadTime;
    private float loadTime;
    public Image loadingBar;

    // Start is called before the first frame update
    void Start()
    {
        loadTime = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLoadTime < loadTime)
        {
            currentLoadTime += Time.deltaTime;
            loadingBar.fillAmount = currentLoadTime / loadTime;
        }
        else
        {
            StartCoroutine(enteringGame());
        }
    }

    IEnumerator enteringGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("4-Level3-xx", LoadSceneMode.Single);
    }
}
