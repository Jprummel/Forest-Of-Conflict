using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]private int             _startHealth;
                    private int             _currentHealth;
                    private PlayerInputs    _playerInputs;
                    public  Text            livesText;

	void Start () {

        _playerInputs   = GetComponent<PlayerInputs>();
        _currentHealth  = _startHealth; //Sets players currenthealth to his max health at the start
        livesText       = GameObject.Find("Player" + _playerInputs.PlayerNumber + "Lives").GetComponent<Text>();
        livesText.text  = "Player " + _playerInputs.PlayerNumber + " Lives : " + _currentHealth.ToString(); //Starts off showing the players full life count
	}
	
	void Update () {
        StartCoroutine(Death());
	}

    public void ChangeHealth(int value)
    {
        _currentHealth += value;
        UpdateLiveText();
    }
    public int GetHealth()
    {
        return _currentHealth;
    }

    public void UpdateLiveText()
    {
        livesText.text = "Player " + _playerInputs.PlayerNumber + " Lives : " + _currentHealth.ToString();
    }

    IEnumerator Death()
    {
        if(_currentHealth <= 0)
        {
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }
}
