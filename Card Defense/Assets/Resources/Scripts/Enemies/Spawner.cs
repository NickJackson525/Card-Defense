using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables

    private Dictionary<EnemyType, GameObject> EnemyList;

    private Dictionary<WaveNumber, Dictionary<EnemyType, int>> GrassMapWaveEnemies = new Dictionary<WaveNumber, Dictionary<EnemyType, int>>
    {
        #region Wave 1

        {
            WaveNumber.One, new Dictionary<EnemyType, int>
            {
                {EnemyType.Sheep, 20 },
                {EnemyType.SpikedSheep, 0 },
                {EnemyType.Ram, 0 },
                {EnemyType.Boar, 0 },
                {EnemyType.Pig, 0 },
                {EnemyType.Bull, 0 },
                {EnemyType.Goat, 0 },
                {EnemyType.Bat, 0 },
                {EnemyType.Bug, 0 },
                {EnemyType.Cyclops, 0 },
                {EnemyType.Minutaur, 0 },
                {EnemyType.Wolf, 0 },
                {EnemyType.Bee, 0 },
                {EnemyType.Spider, 0 },
                {EnemyType.Gazelle, 0 },
                {EnemyType.Werewolf, 0 },
                {EnemyType.FireImp, 0 },
                {EnemyType.WeakFireElemental, 0 },
                {EnemyType.StrongFireElemental, 0 },
                {EnemyType.FireBug, 0 },
                {EnemyType.FireDragon, 0 },
                {EnemyType.Bear, 0 },
                {EnemyType.Skeleton, 0 },
                {EnemyType.Treant, 0 },
            }
        },

        #endregion

        #region Wave 2

        {
            WaveNumber.Two, new Dictionary<EnemyType, int>
            {
                {EnemyType.Sheep, 20 },
                {EnemyType.SpikedSheep, 10 },
                {EnemyType.Ram, 0 },
                {EnemyType.Boar, 0 },
                {EnemyType.Pig, 0 },
                {EnemyType.Bull, 0 },
                {EnemyType.Goat, 0 },
                {EnemyType.Bat, 0 },
                {EnemyType.Bug, 0 },
                {EnemyType.Cyclops, 0 },
                {EnemyType.Minutaur, 0 },
                {EnemyType.Wolf, 0 },
                {EnemyType.Bee, 0 },
                {EnemyType.Spider, 0 },
                {EnemyType.Gazelle, 0 },
                {EnemyType.Werewolf, 0 },
                {EnemyType.FireImp, 0 },
                {EnemyType.WeakFireElemental, 0 },
                {EnemyType.StrongFireElemental, 0 },
                {EnemyType.FireBug, 0 },
                {EnemyType.FireDragon, 0 },
                {EnemyType.Bear, 0 },
                {EnemyType.Skeleton, 0 },
                {EnemyType.Treant, 0 },
            }
        },

        #endregion

        #region Wave 3

        {
            WaveNumber.Three, new Dictionary<EnemyType, int>
            {
                {EnemyType.Sheep, 40 },
                {EnemyType.SpikedSheep, 20 },
                {EnemyType.Ram, 0 },
                {EnemyType.Boar, 0 },
                {EnemyType.Pig, 0 },
                {EnemyType.Bull, 0 },
                {EnemyType.Goat, 0 },
                {EnemyType.Bat, 0 },
                {EnemyType.Bug, 0 },
                {EnemyType.Cyclops, 0 },
                {EnemyType.Minutaur, 0 },
                {EnemyType.Wolf, 0 },
                {EnemyType.Bee, 0 },
                {EnemyType.Spider, 0 },
                {EnemyType.Gazelle, 0 },
                {EnemyType.Werewolf, 0 },
                {EnemyType.FireImp, 0 },
                {EnemyType.WeakFireElemental, 0 },
                {EnemyType.StrongFireElemental, 0 },
                {EnemyType.FireBug, 0 },
                {EnemyType.FireDragon, 0 },
                {EnemyType.Bear, 0 },
                {EnemyType.Skeleton, 0 },
                {EnemyType.Treant, 0 },
            }
        },

        #endregion

        #region Wave 4

        {
            WaveNumber.Four, new Dictionary<EnemyType, int>
            {
                {EnemyType.Sheep, 40 },
                {EnemyType.SpikedSheep, 30 },
                {EnemyType.Ram, 20 },
                {EnemyType.Boar, 0 },
                {EnemyType.Pig, 0 },
                {EnemyType.Bull, 0 },
                {EnemyType.Goat, 0 },
                {EnemyType.Bat, 0 },
                {EnemyType.Bug, 0 },
                {EnemyType.Cyclops, 0 },
                {EnemyType.Minutaur, 0 },
                {EnemyType.Wolf, 0 },
                {EnemyType.Bee, 0 },
                {EnemyType.Spider, 0 },
                {EnemyType.Gazelle, 0 },
                {EnemyType.Werewolf, 0 },
                {EnemyType.FireImp, 0 },
                {EnemyType.WeakFireElemental, 0 },
                {EnemyType.StrongFireElemental, 0 },
                {EnemyType.FireBug, 0 },
                {EnemyType.FireDragon, 0 },
                {EnemyType.Bear, 0 },
                {EnemyType.Skeleton, 0 },
                {EnemyType.Treant, 0 },
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

    private enum WaveNumber { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten }
    private WaveNumber currentWave = WaveNumber.Zero;
    private EnemyType type = EnemyType.Sheep;
    private List<GameObject> spawnList1 = new List<GameObject>();
    private List<GameObject> spawnList2 = new List<GameObject>();
    private int SpawnTimer1 = 120;          // Used to delay when enemies are spawned
    private int SpawnTimer2 = 180;          // Used to delay when enemies are spawned
    private bool justAddedToList1 = false;

    #endregion

    #region Awake

    private void Awake()
    {
         EnemyList = new Dictionary<EnemyType, GameObject>
         {
            {EnemyType.Sheep, Resources.Load<GameObject>("Prefabs/Enemies/Sheep") },
            {EnemyType.SpikedSheep, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Ram, Resources.Load<GameObject>("Prefabs/Enemies/Ram") },
            {EnemyType.Boar, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Pig, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Bull, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Goat, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Bat, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Bug, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Cyclops, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Minutaur, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Wolf, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Bee, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Spider, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Gazelle, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Werewolf, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.FireImp, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.WeakFireElemental, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.StrongFireElemental, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.FireBug, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.FireDragon, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Bear, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Skeleton, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Treant, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
         };
    }

    #endregion

    #region Update

    void Update ()
    {
        //start the next wave when this one has ended and there are no more enemies on screen
        if((spawnList1.Count == 0) && (!GameObject.FindGameObjectWithTag("Enemy")))
        {
            //go to next wave
            currentWave++;

            //create the wave
            GenerateWave();
        }

        //check that the game isn't paused
        if (!GameManager.Instance.Paused)
        {
            //check if the spawn timer is greater than 0 and that there are enemies to spawn
            if ((SpawnTimer1 > 0) && (spawnList1.Count > 0))
            {
                //update spawn timer
                SpawnTimer1--;

                //check if the timer is at 0, meaning another enemy can be spawned
                if (SpawnTimer1 == 0)
                {
                    //spawn enemy
                    Instantiate(spawnList1[0], transform.position, transform.rotation);
                    spawnList1.RemoveAt(0);

                    //reset timer
                    SpawnTimer1 = 120;
                }
            }

            //check if the spawn timer is greater than 0 and that there are enemies to spawn
            if ((SpawnTimer2 > 0) && (spawnList2.Count > 0))
            {
                //update spawn timer
                SpawnTimer2--;

                //check if the timer is at 0, meaning another enemy can be spawned
                if (SpawnTimer2 == 0)
                {
                    //spawn enemy
                    Instantiate(spawnList2[0], transform.position, transform.rotation);
                    spawnList2.RemoveAt(0);

                    //reset timer
                    SpawnTimer2 = 120;
                }
            }
        }
	}

    #endregion

    #region Private Methods

    /// <summary>
    /// This method adds the enemies specified in a wave dictionary to the spawn list, so that they can be spawned in the level
    /// </summary>
    private void GenerateWave()
    {
        //loop through all the enemies specified in the wave dictionary
        foreach (KeyValuePair<WaveNumber, Dictionary<EnemyType, int>> enemy in GrassMapWaveEnemies)
        {
            //only check enemies from this wave
            if (enemy.Key == currentWave)
            {
                //loop through the elements of the enemylist enum
                for (int j = 0; j < 24; j++)
                {
                    int numEnemiesToAdd = enemy.Value[type];

                    //add the number and type of enemies specified to the waveenemies list
                    for (int i = 0; i < numEnemiesToAdd; i++)
                    {
                        if (currentWave > WaveNumber.Three)
                        {
                            if (justAddedToList1)
                            {
                                spawnList2.Add(EnemyList[type]);
                                justAddedToList1 = false;
                            }
                            else
                            {
                                spawnList1.Add(EnemyList[type]);
                                justAddedToList1 = true;
                            }
                        }
                        else
                        {
                            spawnList1.Add(EnemyList[type]);
                        }
                    }

                    //go to next type
                    type++;
                }

                //reset type
                type = EnemyType.Sheep;
            }
        }
    }

    #endregion
}