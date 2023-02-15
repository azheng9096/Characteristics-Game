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
            GameObject effect = Instantiate (hitEffect, transform.position, Quaternion.identity);
            Destroy (effect, 5f);

            MonsterDamage enemy = other.GetComponent<MonsterDamage>();
            enemy.TakeDamage(player.atkPower);

            Destroy (gameObject);
        }
    }

    IEnumerator Lifespan(float time) {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
