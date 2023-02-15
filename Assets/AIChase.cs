using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    GameObject player;
    PlayerController controller;
    private float distance;
    public float enemyMovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (distance > 0) {
                enemyMovementSpeed = controller.returnEnemyMovementSpeed();
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyMovementSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward *angle);
            }
        }
    }
}
