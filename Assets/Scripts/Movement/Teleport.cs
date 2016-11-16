using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    private CameraController _camController;
    private AnimationController _animator;

    [SerializeField]private GameObject  _particle;
    [SerializeField]private float       _teleportDistance;
    [SerializeField]private int         _maxTeleportCharges;
    [SerializeField]private int         _teleportCharges;
    [SerializeField]private float       _rechargeTime;
    [SerializeField]private Transform   _particlePos;
    private CharacterController         _charController;
    private bool                        _isTeleporting;
    private float                       _chargingTime = 0;
    private Vector3                     _teleportDir;
    //Getters and setters
    public int TeleportCharges
    {
        get { return _teleportCharges; }
        set { _teleportCharges = value; }
    }
    public int MaxTeleportCharges
    {
        get { return _maxTeleportCharges; }
        set { _maxTeleportCharges = value; }
    }

    public float ChargingTime
    {
        get { return _chargingTime; }
        set { _chargingTime = value; }
    }

    public float RechargeTime
    {
        get { return _rechargeTime; }
        set { _rechargeTime = value; }
    }

	void Start () {
        _camController = GetComponent<CameraController>();
        _animator = GetComponent<AnimationController>();
        _charController = GetComponent<CharacterController>();
	}

    public void Input(Vector3 teleportDirection, bool teleport)
    {
        _isTeleporting = teleport;
        _teleportDir = teleportDirection;
    }

	void Update () {
        TeleportPlayer();
        RechargeTeleport();
	}

    void TeleportPlayer()
    {
        if (_isTeleporting && _teleportCharges > 0)
        {
            /*_teleportDir = (_teleportDir.x * _camController.CameraRight + _teleportDir.z * _camController.CameraForward).normalized * _teleportDistance * Time.deltaTime;
            Instantiate(_particle, this.transform.position, Quaternion.identity);
            this._charController.Move(_teleportDir);
            _teleportCharges--;
            _isTeleporting = false;*/
            StartCoroutine(TeleportRoutine());
        }
    }

    void RechargeTeleport()
    {
        if (_teleportCharges < _maxTeleportCharges)
        {
            _chargingTime += Time.deltaTime;
            if (_chargingTime > _rechargeTime)
            {
                _chargingTime = 0;
                _teleportCharges++;
            }
        }        
    }

    IEnumerator TeleportRoutine()
    {
        _animator.SetAnimBool("IsTeleporting", true);
        _teleportDir = (_teleportDir.x * _camController.CameraRight + _teleportDir.z * _camController.CameraForward).normalized * _teleportDistance * Time.deltaTime;
        _teleportCharges--;
        Instantiate(_particle, _particlePos.position, Quaternion.identity);
        _charController.Move(_teleportDir);   
        yield return new WaitForSeconds(0.1f);
             
        _isTeleporting = false;
        _animator.SetAnimBool("IsTeleporting", false);
    }
}
