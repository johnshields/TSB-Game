/*
 * The Split Bullet
 * Main Camera
 * John Shields
 */

using UnityEngine;

namespace Cameras_etc
{
    public class MainCamera : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;
        public float smoothSpeed = 0.125f;

        public Vector3 direction;

        private void FixedUpdate()
        {
            var desiredPosition = target.position + offset;
            var smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;
        }
    }
}