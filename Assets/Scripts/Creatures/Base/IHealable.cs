public interface IHealable
{
    public float Health { get; }

    public void TakeHeal(float value);
}
