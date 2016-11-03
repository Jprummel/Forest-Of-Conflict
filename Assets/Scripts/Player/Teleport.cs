using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    private CharacterController _charController;
    [SerializeField]private GameObject _particle;
    [SerializeField]private float _teleportDistance;
    [SerializeField]private int _teleportCharges;
    private bool _isTeleporting;

    private Vector3 _teleportDir;
    
	void Start () {
        _charController = GetComponent<CharacterController>();
	}

    public void Input(Vector3 teleportDirection, bool teleport)
    {
        _isTeleporting = teleport;
        _teleportDir = teleportDirection;
    }

	void Update () {
        TeleportPlayer();
	}

    void TeleportPlayer()
    {
        if (_isTeleporting && _teleportCharges > 0)
        {
            Instantiate(_particle, this.transform.position, Quaternion.identity);
            this._charController.Move(_teleportDir * Time.deltaTime * _teleportDistance);
            _teleportCharges--;
            _isTeleporting = false;
            StartCoroutine(TeleportChargeGain());
        }
    }

    IEnumerator TeleportChargeGain()
    {
        yield return new WaitForSeconds(5);
        _teleportCharges++;
    }
}
