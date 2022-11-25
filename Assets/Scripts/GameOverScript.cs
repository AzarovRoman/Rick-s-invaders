using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    //public List<GameObject> towers;

    //private int _towersDestroyed;

    //private void Start()
    //{
    //    _towersDestroyed = 0;
    //    StartCoroutine(Stop());
    //}

    //private void Update()
    //{

    //}

    //// добавить ЦИКЛ игр (типа где начало и конец)
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Enemy")
    //    {
    //        Time.timeScale = 0;
    //    }
    //}

    //private IEnumerator Stop()
    //{
    //    while (true)
    //    {
    //        foreach (GameObject tower in towers)
    //        {
    //            if (tower.IsDestroyed() == true)
    //            {
    //                _towersDestroyed += 1;
    //            }
    //            yield return null;
    //        }

    //        if (_towersDestroyed == towers.Count)
    //        {
    //            Time.timeScale = 0;
    //            StopCoroutine(Stop());
    //        }
    //        else
    //        {
    //            _towersDestroyed = 0;
    //        }

    //        yield return null;
    //    }
    //}
}