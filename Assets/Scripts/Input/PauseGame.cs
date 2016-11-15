using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    [SerializeField]private GameObject _pauseMenu;

    public void PauseToggle()
    {
        if (Time.timeScale == 1)
        {

        }
        else if (Time.timeScale == 0)
        {

        }
    }

    public void Pause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
