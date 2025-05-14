using UnityEngine;

namespace DKC
{
    public class PlayerManager : CharacterManager
    {
        PlayerLocomotionManager playerLocomotionManager;
        // ReSharper disable once RedundantOverriddenMember
        protected override void Awake()
        {
            base.Awake();
            
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        protected override void Update()
        {
            base.Update();
            
            playerLocomotionManager.HandleAllMovement();
        }
    }
}