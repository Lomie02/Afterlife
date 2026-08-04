using UnityEngine;
using UnityEngine.Events;

public enum InputType
{
    press = 0,
    hold,
    up,
}

[System.Serializable]
public struct InputProfile
{
    public string m_Name;
    public KeyCode m_Key;
    public InputType m_Type;
    public UnityEvent m_OnPress;
}

public class InputManager : MonoBehaviour
{
    public InputProfile[] m_InputList;


    void Start()
    {

    }

    void Update()
    {

    }
}
