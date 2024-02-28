using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public void OpenLevelByRef(SceneAsset Scene)
    {
        SceneManager.LoadScene(Scene.name);
    }
    public void OpenLevelByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
