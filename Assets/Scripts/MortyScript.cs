using System.Collections.Generic;
using UnityEngine;

public class MortyScript : MonoBehaviour
{
    public int health = 3;
    public List<Sprite> sprites;

    public void ReduceHp()
    {
        health -= 1;
        if (health > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[health - 1];
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}