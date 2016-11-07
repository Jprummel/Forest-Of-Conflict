using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]private int             _startHealth;
                    private int             _currentHealth;
                    private PlayerInputs    _playerInputs;
                    public  Text            livesText;

    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

	void Start () 
    {
        _playerInputs   = GetComponent<PlayerInputs>();//Gets the player number
        _currentHealth  = _startHealth; //Sets players currenthealth to his max health at the start
	}
	
	void Update () {
        StartCoroutine(Death());
	}

    public void ChangeHealth(int value)
    {
        _currentHealth += value;
    }
    public int GetHealth()
    {
        return _currentHealth;
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
