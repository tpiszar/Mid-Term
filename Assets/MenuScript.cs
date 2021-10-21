using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AudioSource clickSnd;
    public void LoadLevel(string name)
    {
        clickSnd.Play();
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        clickSnd.Play();
        Application.Quit();
    }
}