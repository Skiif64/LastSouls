using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resistance Sheet", menuName = "Data/Damage/ResistanceSheet")]
public class ResistanceSheet : ScriptableObject
{
    [SerializeField] private List<Resistance> _resistances;
    public List<Resistance> ResistanceList => _resistances;

    public float GetResistanceValue(ResistanceType type)
    {
        float res = 0;
        res = _resistances.Find(x => x.Type==type).BaseValue;
        return res;
    }
}
