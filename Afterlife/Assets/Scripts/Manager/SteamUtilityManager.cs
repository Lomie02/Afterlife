using Steamworks;
using UnityEngine;

[System.Serializable]
public struct AchivementData
{
    public string m_Name;
    public string m_ID;
}

public class SteamUtilityManager : MonoBehaviour
{
    SteamManager m_SteamManager;
    [SerializeField] bool m_SteamAchievmentsEnabled = true;
    [SerializeField] AchivementData[] m_Achievements;

    string m_UsersName = "no_name";

    void Start()
    {
        m_SteamManager = GetComponent<SteamManager>();

        if (SteamManager.Initialized)
        {
            m_UsersName = SteamFriends.GetPersonaName();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        SteamAPI.RunCallbacks();
    }

    public void UnlockAchivement(string _name)
    {
        if (m_SteamAchievmentsEnabled)
        {
            for (int i = 0; i < m_Achievements.Length; i++)
            {
                if (m_Achievements[i].m_Name != _name) continue;
                SteamUserStats.SetAchievement(m_Achievements[i].m_ID);
                SteamUserStats.StoreStats();
                break;
            }
        }
    }

    public void SetSteamStatus(string _status)
    {
        if (SteamManager.Initialized)
            SteamFriends.SetRichPresence("steam_display", "#" + _status);
    }

    public void SetLobbyStatus(int _players, int _maxPlayers)
    {
        if (!SteamManager.Initialized) return;

        string playCount = _players.ToString() + "/" + _maxPlayers.ToString();

        SteamFriends.SetRichPresence("players", playCount);
        SteamFriends.SetRichPresence("steam_display", "#InLobby");
    }

    public string GetUsername()
    {
        return m_UsersName;
    }
}
