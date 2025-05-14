using Unity.Netcode;
using UnityEngine;
using World_Managers;

namespace Menu_Scene
{
    public class TitleScrenManager : MonoBehaviour
    {
        public void StartNetworkAsHost()
        {
            NetworkManager.Singleton.StartHost();
        }

        public void StartNewGame()
        {
            StartCoroutine(WorldSaveGameManager.Instance.LoadNewGame());
        }
    }
}
