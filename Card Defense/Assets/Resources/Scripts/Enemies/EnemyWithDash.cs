using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWithDash : Enemy
{
    #region Variables

    private float dashSpeed;
    private int dashTimer = 180;
    private int dashCooldown = 180;
    private bool isDashing = true;

    #endregion

    #region Start

    protected override void Start()
    {
        base.Start();

        dashSpeed = naturalSpeed * 2;
    }

    #endregion

    #region Update

    protected override void Update ()
    {
        if (!GameManager.Instance.Paused)
        {
            base.Update();

            if((dashTimer > 0) && isDashing)
            {
                dashTimer--;

                currSpeed = dashSpeed;
                anim.speed = 2;

                if(dashTimer == 0)
                {
                    isDashing = false;
                    currSpeed = naturalSpeed;
                    anim.speed = 1;
                    dashTimer = 180;
                }
            }

            if((dashCooldown > 0) && !isDashing)
            {
                dashCooldown--;

                if(dashCooldown == 0)
                {
                    isDashing = true;
                    dashCooldown = 180;
                }
            }
        }
	}

    #endregion
}
