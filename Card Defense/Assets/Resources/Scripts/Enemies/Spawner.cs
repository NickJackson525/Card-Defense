using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables

    private Dictionary<WaveNumber, Dictionary<EnemyType, int>> WaveEnemies = new Dictionary<WaveNumber, Dictionary<EnemyType, int>>
    {
        #region Wave 1

        {
            WaveNumber.One, new Dictionary<EnemyType, int>
            {
                {EnemyType.Sheep, 5 },
                {EnemyType.SpikedSheep, 0 },
            }
        },

        #endregion
    };

    private enum EnemyType
    {
        #region Basic Enemies

        Sheep, SpikedSheep, Ram, Boar, Pig, Bull, Goat, Bat, Bug, Cyclops, Minutaur, Wolf, Bee, Spider, Gazelle, Werewolf,

        #endregion

        #region Fire Resistant Enemies

        FireImp, WeakFireElemental, StrongFireElemental, FireBug, FireDragon,

        #endregion

        #region Ice Resistant Enemies

        Bear,

        #endregion

        #region Lightning Resistant Enemies

        Skeleton,

        #endregion

        #region Void Resistant Enemies

        Treant,

        #endregion
    }
    private enum WaveNumber { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten }
    private WaveNumber currentWave = WaveNumber.One;
    private GameObject Sheep; // Used to spawn sheeps in the world
    private int timer = 120;          // Used to delay when enemies are spawned

    #endregion

    #region Awake

    private void Awake()
    {
        //get references
        Sheep = Resources.Load<GameObject>("Prefabs/Enemies/Monster1");
    }

    #endregion

    #region Update

    void Update ()
    {
        //check that the game isn't paused
        if (!GameManager.Instance.Paused)
        {
            //check if the spawn timer is greater than 0
            if (timer > 0)
            {
                //update spawn timer
                timer--;

                //check if the timer is at 0, meaning another enemy can be spawned
                if (timer == 0)
                {
                    //spawn enemy
                    Instantiate(Sheep, transform.position, transform.rotation);

                    //reset timer
                    timer = 120;
                }
            }
        }
	}

    #endregion
}