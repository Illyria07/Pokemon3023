using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WinEffect", menuName = "ScriptableObjects/WinEffectScriptables", order = 3)]
public class WinEffectScriptable : ActionEffectScriptable
{
    public override void ApplyEffect(PartyDetails user, PartyDetails opponent)
    {
        if(Random.Range(0, 100) <= 5)
        {
            // win condition
        }
    }
}
