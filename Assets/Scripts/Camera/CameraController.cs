using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    //Makes it able to set a target
    [SerializeField]private Transform _target;
    [SerializeField]private Transform _camera;
    [SerializeField]private float _cameraSensitivityX;
    [SerializeField]private float _cameraSensitivityY;
    [SerializeField]private float _minX;
    [SerializeField]private float _maxX;
    private Vector3 _offset;
    private float _rotationX;
    private float _rotationY;
    private Vector3 _rotationDir;
    private Vector3 _cameraForward;
    private Vector3 _targetForward;

    void Start()
    {
        _offset = _target.position - _camera.position;
    }

    void LateUpdate()
    {
        //makes the camera follow the target
        _camera.position = _target.position - _offset;
        CamRotation();
    }

    public void Inputs(Vector3 rotationDirection)
    {
        _rotationDir = rotationDirection;
    }

    void CamRotation()
    {
        _rotationX = Mathf.Clamp(_rotationX, _minX, _maxX);
        _camera.eulerAngles = new Vector3(_rotationX, _rotationY);

        _rotationY += Time.deltaTime * _rotationDir.x * _cameraSensitivityX;
        _rotationX += Time.deltaTime * _rotationDir.y * _cameraSensitivityY;

        _cameraForward = _camera.TransformDirection(Vector3.forward);
        _cameraForward.y = 0;
        //_cameraForward = _cameraForward.normalized;

        //_target.forward = _cameraForward;
        
    }
}
