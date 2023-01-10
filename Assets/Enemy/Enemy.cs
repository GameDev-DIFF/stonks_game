using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;
    public bool enemyActive = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyActive)
        {
            if (player.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }
            else
            {
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            }

            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(new Vector3(transform.position.x, -9f, transform.position.z), player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = new Vector3(transform.position.x, -9f, transform.position.z);
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(new Vector3(transform.position.x, -9f, transform.position.z), player.position, -speed * Time.deltaTime);
            }


            if (timeBetweenShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBetweenShots = startTimeBtwShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        } 
    }
}
