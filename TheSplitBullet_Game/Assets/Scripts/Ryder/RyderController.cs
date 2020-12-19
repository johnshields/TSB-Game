using UnityEngine;

namespace Ryder
{
    public class RyderController : MonoBehaviour
    {

        private float _forwardInput;
        private float _rightInput;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(new Vector3(_forwardInput, 0, _rightInput));
        }

        public void ActionInput(float forward, float right)
        {
            _forwardInput = forward;
            _rightInput = right;

        }
    }
}
