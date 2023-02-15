using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    GameObject player;
    public float speed;
    [SerializeField] GameObject SlowParticleEffect;
    public float minDistance = -1f;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (distance > minDistance) {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                // transform.rotation = Quaternion.Euler(Vector3.forward *angle);
            }
        }
    }

    // for ice ability
    IEnumerator TempReduceSpeed(float newSpeed, float duration) {
        // set new (slow) speed
        float origSpeed = speed;
        speed = newSpeed;

        // turn on particle animation
        SlowParticleEffect.SetActive(true);

        // wait for duration seconds
        yield return new WaitForSeconds(duration);

        // reset speed
        speed = origSpeed;

        // turn off particle animation
        SlowParticleEffect.SetActive(false);
    }

    // reduce speed by 25%
    public void TempReduceSpeed25(float duration) {
        StartCoroutine(TempReduceSpeed(speed * 0.75f, duration));
    }
}
