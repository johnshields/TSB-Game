/*
 * The Split Bullet
 * Main Camera
 * John Shields
 */

using System;
using UnityEngine;

namespace Cameras_etc
{
    public class MainCamera : MonoBehaviour
    {
        // follow Ryder
        public Transform target;
        [SerializeField] public Vector3 offset;
        public float smoothSpeed = 0.125f;

        // mouse controls
        [SerializeField] public float cameraAction = 1.0f;
        [SerializeField] public float cameraUpMax = 60f;
        [SerializeField] public float cameraUpMin = -60f;
        private Quaternion _cameraRotation;
        

        private void FixedUpdate()
        {
            var desiredPosition = target.position + offset;
            var smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;
        }
        

        private void Start()
        {
            _cameraRotation = transform.localRotation;
        }

        private void Update()
        {
            // Debug.Log(Input.GetAxis("Mouse X") + "  :   " + Input.GetAxis("Mouse Y"));

            _cameraRotation.x += Input.GetAxis("Mouse Y") * cameraAction * (-1); // look up and down
            _cameraRotation.y += Input.GetAxis("Mouse X") * cameraAction; // look left to right

            _cameraRotation.x = Mathf.Clamp(_cameraRotation.x, cameraUpMin, cameraUpMax);

            transform.localRotation = Quaternion.Euler(_cameraRotation.x, _cameraRotation.y, _cameraRotation.z);
        }
    }
}