using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject enemy;
    int timer = 120;

    private void Awake()
    {
        enemy = Resources.Load<GameObject>("Prefabs/Enemies/Monster1");
    }
	
	void Update ()
    {
        if (!GameManager.Instance.Paused)
        {
            if (timer > 0)
            {
                timer--;

                if (timer == 0)
                {
                    Instantiate(enemy, transform.position, transform.rotation);
                    timer = 120;
                }
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                Instantiate(enemy, transform.position, transform.rotation);
            }
        }
	}
}
