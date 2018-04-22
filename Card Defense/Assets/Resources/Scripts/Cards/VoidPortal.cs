using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidPortal : MonoBehaviour
{
    #region Variables

    public const int voidDeathChance = 8; // 1 out of 8 chance
    public const int voidTeleportChance = 1; // 100% chance
    public int damage;

    private int lifespanTimer = 120;

    #endregion

    #region Update

    private void Update()
    {
        lifespanTimer--;

        if(lifespanTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion
}