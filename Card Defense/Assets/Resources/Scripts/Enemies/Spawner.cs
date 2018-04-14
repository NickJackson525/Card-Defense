using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Enums

public enum WaveNumber { Zero, One, Two, Three, Four, Five }

#endregion

public class Spawner : MonoBehaviour
{
    #region Variables

    private Dictionary<EnemyType, GameObject> EnemyList;

    private Dictionary<LevelNumber, Dictionary<WaveNumber, List<int>>> MapLibrary = new Dictionary<LevelNumber, Dictionary<WaveNumber, List<int>>>
    {
        #region Grass Map 1

        {
            LevelNumber.One, new Dictionary<WaveNumber, List<int>>
            {
                #region Wave 1

                {
                    WaveNumber.One, new List<int>
                    {
                        {(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},
                        {(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},
                        {(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},
                        {(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},
                    }
                },

                #endregion

                #region Wave 2

                {
                    WaveNumber.Two, new List<int>
                    {
                        {(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.SpikedSheep},
                        {(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.SpikedSheep},
                        {(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.SpikedSheep},
                        {(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.SpikedSheep},
                        {(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.SpikedSheep},
                        {(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.Sheep},{(int)EnemyType.SpikedSheep},
                    }
                },

                #endregion

                #region Wave 3

                {
                    WaveNumber.Three, new List<int>
                    {
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},
                    }
                },

                #endregion

                #region Wave 4

                {
                    WaveNumber.Four, new List<int>
                    {
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                    }
                },

                #endregion

                #region Wave 5

                {
                    WaveNumber.Five, new List<int>
                    {
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.Bat},{(int)EnemyType.Bat},{(int)EnemyType.Bat},{(int)EnemyType.Bat},{(int)EnemyType.Bat},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.Bat},{(int)EnemyType.Bat},{(int)EnemyType.Bat},{(int)EnemyType.Bat},{(int)EnemyType.Bat},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.SpikedSheep},{(int)EnemyType.Ram},
                        {(int)EnemyType.Bat},{(int)EnemyType.Bat},{(int)EnemyType.Bat},{(int)EnemyType.Bat},{(int)EnemyType.Bat},
                    }
                },

                #endregion
            }
        },

        #endregion

        #region Winter Map 1

        {
            LevelNumber.Two, new Dictionary<WaveNumber, List<int>>
            {
                #region Wave 1

                {
                    WaveNumber.One, new List<int>
                    {
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},
                    }
                },

                #endregion

                #region Wave 2

                {
                    WaveNumber.Two, new List<int>
                    {
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                    }
                },

                #endregion

                #region Wave 3

                {
                    WaveNumber.Three, new List<int>
                    {
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},
                    }
                },

                #endregion

                #region Wave 4

                {
                    WaveNumber.Four, new List<int>
                    {
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Bear},
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Bear},
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Bear},
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Bear},
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Bear},
                        {(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Goat},{(int)EnemyType.Bear},
                    }
                },

                #endregion

                #region Wave 5

                {
                    WaveNumber.Five, new List<int>
                    {
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Bat},{(int)EnemyType.Bear},{(int)EnemyType.Bat},{(int)EnemyType.Bear},{(int)EnemyType.Bat},
                        {(int)EnemyType.Bear},{(int)EnemyType.Bat},{(int)EnemyType.Bear},{(int)EnemyType.Bat},{(int)EnemyType.Bear},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Bat},{(int)EnemyType.Bear},{(int)EnemyType.Bat},{(int)EnemyType.Bear},{(int)EnemyType.Bat},
                        {(int)EnemyType.Bear},{(int)EnemyType.Bat},{(int)EnemyType.Bear},{(int)EnemyType.Bat},{(int)EnemyType.Bear},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Wolf},{(int)EnemyType.Goat},
                        {(int)EnemyType.Bat},{(int)EnemyType.Bear},{(int)EnemyType.Bat},{(int)EnemyType.Bear},{(int)EnemyType.Bat},
                        {(int)EnemyType.Bear},{(int)EnemyType.Bat},{(int)EnemyType.Bear},{(int)EnemyType.Bat},{(int)EnemyType.Bear},
                    }
                },

                #endregion
            }
        },

        #endregion
    };

    private enum EnemyType
    {
        #region Basic Enemies

        Sheep, Ram, Boar, Pig, Bull, Bat, Bug, Cyclops, Minutaur, Bee, Spider, Gazelle, Werewolf,

        #endregion

        #region Fire Resistant Enemies

        FireImp, WeakFireElemental, StrongFireElemental, FireBug, FireDragon,

        #endregion

        #region Ice Resistant Enemies

        Wolf, Goat, Bear,

        #endregion

        #region Lightning Resistant Enemies

        SpikedSheep, Skeleton,

        #endregion

        #region Void Resistant Enemies

        Treant,

        #endregion
    }

    private EnemyType type = EnemyType.Sheep;
    private List<GameObject> spawnList1 = new List<GameObject>();
    private List<GameObject> spawnList2 = new List<GameObject>();
    private int SpawnTimer1 = 120;          // Used to delay when enemies are spawned
    private int SpawnTimer2 = 180;          // Used to delay when enemies are spawned

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
            {EnemyType.Goat, Resources.Load<GameObject>("Prefabs/Enemies/Goat") },
            {EnemyType.Bat, Resources.Load<GameObject>("Prefabs/Enemies/Bat") },
            {EnemyType.Bug, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Cyclops, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Minutaur, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Wolf, Resources.Load<GameObject>("Prefabs/Enemies/Wolf") },
            {EnemyType.Bee, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Spider, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Gazelle, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Werewolf, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.FireImp, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.WeakFireElemental, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.StrongFireElemental, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.FireBug, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.FireDragon, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Bear, Resources.Load<GameObject>("Prefabs/Enemies/Bear") },
            {EnemyType.Skeleton, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
            {EnemyType.Treant, Resources.Load<GameObject>("Prefabs/Enemies/SpikedSheep") },
         };
    }

    #endregion

    #region Update

    void Update()
    {
        //start the next wave when this one has ended and there are no more enemies on screen
        if ((spawnList1.Count == 0) && (!GameObject.FindGameObjectWithTag("Enemy")))
        {
            if (!GameManager.Instance.endGamePopup.activeSelf && (((int)GameManager.Instance.currentWave + 1) == Enum.GetNames(typeof(WaveNumber)).Length))
            {
                GameManager.Instance.Paused = true;
                GameManager.Instance.endGamePopup.SetActive(true);
                GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().title.text = "Victory!";
                LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel + 1][LevelElements.isLevelLocked] = "False";

                if (GameManager.Instance.baseHealth == 100)
                {
                    LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel][LevelElements.Star1Unlocked] = "True";
                    LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel][LevelElements.Star2Unlocked] = "True";
                    LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel][LevelElements.Star3Unlocked] = "True";
                    GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().star1.color = Color.white;
                    GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().star2.color = Color.white;
                    GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().star3.color = Color.white;
                    GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().xpGainText.text = "250";
                    GameManager.Instance.currentXP += 250;
                }
                else if (GameManager.Instance.baseHealth > 50)
                {
                    LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel][LevelElements.Star1Unlocked] = "True";
                    LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel][LevelElements.Star2Unlocked] = "True";
                    GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().star1.color = Color.white;
                    GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().star2.color = Color.white;
                    GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().xpGainText.text = "125";
                    GameManager.Instance.currentXP += 125;
                }
                else
                {
                    LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel][LevelElements.Star1Unlocked] = "True";
                    GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().star1.color = Color.white;
                    GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().xpGainText.text = "50";
                    GameManager.Instance.currentXP += 50;
                }

                switch (GameManager.Instance.currenfDifficulty)
                {
                    case Difficulty.Easy:
                        LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel][LevelElements.DifficultyCompleted] = "Bronze";
                        GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().difficultyCrown.sprite = GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().bronzeCrown;
                        break;
                    case Difficulty.Medium:
                        LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel][LevelElements.DifficultyCompleted] = "Silver";
                        GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().difficultyCrown.sprite = GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().silverCrown;
                        break;
                    case Difficulty.Hard:
                        LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel][LevelElements.DifficultyCompleted] = "Gold";
                        GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().difficultyCrown.sprite = GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().goldCrown;
                        break;
                    default:
                        LevelSelectManager.Instance.LevelLibrary[GameManager.Instance.currentLevel][LevelElements.DifficultyCompleted] = "Bronze";
                        GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().difficultyCrown.sprite = GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().bronzeCrown;
                        break;
                }

                GameManager.Instance.endGamePopup.GetComponent<EndGamePopup>().difficultyCrown.color = Color.white;

                LevelSelectManager.Instance.SaveLevelInfo();
                LevelSelectManager.Instance.LoadLevelInfo();
            }
            else
            {
                //go to next wave
                GameManager.Instance.currentWave++;

                //create the wave
                GenerateWave(MapLibrary[GameManager.Instance.currentLevel]);
            }
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
    private void GenerateWave(Dictionary<WaveNumber, List<int>> Map)
    {
        //loop through all the enemies specified in the wave dictionary
        foreach (KeyValuePair<WaveNumber, List<int>> wave in Map)
        {
            //only check enemies from this wave
            if (wave.Key == GameManager.Instance.currentWave)
            {
                foreach (int enemy in wave.Value)
                {
                    spawnList1.Add(EnemyList[(EnemyType)enemy]);
                }

            }
        }
    }

    #endregion
}