using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthUI : MonoBehaviour {

    [SerializeField]private Text _healthText;
    [SerializeField]private PlayerHealth _playerHealth;
    [SerializeField]private PlayerInputs _playerNumber; //Gets the input script to get the players number

	void Start () {
        UIDelegates.TextEvent += UpdateLiveText;

        _healthText.text = "Player " + _playerNumber.PlayerNumber + " Lives : " + _playerHealth.CurrentHealth.ToString(); //Starts off showing the players full life count
	}

    void UpdateLiveText()
    {
        _healthText.text = "Player " + _playerNumber.PlayerNumber + " Lives : " + _playerHealth.CurrentHealth.ToString();
    }

    void OnDisable()
    {
        UIDelegates.TextEvent -= UpdateLiveText;
    }
}
