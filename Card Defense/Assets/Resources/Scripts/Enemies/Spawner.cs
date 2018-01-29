using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject enemy;

    private void Awake()
    {
        enemy = Resources.Load<GameObject>("Prefabs/Enemies/Enemy1");
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Q))
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
	}
}
