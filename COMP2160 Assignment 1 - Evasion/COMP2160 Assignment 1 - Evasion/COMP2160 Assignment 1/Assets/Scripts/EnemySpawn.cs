using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemyMove enemyPrefab;
    private float spawnRate; //Seconds
    private float spawnTimer = 0.0f;
    int i = 0;


    void Start()
    {
        spawnRate = Random.Range(4.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnRate)
        {
            if(this.gameObject.name == "Enemy Spawner Left")
            {
                SpawnEnemyHorizontal(Vector3.right, 4.5f, -1);
                spawnRate -= 0.3f;
                spawnTimer = 0.0f;
            }

            if(this.gameObject.name == "Enemy Spawner Right")
            {
                SpawnEnemyHorizontal(Vector3.left, 4.5f, 1);
                spawnRate -= 0.3f;
                spawnTimer = 0.0f;
            }

            if(this.gameObject.name == "Enemy Spawner Top")
            {
                SpawnEnemyVertical(Vector3.down, 10.0f, 1);
                spawnRate -= 0.3f;
                spawnTimer = 0.0f;
            }

            if(this.gameObject.name == "Enemy Spawner Bottom")
            {
                SpawnEnemyVertical(Vector3.up, 10.0f, -1);
                spawnRate -= 0.3f;
                spawnTimer = 0.0f;
            }
        }

        if(spawnRate < 0)
        {
            spawnRate = 1.0f;
        }
    }

    void SpawnEnemyHorizontal(Vector3 direction, float y, int reverse)
    {
        float zRotation = 0;
        EnemyMove enemy = Instantiate(enemyPrefab);
        enemy.transform.position = transform.position;
        
        //Move enemy to a random Y location.. Varies spawn location
        enemy.transform.position = new Vector3(enemy.transform.position.x, Random.Range(-y, y), 0); 

        if(enemy.transform.position.y > 0) //Slanting enemy direction
        {
            zRotation = Random.Range(3.0f, 10.0f) * reverse;  //Was unsure about how to calculate this
        } else {
            zRotation = Random.Range(-10.0f, -5.0f) * reverse;
        }
        enemy.transform.localRotation = Quaternion.Euler(0,0,zRotation); 
        enemy.direction = direction;

        enemy.transform.Translate(direction * enemy.enemySpeed * Time.deltaTime);
        enemy.transform.parent = transform;
    }

    void SpawnEnemyVertical(Vector3 direction, float x, int reverse)
    {
        float zRotation = 0;
        EnemyMove enemy = Instantiate(enemyPrefab);
        enemy.transform.position = this.transform.position;

        //Move enemies X location, Varies spawn location
        enemy.transform.position = new Vector3(Random.Range(-x, x), enemy.transform.position.y, 0); 

        if(enemy.transform.position.x > 0)
        {
            zRotation = Random.Range(-40.0f, 47.0f) * reverse;
            
        } else {
            zRotation = Random.Range(-48.0f, 20.0f) * reverse;
        }
        enemy.transform.localRotation = Quaternion.Euler(0,0,zRotation); 
        enemy.direction = direction;

        enemy.transform.Translate(direction * enemy.enemySpeed * Time.deltaTime);
        enemy.transform.parent = transform;
    }
    
    

    
}
