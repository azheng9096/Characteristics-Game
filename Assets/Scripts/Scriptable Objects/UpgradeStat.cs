using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Upgrade/UpgradeStat", order = 1)]
public class UpgradeStat : Upgrade
{
    public float hp;
    public float maxHP;
    public float atkPower;
    public float atkSpd;
    public float movementSpeed;

    public override void Use()
    {
        base.Use();

        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        player.RestoreHealth(hp);
        player.ChangeMaxHealth(maxHP);
        player.atkPower += atkPower;
        player.atkSpeed += atkSpd;
        player.movementSpeed += movementSpeed;
    }

    public override void Remove()
    {
        base.Remove();

        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        player.TakeDamage(hp);
        player.ChangeMaxHealth(-1 * maxHP);
        player.atkPower -= atkPower;
        player.atkSpeed -= atkSpd;
        player.movementSpeed -= movementSpeed;
    }
}
