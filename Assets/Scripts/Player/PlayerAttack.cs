using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    //Editor Values
    private AnimationController         _animator;              //Import Animator class
    private CharacterController         _charController;
    private CameraController            _cam;
    private bool                        _isAttacking;           //Checks if player is Attacking
    private bool                        _pressedAttack;
    private float                       _attackAnimTime = 1.2f; //Length of Attack Animation
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
        yield return new WaitForSeconds(_attackAnimTime);
        _animator.SetAnimBool("IsAttacking",false);
        _isAttacking = false;
    }

    public bool Attacking()
    {
        return _isAttacking;
    }
}
