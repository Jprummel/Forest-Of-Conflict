using UnityEngine;
using System.Collections;

//Author : Jordi Prummel

public class LoadScene : MonoBehaviour {
	[SerializeField]private string  _sceneName;
    [SerializeField]private int     _delay;

    public void ChangeLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(_delay);
        Application.LoadLevel(_sceneName);
    }
}