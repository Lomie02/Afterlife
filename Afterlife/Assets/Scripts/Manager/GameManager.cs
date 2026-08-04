using Steamworks;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public UnityEvent m_OnConfigure;
    AsyncOperation m_SceneLoadingTask;


    /// <summary>
    /// Load a scene.
    /// </summary>
    /// <param name="_levelName"></param>
    /// 

    public void Start()
    {
        m_OnConfigure.Invoke();
    }

    public void ChangeScene(string _levelName)
    {
        StartCoroutine(LoadScene(_levelName));
    }


    // Load Scenes over time.
    IEnumerator LoadScene(string _sceneTarget)
    {
        m_SceneLoadingTask = SceneManager.LoadSceneAsync(_sceneTarget);

        if (!m_SceneLoadingTask.isDone)
        {
            yield return null;
        }
    }
}