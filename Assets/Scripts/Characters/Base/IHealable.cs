public interface IHealable
{
    public float CurrentHealth { get; }

    public void TakeHeal(float value);
}
