using UnityEngine;
using System.Collections;

public class CharacterJump : MonoBehaviour
{

    private Rigidbody _rb;
    private CharacterController _charController;

    [SerializeField]private float _jumpHeight;
    [SerializeField]private int _maxJumps;
    private float _gravity = 20;
    private int _jumpCount;
    private bool _isJumping;
    private bool _pressedJump;
    private Vector3 _jumpDir = Vector3.zero;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _charController = GetComponent<CharacterController>();
        EventManager.inputAction += Jump;
    }

    void Update()
    {
        _jumpDir.y -= _gravity * Time.deltaTime;
        _charController.Move(_jumpDir * Time.deltaTime);
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
                //_rb.velocity = new Vector3(0, _jumpHeight, 0);
                _jumpDir.y = _jumpHeight;
                _charController.Move(_jumpDir * Time.deltaTime);
                _jumpCount++;
                
            }
        }
    }

    public void ResetJumpCount()
    {
        _jumpCount = 0;
    }
}
