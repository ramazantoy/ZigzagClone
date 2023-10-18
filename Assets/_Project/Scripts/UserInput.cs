using UnityEngine;
using TouchPhase = UnityEngine.TouchPhase;

namespace LeonBrave.UserInput
{
    public class UserInput : MonoBehaviour
    {
        public static UserInput Instance;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public delegate void TouchDownEvent();

        public event TouchDownEvent TouchDown;


        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                TouchDown?.Invoke();
                return;
            }

#endif

            if (Input.touchCount > 0)
            {
                Touch dokunma = Input.GetTouch(0);

                if (dokunma.phase == TouchPhase.Began)
                {
                    TouchDown?.Invoke();
                }
            }
        }
    }
}