using UnityEngine;

namespace SaladChef
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField]
        private string mPlayerName = string.Empty;
        [SerializeField]
        private float mSpeed = default;

        [Header("Movement")]
        [SerializeField]
        private string mHorizontalAxis = string.Empty;
        [SerializeField]
        private string mVerticalAxis = string.Empty;
        [SerializeField]
        private string mAction = string.Empty;

        private CharacterController mCharController;
        private bool mAllowInput;
        private bool mInitialized;

        private Collider mCurrentCollider;

        void Start()
        {
            mCharController = GetComponent<CharacterController>();
            mInitialized = true;
            StopPlayerMovement(false);
        }

        public void StopPlayerMovement(bool value)
        {
            mAllowInput = !value;
        }

        void Update()
        {
            HandleInput();
        }

        public void UpdateSpeed(float speed)
        {
            mSpeed = speed;
        }

        private void HandleInput()
        {
            if (mAllowInput && mInitialized)
            {
                Vector3 displacement = new Vector3(Input.GetAxis(mHorizontalAxis), 0, Input.GetAxis(mVerticalAxis)) * mSpeed * Time.deltaTime;
                mCharController.Move(displacement);

                if (Input.GetButtonDown(mAction))
                    OnPlayerInteraction();
            }
        }

        private void OnPlayerInteraction()
        {
            Debug.Log("on player action:: " + name);
        }

        private void OnTriggerEnter(Collider collider)
        {
            mCurrentCollider = collider;
            Debug.Log("collider enter:: " + mCurrentCollider.name);
        }

        private void OnTriggerExit(Collider collider)
        {
            Debug.Log("collider exit:: " + collider.name);
            mCurrentCollider = null;            
        }
    }
}
