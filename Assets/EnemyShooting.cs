using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject monsterBullet;
    public Transform monsterBulletPos;
    public int damage;
    private float timer;

    PlayerController player;
    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            // playerHealth.TakeDamage(damage);
            player.TakeDamage(damage);
        }

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer >2){
            timer = 0;
            shoot();
        }
        
    }

    void shoot(){
        Instantiate(monsterBullet, monsterBulletPos.position, Quaternion.identity);
    }
}
