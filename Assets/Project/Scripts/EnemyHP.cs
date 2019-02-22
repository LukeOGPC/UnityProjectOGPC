using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHP : MonoBehaviour
{
    public int currentHP;
    public void Damage(int damageAmount)
    {
        currentHP -= damageAmount;
        if (currentHP <= 0)
        {
            GameObject.Destroy(this.gameObject);
   
        }
    }
}
