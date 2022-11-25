using UnityEngine;

public class RickMovement : MonoBehaviour
{
    public GameObject gun;
    public float speed = 5;
    public ShootingScript shootScript;
    public int health = 3;

    private float _shootTime;

    public void Shoot()
    {
        Instantiate(shootScript, gun.transform.position, shootScript.transform.rotation);
    }

    private void Update()
    {
        if (GameOver2.IsWork == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if ((_shootTime += Time.deltaTime) > 1.0f)
            {
                if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale != 0)
                {
                    _shootTime = 0.0f;
                    Shoot();
                }
            }

            if (health <= 0)
            {
                // тут мог дергаться ивент на смерть рика и экран проигрыша
            }
        }
    }

    public void ReduceHp()
    {
        health -= 1;
        HpManager.instance.ShowHealth(health);
    }
}