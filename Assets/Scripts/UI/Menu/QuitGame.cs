using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

    [SerializeField]private float _exitTime;

    public void ExitGame()
    {
        StartCoroutine(ExitTimer());
    }

    IEnumerator ExitTimer()
    {
        yield return new WaitForSeconds(_exitTime);
        Application.Quit();
    }
}
