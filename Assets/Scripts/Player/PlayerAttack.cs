using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    //Editor Values
    [SerializeField]private Transform   _weapon;
    [SerializeField]private float       _thrustForce;         // The force the player goes forward with when attacking
    private AnimationController         _animator;              //Import Animator class
    private CharacterController         _charController;
    private CameraController            _cam;
    private bool                        _isAttacking;           //Checks if player is Attacking
    private bool                        _pressedAttack;
    private float                       _attackAnimTime = 0.5f; //Length of Attack Animation
    private float                       _attackCooldown = 1f;   //End timer for cooldown
    private float                       _attackTimer = 0f;      //Start timer for cooldown
    

    void Start()
    {
        _cam = GetComponent<CameraController>();
        _animator = GetComponent<AnimationController>();
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Debug.Log(_weapon.forward);
        Attack();
        if (_attackTimer < _attackCooldown)     //Cooldown timer for attacking
        {
            _attackTimer += Time.deltaTime;
        }
    }

    public void Input(bool isAttacking)
    {
        _pressedAttack = isAttacking;
    }

    void Attack()
    {
        if (_pressedAttack && _attackTimer >= _attackCooldown)
        {
            _attackTimer = 0f;
            StartCoroutine(AttackTimer());  //Starts timewindow of the animation so enemy can only be hit if the animation is playing
        }
    }

    IEnumerator AttackTimer()
    {
        _isAttacking = true;
        _animator.SetAnimBool("IsAttacking", true);
        CheckForHit();
        yield return new WaitForSeconds(_attackAnimTime);
        _animator.SetAnimBool("IsAttacking",false);
        _isAttacking = false;
    }

    public bool Attacking()
    {
        return _isAttacking;
    }

    void CheckForHit()
    {
        if (_isAttacking)
        {
            Collider[] col = Physics.OverlapSphere(_weapon.position, 5);
            if (col != null)
            {
                for (int i = 0; i < col.Length; i++)
                {
                    if (col[i].tag == "Player" && col[i].gameObject != this.gameObject) //Checks if raycast hits a player but not accidentaly the one that is attacking
                    {
                        PlayerRespawn enemyHit = col[i].GetComponent<PlayerRespawn>();
                        StartCoroutine(enemyHit.Respawn());
                    }
                }
            }
        }        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_weapon.position,5);
    }
}
