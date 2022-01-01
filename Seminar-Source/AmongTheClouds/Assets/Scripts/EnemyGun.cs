using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGO;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyBullet()
    {
        //igraceva pozicija

        GameObject playerShip = GameObject.Find("PlayerGO");

        if(playerShip != null) //igrac je ziv
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
