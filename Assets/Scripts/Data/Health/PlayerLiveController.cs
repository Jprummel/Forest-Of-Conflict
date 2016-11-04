using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLiveController : MonoBehaviour {
    [SerializeField]private GameObject      _Player;
                    private PlayerHealth    _playerHealth;
                    private int             _lives;
                    private Text            livesText;

	void Start () {
        _playerHealth   = _playerHealth.GetComponent<PlayerHealth>();
        livesText       = GetComponent<Text>();
        UpdateText();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateText();
	}

    public void UpdateText()
    {
        _lives = _playerHealth.GetHealth();
        livesText.text = "Lives : " + _lives.ToString() ;
    }
}
