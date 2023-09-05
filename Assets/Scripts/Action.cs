using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAction", menuName = "Units/Action", order = 0)]
public class Action : ScriptableObject
{
    public string actionName;
    public int apCost;
    public float moveCost;
    public Object castFX;

    public int damage = 0;
    public int changeArmour = 0;
    public int changeMovement = 0;
    public float range = 20;

    [TextArea(3, 10)]
    public string description;

    public void PrepareAction(Controller character)
    {
        character.PrepareAction(this);
    }

    public void CancelAction(Controller character)
    {
        character.PrepareAction(null);
    }

    public void UseAction(Controller character, Vector3 castPos, Health target = null)
    {
        string message = "Used " + name + " action";

        if (target != null)
        {
            message += " on " + target.gameObject.name;
            castPos = target.transform.position;

            //TODO: Apply logic for action
            target.Hit(damage, changeArmour);
        }

        Debug.Log(message);

        //TODO: Spawn fx at cast pos
        Instantiate(castFX, castPos, new Quaternion(0, 0, 0, 0));

        character.UseAP(apCost);
        character.UseMovement(moveCost - changeMovement);
        character.PrepareAction(null);
    }
}
