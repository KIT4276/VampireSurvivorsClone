using System;
using UnityEngine;

public class HeroDamageble : MonoBehaviour, IDamageble
{
    public event Action DamageTaken;

    public void TakeDamage(int value)
    {
       
    }
}
