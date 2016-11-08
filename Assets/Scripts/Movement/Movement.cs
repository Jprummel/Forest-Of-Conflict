using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
    private CharacterController _charController;
    //Speed
    [SerializeField]private float _movementSpeed;
    [SerializeField]private float _turnSpeed;
    //Vectors
    private Vector3 _newForward;
    private Vector3 _moveDir;
    private Quaternion _rotation;
    private CameraController _camController;

    void Start()
    {
        //_rigidBody = GetComponent<Rigidbody>();
        _camController = GetComponent<CameraController>();
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (_moveDir.magnitude > 0)
        {
            Move();
            if (_moveDir.sqrMagnitude > 1)
            {
                _newForward = _newForward.normalized;
            }
        }
    }

    public void Inputs(Vector3 moveDirection)
    {
        _moveDir = moveDirection;
    }

    public void Move()
    {
        _moveDir = (_moveDir.x * _camController.CameraRight + _moveDir.z * _camController.CameraForward).normalized * _movementSpeed * Time.deltaTime;        

        float moveDirX = _moveDir.x >= 0 ? _moveDir.x : -_moveDir.x;
        float moveDirZ = _moveDir.z >= 0 ? _moveDir.z : -_moveDir.z;
        float maxSpeed = moveDirX >= moveDirZ ? moveDirX : moveDirZ;
        
        if (_moveDir != Vector3.zero)
        {
            _rotation = Quaternion.LookRotation(_moveDir * Time.deltaTime);
        }
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation,_rotation,Time.deltaTime * _turnSpeed);
        _charController.Move(_moveDir * (_movementSpeed * maxSpeed) * Time.deltaTime);
    }
}