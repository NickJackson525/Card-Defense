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
                {EnemyType.Sheep, 30 },
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
                {EnemyType.SpikedSheep, 30 },
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
    private List<GameObject> waveEnemies = new List<GameObject>();
    private int primarySpawnTimer = 120;          // Used to delay when enemies are spawned

    #endregion

    #region Awake

    private void Awake()
    {
         EnemyList = new Dictionary<EnemyType, GameObject>
         {
            {EnemyType.Sheep, Resources.Load<GameObject>("Prefabs/Enemies/Sheep") },
            {EnemyType.SpikedSheep, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Ram, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
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
        if(waveEnemies.Count == 0)
        {
            currentWave++;

            GenerateWave();
        }

        //check that the game isn't paused
        if (!GameManager.Instance.Paused)
        {
            //check if the spawn timer is greater than 0
            if (primarySpawnTimer > 0)
            {
                //update spawn timer
                primarySpawnTimer--;

                //check if the timer is at 0, meaning another enemy can be spawned
                if (primarySpawnTimer == 0)
                {
                    //spawn enemy
                    Instantiate(waveEnemies[0], transform.position, transform.rotation);
                    waveEnemies.RemoveAt(0);

                    //reset timer
                    primarySpawnTimer = 120;
                }
            }
        }
	}

    #endregion

    #region Private Methods

    private void GenerateWave()
    {
        foreach (KeyValuePair<WaveNumber, Dictionary<EnemyType, int>> enemy in GrassMapWaveEnemies)
        {
            if (enemy.Key == currentWave)
            {
                for (int j = 0; j < 24; j++)
                {
                    int loopMax = enemy.Value[type];

                    for (int i = 0; i < loopMax; i++)
                    {
                        waveEnemies.Add(EnemyList[type]);
                    }

                    type++;
                }

                type = EnemyType.Sheep;
            }
        }
    }

    #endregion
}