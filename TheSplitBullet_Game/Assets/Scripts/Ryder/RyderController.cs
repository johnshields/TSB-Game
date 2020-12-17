﻿/*
 * The Split Bullet
 * Ryder Controller
 * John Shields
 */

using System;
using UnityEngine;

namespace Ryder
{
    public class RyderController : MonoBehaviour
    {
        // Ryder stats
        private float _actionSpeed = 1;
        [SerializeField] public float rotateSpeed = 1.0f;
        [SerializeField] public float lowProfile = 1.5f;
        [SerializeField] public float highProfile = 4.0f;
        [SerializeField] public float jumpLevel = 5.0f;
        private const float RyderBase = 0.5f;

        // Ryder animations
        private Animator _animator;
        
        // waling 
        private int _isWalkingHash;
        private int _isBackWalking;
        private int _isWalkingLeft;
        private int _isWalkingRight;
        
        // running
        private int _isRunningHash;
        private int _isBackRunning;
        private int _isRunningLeft;
        private int _isRunningRight;
        
        // other
        private int _isInspecting;
        
        // Ryder rotate
        private Rigidbody _bodyPhysics;
        private Vector3 _direction;
        
        // Start is called before the first frame update
        private void Start()
        {
            _animator = GetComponent<Animator>();
            
            // walking
            _isWalkingHash = Animator.StringToHash("isWalking");
            _isBackWalking = Animator.StringToHash("isBackWalking");
            _isWalkingLeft = Animator.StringToHash("isWalkingLeft");
            _isWalkingRight = Animator.StringToHash("isWalkingRight");
            
            // running
            _isRunningHash = Animator.StringToHash("isRunning");
            _isBackRunning = Animator.StringToHash("isBackRunning");
            _isRunningLeft = Animator.StringToHash("isRunningLeft");
            _isRunningRight = Animator.StringToHash("isRunningRight");
            
            // other
            _isInspecting = Animator.StringToHash("isInspecting");

            _bodyPhysics = GetComponent<Rigidbody>();
        }


        // Update is called once per frame
        private void FixedUpdate()
        {
            Walk();
            WalkLeft();
            WalkRight();
            
            Run();
            RunLeft();
            RunRight();
            
            Inspect();
            Jump();
        }

        private void Walk()
        {
            var horizontalMove = Input.GetAxisRaw("Horizontal") * _actionSpeed / 2;
            var verticalMove = Input.GetAxisRaw("Vertical") * _actionSpeed;
            _bodyPhysics.velocity = _direction = 
                (new Vector3(horizontalMove, 0, verticalMove) * Time.deltaTime);

            var forwardPressed = Input.GetKey("w");
            var backPressed = Input.GetKey("s");
            var isWalking = _animator.GetBool(_isWalkingHash);
            var isWalkingBack = _animator.GetBool(_isBackWalking);

            // Idle to Walk
            if (forwardPressed)
            {
                Turn();
                _actionSpeed = _actionSpeed * lowProfile;
                _animator.SetBool(_isWalkingHash, true);
            }

            if (isWalking && !forwardPressed)
            {
                _actionSpeed = 1f;
                _animator.SetBool(_isWalkingHash, false);
            }

            //Walk Backwards
            else if (backPressed)
            {
                _animator.SetBool(_isBackWalking, true);
            }

            if (!isWalkingBack || backPressed) return;
            Turn();
            _animator.SetBool(_isBackWalking, false);
        }
        
        private void WalkLeft()
        {
            var leftPressed = Input.GetKey("a");
            var isLeftWalking = _animator.GetBool(_isWalkingLeft);
            
            if (leftPressed)
            {
                _actionSpeed = _actionSpeed * lowProfile;
                _animator.SetBool(_isWalkingLeft, true);
            }

            if (!isLeftWalking || leftPressed) return;
            _actionSpeed = 1f;
            _animator.SetBool(_isWalkingLeft, false);
        }
        
        private void WalkRight()
        {
            var rightPressed = Input.GetKey("d");
            var isLeftWalking = _animator.GetBool(_isWalkingRight);
            
            if (rightPressed)
            {
                _actionSpeed = _actionSpeed * lowProfile;
                _animator.SetBool(_isWalkingRight, true);
            }

            if (!isLeftWalking || rightPressed) return;
            _actionSpeed = 1f;
            _animator.SetBool(_isWalkingRight, false);
        }

        private void Run()
        {
            var horizontalMove = Input.GetAxisRaw("Horizontal") * _actionSpeed / 8;
            var verticalMove = Input.GetAxisRaw("Vertical") * _actionSpeed;
            transform.Translate(new Vector3(horizontalMove, 0, verticalMove) * Time.deltaTime);

            var runActive = _animator.GetBool(_isRunningHash);
            var backRunActive = _animator.GetBool(_isBackRunning);
            var forwardPressed = Input.GetKey("w");
            var backPressed = Input.GetKey("s");
            var runPressed = Input.GetKey("left shift");
            var backRunPressed = Input.GetKey("left shift");

            // Walk to Run
            if (!runActive && (forwardPressed && runPressed))
            {
                Turn();
                _actionSpeed *= highProfile;
                _animator.SetBool(_isRunningHash, true);
            }

            if (runActive && (!forwardPressed || !runPressed))
            {
                _actionSpeed = 1f;
                _animator.SetBool(_isRunningHash, false);
            }
            
            // Run Backwards
            else if (!backRunActive && (backPressed && backRunPressed))
            {
                _animator.SetBool(_isBackRunning, true);
            }

            if (!backRunActive || (backPressed && backRunPressed)) return;
            Turn();
            _animator.SetBool(_isBackRunning, false);
        }

        private void RunLeft()
        {
            
            var leftRunActive = _animator.GetBool(_isRunningLeft);
            var leftPressed = Input.GetKey("a");
            var leftRunPressed = Input.GetKey("left shift");
            
            // Left Walk to Left Run
            if (!leftRunActive && (leftPressed && leftRunPressed))
            {
                _actionSpeed = _actionSpeed * highProfile;
                _animator.SetBool(_isRunningLeft, true);
            }

            if (leftRunActive && (!leftPressed || !leftRunPressed))
            {
                _actionSpeed = 1f;
                _animator.SetBool(_isRunningLeft, false);
            }
        }
        
        private void RunRight()
        {
            
            var rightRunActive = _animator.GetBool(_isRunningRight);
            var rightPressed = Input.GetKey("d");
            var rightRunPressed = Input.GetKey("left shift");
            
            // Left Walk to Left Run
            if (!rightRunActive && (rightPressed && rightRunPressed))
            {
                _actionSpeed = _actionSpeed * highProfile;
                _animator.SetBool(_isRunningRight, true);
            }

            if (rightRunActive && (!rightPressed || !rightRunPressed))
            {
                _actionSpeed = 1f;
                _animator.SetBool(_isRunningRight, false);
            }
        }

        private void Turn()
        {
            // rotate direction
            if (_direction !=Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp
                    (transform.rotation, Quaternion.LookRotation(_direction), rotateSpeed * Time.deltaTime);
            }
            _bodyPhysics.MovePosition(transform.position + _actionSpeed * Time.deltaTime * _direction);
        }

        private void Inspect()
        {
            var inspectPressed = Input.GetKey("i");
            var idleInspect = Input.GetKey("left ctrl");
            var isInspecting = _animator.GetBool(_isInspecting);

            // Idle to inspect
            if (inspectPressed && idleInspect)
            {
                _animator.SetBool(_isInspecting, true);
            }

            if (isInspecting && (!inspectPressed && !idleInspect))
            {
                _animator.SetBool(_isInspecting, false);
            }
        }
        private void Jump()
        {
            var jump = Input.GetKey("space");

            if (!jump) return;
            // player does not jump if is not touching the ground layer
            if (transform.position.y <=RyderBase) {
                _bodyPhysics.AddForce(Vector3.up * jumpLevel); // jump height
            }
        }
        
    }
}