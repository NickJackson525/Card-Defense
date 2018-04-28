using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleportedEnemy;
    public Vector3 positionToTeleportTo;

	// Use this for initialization
	void Start ()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.Effects, Sound.teleport);

        teleportedEnemy.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, positionToTeleportTo, .1f);

        if (Vector3.Distance(transform.position, positionToTeleportTo) <= .5f)
        {
            teleportedEnemy.GetComponent<Enemy>().pathCount = 0;
            teleportedEnemy.transform.position = positionToTeleportTo;
            teleportedEnemy.SetActive(true);
            Destroy(gameObject);
        }
    }
}
