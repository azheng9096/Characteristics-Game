using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float lifespanTime = 20f;
    public GameObject hitEffect;

    PlayerController player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        StartCoroutine(Lifespan(lifespanTime));
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            // damage visual effect
            GameObject effect = Instantiate (hitEffect, transform.position, Quaternion.identity);
            Destroy (effect, 5f);

            // take damage
            MonsterDamage enemy = other.GetComponent<MonsterDamage>();
            enemy.TakeDamage(player.atkPower);

            // ice effect
            if (player.iceStack > 0) {
                float duration = 1f * player.iceStack;

                AIChase chase = other.GetComponent<AIChase>();
                chase.TempReduceSpeed25(duration);
            }

            // flame effect
            if (player.flameStack > 0) {
                float duration = 3f;
                float dmg = 10f * player.flameStack;

                enemy.Ignite(dmg, duration);
            }

            Destroy (gameObject);
        }
    }

    IEnumerator Lifespan(float time) {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
