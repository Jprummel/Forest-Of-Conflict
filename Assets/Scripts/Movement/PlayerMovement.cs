using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    private CharacterController _charController;
    //Speed
    [SerializeField]private float _movementSpeed;
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
        Movement();
    }

    public void Inputs(Vector3 moveDirection)
    {
        _moveDir = moveDirection;
    }

    public void Movement()
    {
        _newForward = Vector3.Normalize(new Vector3 (_moveDir.x, 0, _moveDir.z) * _movementSpeed * Time.deltaTime);
        float moveDirX = _moveDir.x >= 0 ? _moveDir.x : -_moveDir.x;
        float moveDirZ = _moveDir.z >= 0 ? _moveDir.z : -_moveDir.z;
        float maxSpeed = moveDirX >= moveDirZ ? moveDirX : moveDirZ;
        if (_moveDir != Vector3.zero)
        {
            _rotation = Quaternion.LookRotation(_moveDir * Time.deltaTime);
        }

        this.transform.forward = _newForward;
        _charController.Move(_newForward * (_movementSpeed * maxSpeed) * Time.deltaTime);
        this.transform.rotation = _rotation;
        //transform.Translate(_newForward *(_movementSpeed * maxSpeed)* Time.deltaTime);
        //float angle = (Mathf.Atan2(_moveDir.x, _moveDir.z) * 180 / Mathf.PI);
        //Quaternion playerRotation = Quaternion.Euler(0f, angle, 0f);
        //transform.localRotation = Quaternion.Lerp(transform.localRotation, playerRotation, Time.deltaTime * 7);
    }
}