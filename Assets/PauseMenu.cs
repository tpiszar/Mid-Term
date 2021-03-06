using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject resume;
    public GameObject quit;
    public GameObject newGame;
    public GameObject player;
    bool isPaused = false;
    bool end = false;
    public AudioSource clickSnd;
    public AudioSource music;

    private void Start()
    {
        resume.SetActive(false);
        quit.SetActive(false);
        newGame.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && !end)
        {
            TogglePause();
        }
        if (!end && player == null)//lava.transform.position.y >= camera.transform.position.y - 1)
        {
            end = true;
            Time.timeScale = 0.0f;
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.34509803921f);
            newGame.SetActive(true);
            quit.SetActive(true);
            music.Stop();
        }
    }

    public void TogglePause()
    {
        clickSnd.Play();
        if (isPaused)
        {
            //unpause
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            isPaused = false;
            Time.timeScale = 1.0f;
            resume.SetActive(false);
            quit.SetActive(false);
            music.UnPause();
        }
        else
        {
            //pause
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0.34509803921f);
            isPaused = true;
            Time.timeScale = 0.0f;
            resume.SetActive(true);
            quit.SetActive(true);
            music.Pause();
        }
    }

    public void OnApplicationQuit()
    {
        clickSnd.Play();
        Application.Quit();
    }

    public void Restart(string name)
    {
        clickSnd.Play();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }
}
