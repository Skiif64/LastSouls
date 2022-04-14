using UnityEngine;

[CreateAssetMenu(fileName = "New Resistance", menuName = "Data/Damage/Resistance")]
public class Resistance : ScriptableObject
{
    [SerializeField] private ResistanceType _type;
    [SerializeField] private float _baseValue;

    public ResistanceType Type => _type;
    public float BaseValue => _baseValue;
}
