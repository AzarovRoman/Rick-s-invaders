using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 10;

    void Update()
    {
        if (GameOver2.IsWork == true)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    // пуля имеет ссылку на морти(во время коллизии) и уменьшает ему здоровье через метод морти
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            collision.gameObject.GetComponent<MortyScript>().ReduceHp();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<RickMovement>().ReduceHp();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            ScoreManager.instance.AddPoint();
        }
        if (collision.gameObject.tag == "EnemyBullet" && gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}