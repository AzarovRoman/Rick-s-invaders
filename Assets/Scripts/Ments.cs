using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ments : MonoBehaviour
{
    public static List<GameObject> ments = new List<GameObject>();

    public GameObject defaultMent;

    public float speed = 1f;
    public ShootingScript shootScript;

    public int rows = 4;
    public int cols = 6;

    private float horizDistance = 4;

    private Vector3 _direction = Vector2.right;
    private System.Random _rand;

    private void Awake()
    {

        for (int row = 0; row < rows; row++)
        {
            float width = horizDistance * (cols - 1);
            float height = 2 * (rows - 1);

            Vector2 centering = new Vector2(-width/2, -height/2);
            Vector2 rowPosition = new Vector3(centering.x, centering.y + (row * 3));

            for (int col = 0; col < cols; col++)
            {
                GameObject ment = Instantiate(defaultMent, transform);
                ments.Add(ment);

                Vector2 position = rowPosition;
                position.x += col * horizDistance;

                ment.gameObject.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        _rand = new();

        StartCoroutine(MentShoot());
    }

    private void Update()
    {
        if (GameOver2.IsWork == true)
        {
            transform.position += _direction * speed * Time.deltaTime;
            StartCoroutine(MentMove());
        }
    }

    private void AdvanceRow()
    {
        _direction *= -1;

        Vector3 position = transform.position;
        position.y -= 1;

        transform.position = position;
    }

    private void Shoot(Transform ment)
    {
        Instantiate(shootScript, ment.transform.position, shootScript.transform.rotation);
    }

    private IEnumerator MentMove()
    {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform ment in transform)
        {
            if (ment.gameObject.IsDestroyed() == true)
            {
                ments.Remove(ment.gameObject);
            }

            if (_direction == Vector3.right && ment.position.x >= (rightEdge.x - 1))
            {
                AdvanceRow();
            }
            else if (_direction == Vector3.left && ment.position.x <= (leftEdge.x + 1))
            {
                AdvanceRow();
            }
            yield return null;
        }
    }

    // записать всех ментов в лист и что бы случайный из них стрелял раз в секунду (не забыть проверку на null)
    private IEnumerator MentShoot()
    {
        while (ments.Count > 0 && GameOver2.IsWork == true)
        {
            yield return new WaitForSeconds(1f);
            var mustShootMent = ments[_rand.Next(ments.Count)];

            Shoot(mustShootMent.transform);

            yield return null;
        }
    }
}