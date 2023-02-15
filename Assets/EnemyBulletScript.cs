using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private GameObject player;
    public float force;
    private float timer;
    PlayerController player2;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized *force;
        
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rot + 90);


        // damage increase by level
        damage *= Save.currLevel;

        // hardcore stack
        damage += (Save.hardcoreStack * 15);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >10){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            player2.TakeDamage(damage);
            Destroy(gameObject);
    
        }
    }
}
