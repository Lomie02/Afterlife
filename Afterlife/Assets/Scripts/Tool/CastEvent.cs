using UnityEngine;
using UnityEngine.Events;

public class CastEvent : MonoBehaviour
{
    public UnityEvent m_OnCalled;

    /// <summary>
    /// Trigger an event.
    /// </summary>
    public void Call()
    {
        m_OnCalled.Invoke();
    }
}
