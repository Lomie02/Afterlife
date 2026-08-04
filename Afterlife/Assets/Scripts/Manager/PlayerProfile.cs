using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    public Image m_PlayerIcon;
    public TextMeshProUGUI m_PlayerNameTag;
    public TextMeshProUGUI m_Level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CSteamID steamId = SteamUser.GetSteamID();

        int avatarid = SteamFriends.GetLargeFriendAvatar(steamId);

        if (m_PlayerIcon)
            m_PlayerIcon.sprite = GetIconSteam(avatarid);
    }

    public Sprite GetIconSteam(int _imageid)
    {
        uint w;
        uint h;

        SteamUtils.GetImageSize(_imageid, out w, out h);

        byte[] image = new byte[w * h * 4];

        SteamUtils.GetImageRGBA(_imageid, image, image.Length);

        Texture2D texture = new Texture2D(
            (int)w, (int)h,
            TextureFormat.RGBA32,
            false
            );

        texture.LoadRawTextureData(image);
        texture.Apply();

        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

    }

}
