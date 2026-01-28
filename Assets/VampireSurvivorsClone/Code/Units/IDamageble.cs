using System;

public interface IDamageble
{
    public bool IsEnemy { get; }

    void TakeDamage(float value);
}
