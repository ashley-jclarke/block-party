using UnityEngine;
using Unity.Netcode;

public class NetworkStartUI : MonoBehaviour
{
    [SerializeField] private Canvas menu;

    public void Host()
    {
        Debug.Log("Start host");
        NetworkManager.Singleton.StartHost();
        DisableMenu();
    }
    public void Client()
    {
        Debug.Log("Start client");
        NetworkManager.Singleton.StartClient();
        DisableMenu();
    }
    public void Server()
    {
        Debug.Log("Start server");
        NetworkManager.Singleton.StartServer();
        DisableMenu();
    }
    private void DisableMenu()
    {
        menu.enabled = false;
    }
}
