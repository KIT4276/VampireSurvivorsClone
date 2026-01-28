using System;

public interface IDamageble
{
    public event Action DamageTaken;

    void TakeDamage(int value);
}
