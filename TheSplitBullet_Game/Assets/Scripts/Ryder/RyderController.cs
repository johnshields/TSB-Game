using System;
using UnityEngine;

namespace Ryder
{
    public class RyderController : MonoBehaviour
    { 
        // Ryder Stats
        private float _currentProfile;
        private const float RyderBase = 0.01f;
        [SerializeField] public float lowProfile = 0.02f;
        [SerializeField] public float highProfile = 0.06f;
        [SerializeField] public float rotationSpeed = 4.0f;
        [SerializeField] public float jumpLevel = 5.0f;

        private Rigidbody _bodyPhysics;
        private Animator _animator;
        private CapsuleCollider _capsuleCollider;

        public Transform cameraTransform;

        private float _yaw;
        private float _pitch;

        // animation bools
        private int _idleActiveHash;
        private int _walkActiveHash;
        private int _runActiveHash;
        private int _backRunActiveHash;
        private int _inspectActiveHash;

        private void Start()
        {
            _bodyPhysics = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _capsuleCollider = GetComponent<CapsuleCollider>();

            _idleActiveHash = Animator.StringToHash("IdleActive");
            _walkActiveHash = Animator.StringToHash("WalkActive");
            _runActiveHash = Animator.StringToHash("RunActive");
            _backRunActiveHash = Animator.StringToHash("BackRunActive");
            _inspectActiveHash = Animator.StringToHash("InspectActive");
        }

        private void FixedUpdate()
        {
            RyderMovement();
            MoveBack();
            Inspect();
            CameraMovement();
        }

        private void RyderMovement()
        {
            // move Ryder
            var z = Input.GetAxis("Vertical") * _currentProfile;
            var y = Input.GetAxis("Horizontal") * rotationSpeed;
            transform.Translate(0, 0, z);
            transform.Rotate(0, y, 0);

            // Player Inputs
            var forwardPressed = Input.GetKey("w");
            var highProfilePressed = Input.GetKey("left shift");

            if (highProfilePressed)
            {
                if (forwardPressed)
                {
                    // Run
                    _animator.SetBool(_inspectActiveHash, false);
                    _animator.SetBool(_backRunActiveHash, false);
                    _animator.SetBool(_walkActiveHash, false);
                    _animator.SetBool(_runActiveHash, true);
                    _animator.SetBool(_idleActiveHash, false);
                }
                else
                {
                    // Idle
                    _animator.SetBool(_inspectActiveHash, false);
                    _animator.SetBool(_backRunActiveHash, false);
                    _animator.SetBool(_walkActiveHash, false);
                    _animator.SetBool(_runActiveHash, false);
                    _animator.SetBool(_idleActiveHash, true);
                }

                _currentProfile = highProfile;
            }
            else
            {
                if (forwardPressed)
                {
                    // Walk
                    _animator.SetBool(_inspectActiveHash, false);
                    _animator.SetBool(_backRunActiveHash, false);
                    _animator.SetBool(_walkActiveHash, true);
                    _animator.SetBool(_runActiveHash, false);
                    _animator.SetBool(_idleActiveHash, false);
                }
                else
                {
                    // Idle
                    _animator.SetBool(_inspectActiveHash, false);
                    _animator.SetBool(_backRunActiveHash, false);
                    _animator.SetBool(_walkActiveHash, false);
                    _animator.SetBool(_runActiveHash, false);
                    _animator.SetBool(_idleActiveHash, true);
                }
                _currentProfile = lowProfile;
            }
        }
        
        private void MoveBack()
        {
            // Player Input
            var backPressed = Input.GetKey("s");
            // Animator bool
            var backRunActive = _animator.GetBool(_backRunActiveHash);
            
            if (backPressed)
            {
                // Move Back
                _animator.SetBool(_inspectActiveHash, false);
                _animator.SetBool(_walkActiveHash, false);
                _animator.SetBool(_runActiveHash, false);
                _animator.SetBool(_idleActiveHash, false);
                _animator.SetBool(_backRunActiveHash, true);
            }

            if (!backRunActive || backPressed) return;
            // Idle
            _animator.SetBool(_inspectActiveHash, false);
            _animator.SetBool(_walkActiveHash, false);
            _animator.SetBool(_runActiveHash, false);
            _animator.SetBool(_idleActiveHash, true);
            _animator.SetBool(_backRunActiveHash, false);
        }

        private void Inspect()
        {
            // Player Input
            var inspectPressed = Input.GetKey("i");
            // Animator bool
            var inspectActive = _animator.GetBool(_inspectActiveHash);

            switch (inspectPressed)
            {
                // Inspect
                case true:
                    _animator.SetBool(_walkActiveHash, false);
                    _animator.SetBool(_runActiveHash, false);
                    _animator.SetBool(_idleActiveHash, false);
                    _animator.SetBool(_inspectActiveHash, true);
                    _currentProfile = 0;
                    break;
            }

            // Idle
            if (!inspectActive || inspectPressed) return;
            _animator.SetBool(_walkActiveHash, false);
            _animator.SetBool(_runActiveHash, false);
            _animator.SetBool(_idleActiveHash, false);
            _animator.SetBool(_inspectActiveHash, false);
        }

        private void CameraMovement()
        {
            // move Camera with mouse
            _yaw += rotationSpeed * Input.GetAxisRaw("Mouse X");
            _pitch -= rotationSpeed * Input.GetAxisRaw("Mouse Y");
            transform.eulerAngles = new Vector3(0, _yaw, 0);
            cameraTransform.eulerAngles = new Vector3(_pitch, _yaw, 0);
        }
    }
}