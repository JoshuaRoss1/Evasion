using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float enemySpeed = 0.0f;
    public Bullet bulletPrefab;
    private GameObject bulletParent;
    public GameObject coinPrefab;
    private GameObject player;
    [System.NonSerialized]
    public Vector3 direction = Vector3.zero; //Public so it can be accessed elsewhere (NonSerialized)
    public float timeToShoot = 0.0f;
    private float shotTimer = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;
        int timerSeconds = (int)shotTimer % 60; //Convert timer to Seconds

        player = GameObject.Find("Player");
        bulletParent = GameObject.Find("Bullets");
        
        if(timerSeconds == timeToShoot)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Vector3 bulletDirection = (player.transform.localPosition - transform.position).normalized;
            bullet.direction = bulletDirection; //Could be a redundant line, but im not sure so will leave in
            bullet.transform.parent = bulletParent.transform;
            
            shotTimer += 1.0f;
        }
        
        if(player == null) //If player is dead, don't shoot
        {
            shotTimer = timeToShoot + 1;
        }
        
        transform.Translate(direction * enemySpeed * Time.deltaTime); //Move Enemy
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        Destroy(collider.gameObject);
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}
