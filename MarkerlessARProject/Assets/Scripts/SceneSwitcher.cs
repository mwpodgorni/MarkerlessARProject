using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public void OpenScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Return()
    {
        SceneManager.LoadScene("Main");
    }
}
