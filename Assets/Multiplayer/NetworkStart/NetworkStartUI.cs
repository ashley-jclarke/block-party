using UnityEngine;
using Unity.Netcode;

public class NetworkStartUI : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    public void Host()
    {
        Debug.Log("Start host");
        NetworkManager.Singleton.StartHost();
        menu.GetComponent<Renderer>().enabled = false;
    }
    public void Client()
    {
        Debug.Log("Start client");
        NetworkManager.Singleton.StartClient();
        menu.GetComponent<Renderer>().enabled = false;

    }
    public void Server()
    {
        Debug.Log("Start server");
        NetworkManager.Singleton.StartServer();
        menu.GetComponent<Renderer>().enabled = false;
    }
}
