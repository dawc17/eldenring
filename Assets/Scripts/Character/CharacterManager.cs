using System;
using UnityEngine;
using Unity.Netcode;

namespace DKC
{
    public class CharacterManager : NetworkBehaviour
    {
        public CharacterController characterController;

        private CharacterNetworkManager characterNetworkManager;
        protected virtual void Awake()
        {
            DontDestroyOnLoad(this); 
            
            characterController = GetComponent<CharacterController>();
            characterNetworkManager = GetComponent<CharacterNetworkManager>();
        }

        protected virtual void Update()
        {
            // if character owned by us, assign position to our transform
            if (IsOwner)
            {
                characterNetworkManager.networkPosition.Value = transform.position;
                characterNetworkManager.networkRotation.Value = transform.rotation;
            }
            // if controlled from elsewhere, update position locally based on network position
            else
            {
                // position
                transform.position = Vector3.SmoothDamp(transform.position,
                    characterNetworkManager.networkPosition.Value, 
                    ref characterNetworkManager.networkPositionVelocity,
                    characterNetworkManager.networkPositionSmoothTime);
                
                // rotation
                transform.rotation = Quaternion.Slerp
                    (transform.rotation, 
                        characterNetworkManager.networkRotation.Value, 
                        characterNetworkManager.networkRotationSmoothTime);
            }
        }

        protected virtual void LateUpdate()
        {
            
        }
    }
}
