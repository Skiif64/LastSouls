using UnityEngine;

[CreateAssetMenu(fileName ="New Damage Type", menuName ="Data/Damage/DamageType")]
public class DamageType : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Color _color;
    [SerializeField] private ResistanceType _resistanceType;

    public string Name => _name;
    public Color Color => _color;
    public ResistanceType ResistanceType => _resistanceType;
}
