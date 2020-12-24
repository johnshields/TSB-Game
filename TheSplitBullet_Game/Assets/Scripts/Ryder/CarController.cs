using UnityEngine;

namespace Ryder
{
    public class CarController : MonoBehaviour
    {
        private float _currentSpeed;
        [SerializeField] public float acceleration = 0.06f;
        [SerializeField] public float rotationSpeed = 4.0f;
        
        private Rigidbody _carPhysics;
        private BoxCollider _boxCollider;
        
        public Transform cameraTransform;

        private float _yaw;
        private float _pitch;
        
        // Start is called before the first frame update
        private void Start()
        {
            _carPhysics = GetComponent<Rigidbody>();
            _boxCollider = GetComponent<BoxCollider>();
        }
        
        private void FixedUpdate()
        {
            Drive();
            CameraMovement();
        }

        private void Drive()
        {
            var z = Input.GetAxis("Vertical") * _currentSpeed;
            var y = Input.GetAxis("Horizontal") * rotationSpeed;
            transform.Translate(0, 0, z);
            transform.Rotate(0, y, 0);
            _currentSpeed = acceleration;
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
