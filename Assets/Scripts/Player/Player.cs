using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : LivingEntity
{
    protected override void Die()
    {
        
        Debug.Log("Player has died!");
        
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        UIManager.Instance.UpdateHealth(CurrentHealth);
    }

}
