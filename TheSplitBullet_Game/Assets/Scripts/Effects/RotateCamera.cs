using UnityEngine;

namespace Effects
{
    public class RotateCamera : MonoBehaviour
    {
        private void Update()
        { 
            transform.Rotate(Vector3.forward, 10.0f * Time.deltaTime);
        }
    }
}