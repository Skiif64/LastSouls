using UnityEngine;

[System.Serializable]
public class Resistance
{
    [SerializeField] private ResistanceType _type;
    [SerializeField] private float _baseValue;

    public ResistanceType Type => _type;
    public float BaseValue => _baseValue;
}
