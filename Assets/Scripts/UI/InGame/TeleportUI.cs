using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TeleportUI : MonoBehaviour {

    [SerializeField]private Image       _teleportImage;
    [SerializeField]private Text        _teleportChargeText;
    [SerializeField]private Teleport    _playerTeleportInfo;
	// Use this for initialization
	void Start () {

        UIDelegates.CooldownEvent += ImageFill;
        UIDelegates.TextEvent += ShowTeleportCharges;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ImageFill()
    {        
        if (_playerTeleportInfo.TeleportCharges < _playerTeleportInfo.MaxTeleportCharges)
        {
            Debug.Log("ayy");
            _teleportImage.fillAmount = _playerTeleportInfo.ChargingTime / _playerTeleportInfo.RechargeTime;
        }
    }

    void ShowTeleportCharges()
    {
        _teleportChargeText.text = _playerTeleportInfo.TeleportCharges.ToString();
    }

    void OnDisable()
    {
        UIDelegates.CooldownEvent -= ImageFill;
        UIDelegates.TextEvent -= ShowTeleportCharges;
    }
}
