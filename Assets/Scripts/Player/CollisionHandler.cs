using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]private GameObject _weapon;
    private PlayerRespawn   _respawn; //Import Respawn script

    void Start()
    {
        _respawn = GetComponent<PlayerRespawn>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Weapon" && coll.gameObject != _weapon && this.gameObject.tag == "Player")
        {
            PlayerAttack enemy = coll.gameObject.GetComponentInParent<PlayerAttack>();
            if (enemy.Attacking() && _respawn.IsAlive()) //Checks if other player is attacking or not
            {
                Debug.Log("ey");
                StartCoroutine(_respawn.Respawn());
            }
        }
    }
}
