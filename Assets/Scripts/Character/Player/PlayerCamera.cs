using System;
using UnityEngine;

namespace DKC
{
    public class PlayerCamera : MonoBehaviour
    {
        public static PlayerCamera instance;
        public Camera cameraObject;

        public PlayerManager player;

        [Header("Camera Settings")] private Vector3 cameraVelocity;
        private float cameraSmoothSpeed = 1;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void HandleAllCameraActions()
        {
            if (player != null)
            {
                FollowTarget();
            }
            // follow player
            // rotate around player
            // do not clip through walls
        }

        private void FollowTarget()
        {
            Vector3 targetCameraPosition = Vector3.SmoothDamp(transform.position, player.transform.position,
                ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
            transform.position = targetCameraPosition;
        }
    }
}