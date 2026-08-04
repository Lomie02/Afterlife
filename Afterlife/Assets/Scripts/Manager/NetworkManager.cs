using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    [Header("Callbacks")]
    public UnityEvent m_OnConnected;
    public UnityEvent m_OnDisconnected;
    [Space]
    public UnityEvent m_OnJoinLobby;
    public UnityEvent m_OnJoinLobbyFailed;
    [Space]
    public UnityEvent m_OnRoomJoined;
    public UnityEvent m_OnRoomFailed;
    public UnityEvent m_OnRoomLeft;


    [Space]
    [Header("Interfaces")]
    public GameObject m_CreateLobbyInterface;
    public Toggle m_LobbyPrivacy;
    public GameObject m_LobbyInterface;
    public void ConnectToServers()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Called when user connects to the master server.
    public override void OnConnectedToMaster()
    {
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

        base.OnDisconnected(cause);
    }

    // Called when user joins a lobby.
    public override void OnJoinedLobby()
    {
        m_OnJoinLobby.Invoke();
        base.OnJoinedLobby();
    }

    // Set the visiblity of the create lobby interface
    public void SetCreateLobbyInterface(bool _state)
    {
        if (m_CreateLobbyInterface)
            m_CreateLobbyInterface.SetActive(_state);
    }

    // Creates a game for others to join
    public void CreateGame()
    {
        RoomOptions options = new RoomOptions();
        options.IsVisible = !m_LobbyPrivacy.isOn;
        options.MaxPlayers = 4;

        PhotonNetwork.CreateRoom("game_test", options);
        SetCreateLobbyInterface(false);
    }

    // called when player creates a game.
    public override void OnCreatedRoom()
    {
        m_LobbyInterface.SetActive(true);
        m_OnRoomJoined.Invoke();
        base.OnCreatedRoom();
    }

    // called when player leaves the game
    public override void OnLeftRoom()
    {
        m_OnRoomLeft.Invoke();
        m_LobbyInterface.SetActive(false);
        base.OnLeftRoom();
    }

    // Called when the player fails to join or create a game
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        m_OnRoomFailed.Invoke();
        base.OnCreateRoomFailed(returnCode, message);
    }

    public void LeaveGame()
    {
        PhotonNetwork.LeaveRoom();
    }
}
