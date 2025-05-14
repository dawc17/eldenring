using UnityEngine;

namespace DKC
{
    public class CharacterManager : MonoBehaviour
    {
        protected virtual void Awake()
        {
            DontDestroyOnLoad(this); 
        }
    }
}
