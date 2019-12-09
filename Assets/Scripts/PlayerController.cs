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
        private string mActionKey = string.Empty;

        private CharacterController mCharController;
        private bool mAllowInput;
        private bool mInitialized;

        void Start()
        {
            mCharController = GetComponent<CharacterController>();
            mInitialized = true;
            PlayerPause(false);
        }

        public void PlayerPause(bool value)
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

        void HandleInput()
        {
            if (mAllowInput && mInitialized)
            {
                Vector3 displacement = new Vector3(Input.GetAxis(mHorizontalAxis), 0, Input.GetAxis(mVerticalAxis)) * mSpeed * Time.deltaTime;
                mCharController.Move(displacement);
            }
        }
    }
}
