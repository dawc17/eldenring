using UnityEngine;
using Unity.Netcode;

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
