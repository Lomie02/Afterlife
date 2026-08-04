using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    [Header("Callbacks")]
    public UnityEvent m_OnConnected;
    public UnityEvent m_OnDisconnected;
    [Space]
    public UnityEvent m_OnJoinLobby;
    public UnityEvent m_OnJoinLobbyFailed;

    TextMeshProUGUI m_ConnectionStatus;
    public void ConnectToServers()
    {
        if (m_ConnectionStatus)
            m_ConnectionStatus.text = "Connecting to game Servers.";
        PhotonNetwork.ConnectUsingSettings();
    }

    // Called when user connects to the master server.
    public override void OnConnectedToMaster()
    {
        if (m_ConnectionStatus)
            m_ConnectionStatus.text = "Connecting to steam.";

        if (SteamManager.Initialized)
        {
            PhotonNetwork.JoinLobby();
            m_OnConnected.Invoke();
        }
        else
        {
            PhotonNetwork.Disconnect();
        }
    }

    // Called after disconnecting from the servers.
    public override void OnDisconnected(DisconnectCause cause)
    {
        m_OnDisconnected.Invoke();

        if (m_ConnectionStatus)
            m_ConnectionStatus.text = "Connected Failed.";
            
        base.OnDisconnected(cause);
    }

    // Called when user joins a lobby.
    public override void OnJoinedLobby()
    {
        m_OnJoinLobby.Invoke();
        base.OnJoinedLobby();
    }

}
