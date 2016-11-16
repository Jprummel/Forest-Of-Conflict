using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

    private Animator _anim;
    //Gets the scripts that require input
    private PlayerRespawn       _playerRespawn;
    private Movement            _playerMovement;
    private CameraController    _cameraController;
    private PlayerAttack        _playerAttack;
    private Teleport            _teleport;
    private PlayerJump          _jump;
    //Assigns a number to the player
    [SerializeField]private int _playerNumber;
    private string              _playerNumberString;

    public int PlayerNumber { get { return _playerNumber; } set { value = _playerNumber; } }
    
    //Vectors for movement and rotation of player and camera
    private Vector3 _moveDirection;
    private Vector3 _rotateDirection;
    //Movement
    private float _moveHorizontal;
    private float _moveVertical;
    private float _rotationHorizontal;
    private float _rotationVertical;
    //Jump & Teleport
    private bool _isJumping;
    private bool _isTeleporting;
    //Attack
    private bool _isAttacking;

	void Start () {
        _playerNumberString = _playerNumber.ToString();         //turns the players assigned number to a string
        _playerRespawn      = GetComponent<PlayerRespawn>();
        _playerMovement     = GetComponent<Movement>();   //Player movement script
        _cameraController   = GetComponent<CameraController>(); //Camera controller script
        _playerAttack       = GetComponent<PlayerAttack>();     //Attack script
        _teleport           = GetComponent<Teleport>();         //Teleporting script
        _jump               = GetComponent<PlayerJump>();             //Jumping script
        _anim = GetComponent<Animator>();
	}
	
	void Update () {
        if (_playerRespawn.IsAlive())
        {
            Inputs();
        }
	}

    void Inputs()
    {
        //Movement and rotation
        _moveHorizontal = Input.GetAxis(InputAxes.leftX + _playerNumberString);
        _moveVertical   = Input.GetAxis(InputAxes.leftY + _playerNumberString);
        _rotationHorizontal = Input.GetAxis(InputAxes.rightX + _playerNumberString);
        _rotationVertical = Input.GetAxis(InputAxes.rightY + _playerNumberString);
        
        //Jumping & Teleporting
        _isJumping = Input.GetButtonDown(InputAxes.a + _playerNumberString);
        _isTeleporting = Input.GetButtonDown(InputAxes.lb + _playerNumberString);
        
        //Attack
        _isAttacking = Input.GetButtonDown(InputAxes.x + _playerNumberString);

        //Sets the movement and roation vectors
        _moveDirection = new Vector3(_moveHorizontal, 0, _moveVertical);
        _rotateDirection = new Vector3(_rotationHorizontal, _rotationVertical, 0);

        //Returning inputs
        _playerMovement.Inputs(_moveDirection);
        _cameraController.Inputs(_rotateDirection);
        _playerAttack.Input(_isAttacking);
        _teleport.Input(_moveDirection,_isTeleporting);
        _jump.Input(_isJumping);

        //AnimationInputs();
    }

    /*void AnimationInputs()
    {
        if (_moveDirection == Vector3.zero)
        {
            _anim.SetInteger("MoveState", 0);
        }

        if (_moveDirection != Vector3.zero)
        {
            _anim.SetInteger("MoveState", 1);
        }
        if (_isJumping)
        {
            _anim.SetBool("IsJumping", true);
        }
        if (_isTeleporting)
        {
            _anim.SetBool("IsTeleporting", true);
        }
        if (_isAttacking)
        {
            _anim.SetBool("IsAttacking", true);
        }
    }*/
}
