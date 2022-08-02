using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
        public Bullet bulletPrefab;
        public GameObject bulletParent;
        public float timeBetweenShots = 0.0f; //Seconds
        private float timer = 0.0f; //Seconds

        // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(Input.GetKey(KeyCode.UpArrow)) // Shoot Up
        {
            if(timer >= timeBetweenShots)
            {
                if(Input.GetKey(KeyCode.RightArrow)) //Shoot diagonally to top right
                {
                    Vector3 rightDiagonal = Vector3.up + Vector3.right;
                    SpawnBullet(rightDiagonal.normalized);
                } else if(Input.GetKey(KeyCode.LeftArrow)) 
                {
                    Vector3 leftDiagonal = Vector3.up + Vector3.left;
                    SpawnBullet(leftDiagonal.normalized);
                } else {
                    SpawnBullet(Vector3.up);
                }
            } 
        }

        if(Input.GetKey(KeyCode.DownArrow)) //Shoot down
        {
            if(timer >= timeBetweenShots)
            {
                if(Input.GetKey(KeyCode.RightArrow)) //Shoot diagonally to bottom right
                {
                    Vector3 rightDiagonal = Vector3.down + Vector3.right;
                    SpawnBullet(rightDiagonal.normalized);
                } else if(Input.GetKey(KeyCode.LeftArrow))
                {
                    Vector3 leftDiagonal = Vector3.down + Vector3.left;
                    SpawnBullet(leftDiagonal.normalized);
                } else {
                    SpawnBullet(Vector3.down);
                }
            }
        }


        if(Input.GetKey(KeyCode.LeftArrow)) //Shoot left
        {
            if(timer >= timeBetweenShots)
            {
                SpawnBullet(Vector3.left);
            }
        }

        if(Input.GetKey(KeyCode.RightArrow)) //Shoot right
        {
            if(timer >= timeBetweenShots)
            {
                SpawnBullet(Vector3.right);
            }
        }


        void SpawnBullet(Vector3 vector)
        {
            Bullet bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
            bullet.gameObject.name = "Bullet";
            bullet.transform.parent = bulletParent.transform;
            bullet.direction = vector;
            timer = 0.0f;

        }

    }
}

