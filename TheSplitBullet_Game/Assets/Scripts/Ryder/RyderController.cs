/*
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
        // Ryder speed
        private float _actionSpeed = 1;
        private float _rotateSpeed = 1;
        [SerializeField] public float lowProfile = 1.5f;
        [SerializeField] public float highProfile = 4.0f;

        // Ryder animations
        private Animator _animator;
        private int _isWalkingHash;
        private int _isRunningHash;
        private int _isBackWalking;
        private int _isBackRunning;
        
        // Ryder rotate
        private Rigidbody _bodyPhysics;
        private Vector3 _direction;
        
        // Start is called before the first frame update
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _isWalkingHash = Animator.StringToHash("isWalking");
            _isRunningHash = Animator.StringToHash("isRunning");
            _isBackWalking = Animator.StringToHash("isBackWalking");
            _isBackRunning = Animator.StringToHash("isBackRunning");

            _bodyPhysics = GetComponent <Rigidbody>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            Walk();
            Run();
        }

        private void Walk()
        {
            float horizontalMove = Input.GetAxisRaw("Horizontal") * _actionSpeed;
            float verticalMove = Input.GetAxisRaw("Vertical") * _actionSpeed;
            _direction = (new Vector3(horizontalMove, 0, verticalMove) * Time.deltaTime);

            bool forwardPressed = Input.GetKey("w");
            bool backPressed = Input.GetKey("s");
            bool isWalking = _animator.GetBool(_isWalkingHash);
            bool isWalkingBack = _animator.GetBool(_isBackWalking);

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
            
            if (isWalkingBack && ! backPressed)
            {
                Turn();
                _animator.SetBool(_isBackWalking, false);
            }
        }

        private void Run()
        {
            float horizontalMove = Input.GetAxisRaw("Horizontal") * _actionSpeed;
            float verticalMove = Input.GetAxisRaw("Vertical") * _actionSpeed;
            transform.Translate(new Vector3(horizontalMove, 0, verticalMove) * Time.deltaTime);

            bool runActive = _animator.GetBool(_isRunningHash);
            bool backRunActive = _animator.GetBool(_isBackRunning);
            bool forwardPressed = Input.GetKey("w");
            bool backPressed = Input.GetKey("s");
            bool runPressed = Input.GetKey("left shift");
            bool backRunPressed = Input.GetKey("left shift");

            // Walk to Run
            if (!runActive && (forwardPressed && runPressed))
            {
                Turn();
                _actionSpeed = _actionSpeed * highProfile;
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
            
            if (backRunActive && (!backPressed || !backRunPressed))
            {
                Turn();
                _animator.SetBool(_isBackRunning, false);
            }
        }
        
        private void Turn()
        {
            // rotate direction
            if (_direction !=Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp
                    (transform.rotation, Quaternion.LookRotation(_direction), _rotateSpeed * Time.deltaTime);
            }
            _bodyPhysics.MovePosition(transform.position + _actionSpeed * Time.deltaTime * _direction);
        }
    }
}
