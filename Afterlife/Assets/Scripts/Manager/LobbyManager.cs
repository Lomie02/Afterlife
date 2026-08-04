using Photon.Pun;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    SteamUtilityManager m_SteamUtil;

    public GameObject[] m_HostOnlyObjects;

    private void Start()
    {
        m_SteamUtil = FindAnyObjectByType<SteamUtilityManager>();
    }

    public void UpdateInterface()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            for(int i = 0; i < m_HostOnlyObjects.Length; i++)
            {
                m_HostOnlyObjects[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < m_HostOnlyObjects.Length; i++)
            {
                m_HostOnlyObjects[i].SetActive(true);
            }
        }

        //======

        if (m_SteamUtil)
            m_SteamUtil.SetLobbyStatus(PhotonNetwork.CurrentRoom.PlayerCount, PhotonNetwork.CurrentRoom.MaxPlayers);
    }


}
