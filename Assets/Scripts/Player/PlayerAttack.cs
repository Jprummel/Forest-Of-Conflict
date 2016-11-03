using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    private AnimStateHandler    _animator;              //Import Animator class
    private bool                _isAttacking;           //Checks if player is Attacking
    private bool                _pressedAttack;
    private float               _attackAnimTime = 0.5f; //Length of Attack Animation
    private float               _attackCooldown = 1f;   //End timer for cooldown
    private float               _attackTimer = 0f;      //Start timer for cooldown

    void Start()
    {
        _animator = GetComponent<AnimStateHandler>();
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
        _animator.AnimState(1);
        yield return new WaitForSeconds(_attackAnimTime);
        _animator.AnimState(0);
        _isAttacking = false;
    }

    public bool Attacking()
    {
        return _isAttacking;
    }
}
