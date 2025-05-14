using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DKC
{
    public class PlayerInputManager : MonoBehaviour
    {
        // 1. read player input
        // move chatacter based on input
        public static PlayerInputManager instance;
        private PlayerControls playerControls;

        [SerializeField] private Vector2 movement;

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
            SceneManager.activeSceneChanged += OnSceneChange;
            instance.enabled = false;
        }

        private void OnSceneChange(Scene oldScene, Scene newScene)
        {
            if (newScene.buildIndex == WorldSaveGameManager.Instance.GetWorldSceneIndex())
            {
                instance.enabled = true;
            }
            else
            {
                instance.enabled = false;
            }
        }

        private void OnDestroy()
        {
            SceneManager.activeSceneChanged -= OnSceneChange;
        }

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();
                playerControls.PlayerMovement.Movement.performed += i => movement = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }
    }
}