using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public float health = 100;
    
    PlayerController damages;

    PlayerController player;
    ColoredFlash flash;
    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        flash = GetComponent<ColoredFlash>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            player.TakeDamage(damage);
        }
    }

    public void TakeDamage(float dmg) {
        flash.Flash(Color.red);
        health -= dmg;

        if (health <= 0) {
            Die();
        }
    }

    public void Die() // made public for debugging purposes
    {
        GameOverUI.instance.DeductEnemyCount();
        Destroy(gameObject);
    }
}
