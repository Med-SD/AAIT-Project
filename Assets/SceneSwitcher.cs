using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName; // The name of the scene to switch to

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

