using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject _pause;

    public void PauseOff()
    { 
        _pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void Start()
    {
        _pause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pause.SetActive(true);
            Time.timeScale = 0;
        }
    }
}