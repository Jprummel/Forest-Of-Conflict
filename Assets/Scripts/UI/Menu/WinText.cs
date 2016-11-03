using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinText : MonoBehaviour {

    [SerializeField]private float       _endtimer;
                    private GameObject  _player1;
                    private GameObject  _player2;
                    private Text        _winText;
    
    

	// Use this for initialization
	void Start () {
        _player1 = GameObject.Find("Player1");
        _player2 = GameObject.Find("Player2");
        _winText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(!_player1)
        {
            _winText.text = "Player 2 Wins!";
            StartCoroutine(EndGame());
        }else if(!_player2)
        {
            _winText.text = "Player 1 Wins!";
            StartCoroutine(EndGame());
        }
	}

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(_endtimer);
        Application.LoadLevel("EndGame");
    }
}
