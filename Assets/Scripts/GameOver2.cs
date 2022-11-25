using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver2 : MonoBehaviour
{
    public static bool IsWork = true;

    public delegate void CompleteGameAction();
    public static event CompleteGameAction Action;

    public GameObject winPic;
    public GameObject LosePic;
    public GameObject DeadMortyPic;

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Awake()
    {
        Action += SetFaslseIsWork;
    }

    private void Update()
    {
        if (IsWork == true)
        {
            // победа (когда врагов не осталось)
            if (Ments.ments.Count <= 0)
            {
                Action += ShowWinPic;
                Action?.Invoke();

                Action -= ShowWinPic;
            }

            // поражение когда все морти мертвы
            List<GameObject> Morty = GameObject.FindGameObjectsWithTag("Tower").ToList();

            if (Morty.Count == 0)
            {
                Action += ShowDeadMortyPic;
                Action?.Invoke();

                Action -= ShowDeadMortyPic;
            }

            // поражение когда рик умер
            GameObject Rick = GameObject.FindGameObjectWithTag("Player");
            if (Rick.GetComponent<RickMovement>().health <= 0)
            {
                Action += ShowLosePic;
                Action?.Invoke();

                Action -= ShowLosePic;
            }
        }
    }

    public static void EndGame()
    {
        Action?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Action += ShowLosePic;
            Action?.Invoke();

            Action -= ShowLosePic;
        }
    }

    private void ShowWinPic()
    {
        winPic.SetActive(true);
    }

    private void ShowDeadMortyPic()
    {
        DeadMortyPic.SetActive(true);
    }

    private void ShowLosePic()
    {
        LosePic.SetActive(true);
    }

    private void SetFaslseIsWork()
    {
        IsWork = false;
    }
}