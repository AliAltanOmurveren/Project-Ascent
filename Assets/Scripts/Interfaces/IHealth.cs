public interface IHealth{
    float MaxHp { get; set; }
    float CurrentHp { get; set; }

    void DecreaseHp(float amount);
    void IncreaseHp(float amount);
    void OnDeath();
}
