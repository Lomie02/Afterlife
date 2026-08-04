using UnityEngine;
using UnityEngine.Events;
public class StartEvent : MonoBehaviour
{
    public UnityEvent m_OnCall;
    void Start()
    {
        m_OnCall.Invoke();
    }

}
