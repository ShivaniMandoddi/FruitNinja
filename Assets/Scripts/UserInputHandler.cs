using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserHandler
{
    public class UserInputHandler : MonoBehaviour
    {
        #region PUBLIC VARIABLES
        public delegate void OnPanStart(Touch touch);
        public static event OnPanStart OnPanStartAction;
        #endregion
        #region PRIVATE VARIABLES
        private bool isGestureRecognised = false;
        private float startTime;
        private float maxTime = 0.4f;
        #endregion
        #region MONOBEHAVIOUR METHODS
        private void Start()
        {
            startTime = Time.time;
        }
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began)
                {
                    startTime = Time.time;
                }
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    if (Time.time - startTime >= 0.1f)
                    {
                        Debug.Log("PanGesture Enabled");
                        if (!isGestureRecognised)
                        {
                            
                            //isGestureRecognised = true;
                            if (OnPanStartAction != null)
                            {
                                OnPanStartAction(touch);
                            }

                        }
                    }
                    else if (isGestureRecognised)
                    {
                        Debug.Log("Helding method");
                        if (OnPanStartAction != null)
                        {
                            OnPanStartAction(touch);
                        }
                    }
                }

                else
                {
                    isGestureRecognised = false;
                }
            }
        }
        #endregion
        #region PUBLIC METHODS

        #endregion
        #region PRIVATE METHODS

        #endregion
    }
}
