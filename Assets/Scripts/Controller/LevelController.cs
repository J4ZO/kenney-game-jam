using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartLevel()
    {
        GameManager.Instance.Restart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
