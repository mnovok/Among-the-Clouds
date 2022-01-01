using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl2 : MonoBehaviour
{
    GameObject scoreUIText2GO;

    public GameObject ExplosionGO;

    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 15f; //pocetna brzina

        scoreUIText2GO = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; //trenutna pozicija

        position = new Vector2(position.x, position.y - speed * Time.deltaTime); //nova pozicija

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //unisti neprijatelja ako je izvan scene

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();

            scoreUIText2GO.GetComponent<GameScore>().Score += 25;

            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;
    }
}
