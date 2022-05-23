/// <summary>
/// Информация об уроне
/// </summary>
public struct DamageInfo
{
    public readonly object Sender;
    public readonly float Value;
    public readonly DamageType Type;    

    public DamageInfo(object sender, float value, DamageType damageType)
    {
        Sender = sender;
        Value = value;
        Type = damageType;
        
    }
}
