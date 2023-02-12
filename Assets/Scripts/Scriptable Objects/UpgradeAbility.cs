using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Upgrade/UpgradeAbility", order = 1)]
public class UpgradeAbility : Upgrade
{
    public Ability ability;

    public override void Use() {
        base.Use();

        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        switch (ability) {
            case Ability.Flame:
                break;
            case Ability.Ice:
                break;
        }
    }

    public override void Remove()
    {
        base.Remove();

        // TODO: undo an instance of the effect of this ability
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        switch (ability) {
            case Ability.Flame:
                break;
            case Ability.Ice:
                break;
        }
    }

    public enum Ability{Flame, Ice};
}
