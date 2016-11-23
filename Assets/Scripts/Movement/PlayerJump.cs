using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    private CharacterController _charController;
    private AnimationController _animator;
    [SerializeField]private float   _jumpHeight;
    [SerializeField]private int     _maxJumps;
                    private float   _gravity = 20;
                    private int     _jumpCount;
                    private bool    _pressedJump;
                    private Vector3 _moveDir = Vector3.zero;

    void Start()
    {
        _animator = GetComponent<AnimationController>();
        _charController = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        _moveDir.y -= _gravity * Time.deltaTime;
        _charController.Move(_moveDir * Time.deltaTime);
        Jump();
        if (_charController.collisionFlags == CollisionFlags.Below)
        {
            ResetJumpCount();
            _animator.SetAnimBool("IsGrounded", true);
        }
        else
        {
            _animator.SetAnimBool("IsGrounded", false);
        }
    }

    public void Input(bool isJumping)
    {
        _pressedJump = isJumping;
    }

    void Jump()
    {
        if (_jumpCount < _maxJumps) //Checks if the amount of jumps the player made is below the max allowed jumps
        {
            if (_pressedJump)
            {
                StartCoroutine(JumpRoutine());
            }
        }
    }

    IEnumerator JumpRoutine()
    {
        _moveDir.y = _jumpHeight;
        _charController.Move(_moveDir * Time.deltaTime);
        _jumpCount++;
        _animator.SetAnimBool("IsJumping", true);
        _animator.SetAnimInt("JumpState", _jumpCount);
        yield return new WaitForSeconds(1);
        _animator.SetAnimBool("IsJumping", false);
        if (_jumpCount == 2)
        {
            _jumpCount = 3; //Makes sure the animation doesnt loop while double jumping
        }
    }

    public void ResetJumpCount()
    {
        _jumpCount = 0;
    }
}
