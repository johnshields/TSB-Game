using System;
using UnityEngine;

namespace Ryder
{
    public class RyderController : MonoBehaviour
    {
        private float _currentProfile;
        public float lowProfile = 0.02f;
        public float highProfile = 0.06f;
        public float rotationSpeed = 4.0f;

        private Rigidbody _bodyPhysics;
        private Animator _animator;
        private CapsuleCollider _capsuleCollider;

        public Transform cameraTransform;

        private float _yaw;
        private float _pitch;

        // animation triggers
        private int _idleActive;
        private int _walkActiveHash;
        private int _runActiveHash;


        private void Start()
        {
            _bodyPhysics = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _capsuleCollider = GetComponent<CapsuleCollider>();

            _idleActive = Animator.StringToHash("IdleActive");
            _walkActiveHash = Animator.StringToHash("WalkActive");
            _runActiveHash = Animator.StringToHash("RunActive");
        }

        private void FixedUpdate()
        {
            RyderMovement();
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
                    _animator.SetBool(_walkActiveHash, false);
                    _animator.SetBool(_runActiveHash, true);
                    _animator.SetBool(_idleActive, false);
                }
                else
                {
                    // Idle
                    _animator.SetBool(_walkActiveHash, false);
                    _animator.SetBool(_runActiveHash, false);
                    _animator.SetBool(_idleActive, true);
                }

                _currentProfile = highProfile;
            }
            else
            {
                if (forwardPressed)
                {
                    // Walk
                    _animator.SetBool(_walkActiveHash, true);
                    _animator.SetBool(_runActiveHash, false);
                    _animator.SetBool(_idleActive, false);
                }
                else
                {
                    // Idle
                    _animator.SetBool(_walkActiveHash, false);
                    _animator.SetBool(_runActiveHash, false);
                    _animator.SetBool(_idleActive, true);
                }

                _currentProfile = lowProfile;
            }
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