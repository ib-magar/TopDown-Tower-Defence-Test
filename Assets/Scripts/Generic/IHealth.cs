using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IHealth
{
    float CurrentHealth { get; }
    float MaxHealth { get; }

    void TakeDamage(float damage);
    void Heal(float amount);
    
}


