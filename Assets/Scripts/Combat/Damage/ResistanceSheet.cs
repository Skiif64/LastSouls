using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Resistance Sheet", menuName = "Data/Damage/ResistanceSheet")]
public class ResistanceSheet : ScriptableObject
{
    [SerializeField] private List<Resistance> _resistances;
    public List<Resistance> ResistanceList => _resistances;
}
