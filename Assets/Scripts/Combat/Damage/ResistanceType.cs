using UnityEngine;

[CreateAssetMenu(fileName = "New Resistance Type", menuName = "Data/Damage/ResistanceType")]
public class ResistanceType : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    public string Name => _name;
    public Sprite Icon => _icon;
    
}
