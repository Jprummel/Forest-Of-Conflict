using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField]private GameObject  _bloodSplatter; //Blood Particle
    [SerializeField]private Transform[] _respawnPoint;
    [SerializeField]private float       _respawnTimer;
    private AnimationController         _animator;
    private PlayerHealth                _healthController;
    private bool                        _isAlive;


    void Start()
    {
        _healthController = GetComponent<PlayerHealth>();
        _animator = GetComponent<AnimationController>();
        _isAlive = true;
    }

    public IEnumerator Respawn()
    {
        //Particle effect on death
        GameObject newBloodSplatter = Instantiate(_bloodSplatter, transform.position, Quaternion.identity) as GameObject; //Spawns blood particle
        newBloodSplatter.transform.parent = transform;
        newBloodSplatter.transform.localPosition = new Vector3(0, 1.1f, 0); //Positions blood particle

        _isAlive = false;
        _healthController.ChangeHealth(-1);
        _animator.SetAnimBool("IsDead", true);
        yield return new WaitForSeconds(_respawnTimer);
        _animator.SetAnimBool("IsDead", false);
        transform.position = _respawnPoint[Random.Range(0, _respawnPoint.Length - 1)].position; //Gets a random spawn point from the array and lets player respawn there
        _isAlive = true;
    }

    public bool IsAlive()
    {
        return _isAlive;
    }
}
