using UnityEngine;
using System.Collections;

public class CharacterJump : MonoBehaviour
{
    private CharacterController _charController;

    [SerializeField]private float _jumpHeight;
    [SerializeField]private int _maxJumps;
    private float _gravity = 20;
    private int _jumpCount;
    private bool _pressedJump;
    private Vector3 _moveDir = Vector3.zero;

    void Start()
    {
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
                _moveDir.y = _jumpHeight;
                _charController.Move(_moveDir * Time.deltaTime);
                _jumpCount++;
                
            }
        }
    }

    public void ResetJumpCount()
    {
        _jumpCount = 0;
    }
}
