using UnityEngine;

[CreateAssetMenu(fileName = "New Resistance Type", menuName = "Data/Damage/ResistanceType")]
public class ResistanceType : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name => _name;
    
}
