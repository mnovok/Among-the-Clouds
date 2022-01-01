using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed; //metak

    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        //pozicija metka
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyShipTag2"))
        {
            Destroy(gameObject);
        }
    }
}
