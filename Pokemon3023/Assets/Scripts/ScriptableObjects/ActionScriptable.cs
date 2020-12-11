using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Action", menuName = "ScriptableObjects/ActionScriptables/Action", order = 1)]
public class ActionScriptable : ScriptableObject
{
    public string abilityName;
    List<ActionEffectScriptable> effects;

    public void UseAbility(PartyDetails user, PartyDetails opponent)
    {
        foreach (ActionEffectScriptable eff in effects)
        {

        }
    }
}
