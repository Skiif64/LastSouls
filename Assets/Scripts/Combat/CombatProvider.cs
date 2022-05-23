using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatProvider : MonoBehaviour
{
    [SerializeField] private Combat _combat;

    public void RecoverAttack()
    {
        _combat.RecoverAttack();
    }
}
