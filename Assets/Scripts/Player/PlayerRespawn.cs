using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]private Transform[] _respawnPoint;
    [SerializeField]private float _respawnTimer;
    private AnimStateHandler _animator;
    private PlayerHealth _healthController;
    private bool _isAlive;


    void Start()
    {
        _healthController = GetComponent<PlayerHealth>();
        _animator = GetComponent<AnimStateHandler>();
        _isAlive = true;
    }

    public IEnumerator Respawn()
    {
        _isAlive = false;
        _healthController.ChangeHealth(-1);
        _animator.AnimState(2);
        yield return new WaitForSeconds(_respawnTimer);
        _animator.AnimState(0);
        transform.position = _respawnPoint[Random.Range(0, _respawnPoint.Length - 1)].position; //Gets a random spawn point from the array and lets player respawn there
        _isAlive = true;
    }

    public bool IsAlive()
    {
        return _isAlive;
    }
}
