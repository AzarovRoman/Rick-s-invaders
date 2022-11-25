using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pause;

    public void StartGame()
    {
        //SceneManager.LoadSceneAsync(0);
        SceneManager.LoadSceneAsync(1);

        GameOver2.IsWork = true;
        Time.timeScale = 1;
    }
}
