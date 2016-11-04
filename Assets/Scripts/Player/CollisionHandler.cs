using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]private GameObject _bloodSplatter; //Blood Particle
    private PlayerRespawn _respawn; //Import Animator script

    void Start()
    {
        _respawn = GetComponent<PlayerRespawn>();
    }

    //void OnCharacterController

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Weapon" && this.tag == "Player")
        {
            PlayerAttack enemySword = coll.gameObject.GetComponentInParent<PlayerAttack>();
            if (enemySword.Attacking()) //Checks if other player is attacking or not
            {
                GameObject newBloodSplatter = Instantiate(_bloodSplatter, transform.position, Quaternion.identity) as GameObject; //Spawns blood particle
                newBloodSplatter.transform.parent = transform;
                newBloodSplatter.transform.localPosition = new Vector3(0, 1.1f, 0); //Positions blood particle
                StartCoroutine(_respawn.Respawn());
            }
        }
    }
}
