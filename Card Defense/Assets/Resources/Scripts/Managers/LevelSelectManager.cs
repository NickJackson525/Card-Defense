using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

#region Enums

public enum LevelNumber { One, Two }

public enum LevelElements
{
    NodePrefab, Node1, Node2, Node3, Node4, Node5, Node6, Node7, Node8, Node9, Node10,
    Node11, Node12, Node13, Node14, Node15, Node16, Node17, Node18, Node19, NumberOfNodes, Map, MapLocation, SpawnerLocation,
    Star1Unlocked, Star2Unlocked, Star3Unlocked, MapScreenshot, DifficultyCompleted, isLevelLocked
}

#endregion

public class LevelSelectManager : MonoBehaviour
{
    #region Variables

    public Dictionary<LevelNumber, Dictionary<LevelElements, string>> LevelLibrary = new Dictionary<LevelNumber, Dictionary<LevelElements, string>>
    {
        #region Level One (Grass Map 1)

        {
            LevelNumber.One, new Dictionary<LevelElements, string>
            {
                {LevelElements.Map, "Prefabs/Maps/GrassMap1" },        // path for resources.load to use to create the map
                {LevelElements.MapLocation, "-24.47,18.01,0" },        // where to place the map in the world
                {LevelElements.NodePrefab, "Prefabs/Paths/PathNode" }, // path for resources.load to use to create nodes
                {LevelElements.Node1, "-24.62875,13.08,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node2, "14.4925,13.13,0" },             // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node3, "16.745,10.07,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node4, "14.76875,6.670001,0" },         // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node5, "9.998126,6.2,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node6, "7.841251,2.94,0" },             // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node7, "3.08125,4.68,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node8, "1.105,7.25,0" },                // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node9, "-1.7,7.16,0" },                 // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node10, "-3.431875,4.87,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node11, "-5.981876,2.58,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node12, "-8.765627,3.58,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node13, "-11.39,7.01,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node14, "-14.47125,7.11,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node15, "-16.49,4.92,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node16, "-19.72,2.07,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node17, "-20.12375,-0.6800001,0" },     // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node18, "-18.00938,-3.48,0" },          // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node19, "25.63813,-3.15,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.NumberOfNodes, "19" },                  // total number of nodes for this map
                {LevelElements.SpawnerLocation, "-28.65,12.97,0" },    // position to move the spawner to for this map
                {LevelElements.Star1Unlocked, "False" },
                {LevelElements.Star2Unlocked, "False" },
                {LevelElements.Star3Unlocked, "False" },
                {LevelElements.MapScreenshot, "Sprites/UI/MapScreenshots/GrassMap1" },
                {LevelElements.DifficultyCompleted, "None" },
                {LevelElements.isLevelLocked, "False" }
            }
        },

        #endregion

        #region Level Two (Ice Map 1)

        {
            LevelNumber.Two, new Dictionary<LevelElements, string>
            {
                {LevelElements.Map, "Prefabs/Maps/SnowMap1" },        // path for resources.load to use to create the map
                {LevelElements.MapLocation, "-24.47,18.01,0" },        // where to place the map in the world
                {LevelElements.NodePrefab, "Prefabs/Paths/PathNode" }, // path for resources.load to use to create nodes
                {LevelElements.Node1, "-24.62875,13.08,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node2, "14.4925,13.13,0" },             // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node3, "16.745,10.07,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node4, "14.76875,6.670001,0" },         // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node5, "9.998126,6.2,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node6, "7.841251,2.94,0" },             // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node7, "3.08125,4.68,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node8, "1.105,7.25,0" },                // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node9, "-1.7,7.16,0" },                 // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node10, "-3.431875,4.87,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node11, "-5.981876,2.58,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node12, "-8.765627,3.58,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node13, "-11.39,7.01,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node14, "-14.47125,7.11,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node15, "-16.49,4.92,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node16, "-19.72,2.07,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node17, "-20.12375,-0.6800001,0" },     // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node18, "-18.00938,-3.48,0" },          // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node19, "25.63813,-3.15,0" },           // position to create node at, will give them the count number in the creation loop
                {LevelElements.NumberOfNodes, "19" },                  // position to move the spawner to for this map
                {LevelElements.SpawnerLocation, "-28.65,12.97,0" },    // position to move the spawner to for this map
                {LevelElements.Star1Unlocked, "False" },
                {LevelElements.Star2Unlocked, "False" },
                {LevelElements.Star3Unlocked, "False" },
                {LevelElements.MapScreenshot, "Sprites/UI/MapScreenshots/IceMap1" },
                {LevelElements.DifficultyCompleted, "None" },
                {LevelElements.isLevelLocked, "True" }
            }
        },

        #endregion
    };

    public GameObject infoPopup;

    private GameObject mapPrefab;
    private GameObject nodePrefab;
    private GameObject createdNode;

    #endregion

    #region Singleton Constructor

    // create variable for storing singleton that any script can access
    private static LevelSelectManager instance;

    // create LevelSelectManager
    private LevelSelectManager()
    {
        
    }

    // Property for Singleton
    public static LevelSelectManager Instance
    {
        get { return instance ?? (instance = new LevelSelectManager()); }
    }

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        if (SceneManager.GetActiveScene().name == "Map 1")
        {
            CreateLevel(GameManager.Instance.currentLevel);
        }
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        if ((SceneManager.GetActiveScene().name != "Level Select") && (gameObject.name == "Level Icons"))
        {
            gameObject.SetActive(false);
        }
        else if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
	}

    #endregion

    #region Public Methods

    public void LevelInfoPanel(int level)
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);
        infoPopup.SetActive(true);
        infoPopup.GetComponent<InfoPanel>().title.text = "Level " + ((int)level + 1);
        infoPopup.GetComponent<InfoPanel>().mapScreenshot.sprite = Resources.Load<Sprite>(Instance.LevelLibrary[(LevelNumber)level][LevelElements.MapScreenshot]);

        #region Check Star 1

        if (bool.Parse(Instance.LevelLibrary[(LevelNumber)level][LevelElements.Star1Unlocked]))
        {
            infoPopup.GetComponent<InfoPanel>().star1.color = Color.white;
        }
        else
        {
            infoPopup.GetComponent<InfoPanel>().star1.color = Color.black;
        }

        #endregion

        #region Check Star 2

        if (bool.Parse(Instance.LevelLibrary[(LevelNumber)level][LevelElements.Star2Unlocked]))
        {
            infoPopup.GetComponent<InfoPanel>().star2.color = Color.white;
        }
        else
        {
            infoPopup.GetComponent<InfoPanel>().star2.color = Color.black;
        }

        #endregion

        #region Check Star 3

        if (bool.Parse(Instance.LevelLibrary[(LevelNumber)level][LevelElements.Star3Unlocked]))
        {
            infoPopup.GetComponent<InfoPanel>().star3.color = Color.white;
        }
        else
        {
            infoPopup.GetComponent<InfoPanel>().star3.color = Color.black;
        }

        #endregion

        #region Check Crown

        if (Instance.LevelLibrary[(LevelNumber)level][LevelElements.DifficultyCompleted] == "Bronze")
        {
            infoPopup.GetComponent<InfoPanel>().difficultyCrown.sprite = infoPopup.GetComponent<InfoPanel>().bronzeCrown;
            infoPopup.GetComponent<InfoPanel>().difficultyCrown.color = Color.white;
        }
        else if (Instance.LevelLibrary[(LevelNumber)level][LevelElements.DifficultyCompleted] == "Silver")
        {
            infoPopup.GetComponent<InfoPanel>().difficultyCrown.sprite = infoPopup.GetComponent<InfoPanel>().silverCrown;
            infoPopup.GetComponent<InfoPanel>().difficultyCrown.color = Color.white;
        }
        else if (Instance.LevelLibrary[(LevelNumber)level][LevelElements.DifficultyCompleted] == "Gold")
        {
            infoPopup.GetComponent<InfoPanel>().difficultyCrown.sprite = infoPopup.GetComponent<InfoPanel>().goldCrown;
            infoPopup.GetComponent<InfoPanel>().difficultyCrown.color = Color.white;
        }
        else
        {
            infoPopup.GetComponent<InfoPanel>().difficultyCrown.color = Color.black;
        }

        #endregion

        GameManager.Instance.currentLevel = (LevelNumber)level;
    }

    public void ClosePopup()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);
        infoPopup.SetActive(false);
    }
    
    public void SelectLevel()
    {
        AudioManager.Instance.PlaySound(AudioSourceType.UI, Sound.ButtonClick);
        AudioManager.Instance.PlayInGameBackgroundMusic();
        SceneManager.LoadScene("Map 1");
    }

    public void CreateLevel(LevelNumber level)
    {
        //delete old level
        DeleteCurrentLevel();

        //get references
        mapPrefab = Resources.Load<GameObject>(LevelLibrary[level][LevelElements.Map]);
        nodePrefab = Resources.Load<GameObject>(LevelLibrary[level][LevelElements.NodePrefab]);

        //create map
        Instantiate(mapPrefab, GetVector3FromString(LevelLibrary[level][LevelElements.MapLocation]), transform.rotation);

        //create nodes
        for(int i = 1; i < int.Parse(LevelLibrary[level][LevelElements.NumberOfNodes]) + 1; i++)
        {
            createdNode = Instantiate(nodePrefab, GetVector3FromString(LevelLibrary[level][(LevelElements)i]), Quaternion.identity);
            createdNode.GetComponent<PathNode>().nodeNumber = i;
        }

        //move spawner
        GameObject.FindGameObjectWithTag("Spawner").transform.position = GetVector3FromString(LevelLibrary[level][LevelElements.SpawnerLocation]);
    }

    public void SaveLevelInfo()
    {
        int index = 0;
        AllLevels allLevels;
        LevelData[] levelData = new LevelData[Enum.GetNames(typeof(LevelNumber)).Length];
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/LevelInfo.dat", FileMode.OpenOrCreate);

        foreach(KeyValuePair<LevelNumber, Dictionary<LevelElements, string>> level in LevelLibrary)
        {
            levelData[index] = new LevelData(bool.Parse(level.Value[LevelElements.Star1Unlocked]), 
                                             bool.Parse(level.Value[LevelElements.Star2Unlocked]), 
                                             bool.Parse(level.Value[LevelElements.Star3Unlocked]), 
                                             level.Value[LevelElements.DifficultyCompleted],
                                             level.Key);

            index++;
        }

        allLevels = new AllLevels(levelData);

        formatter.Serialize(file, allLevels);
        file.Close();
    }

    public void LoadLevelInfo()
    {
        if (File.Exists(Application.persistentDataPath + "/LevelInfo.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/LevelInfo.dat", FileMode.Open);
            AllLevels data = (AllLevels)formatter.Deserialize(file);

            foreach(LevelData levelInfo in data.levelData)
            {
                LevelLibrary[levelInfo.level][LevelElements.Star1Unlocked] = levelInfo.star1Unlocked.ToString();
                LevelLibrary[levelInfo.level][LevelElements.Star2Unlocked] = levelInfo.star2Unlocked.ToString();
                LevelLibrary[levelInfo.level][LevelElements.Star3Unlocked] = levelInfo.star3Unlocked.ToString();
                LevelLibrary[levelInfo.level][LevelElements.DifficultyCompleted] = levelInfo.difficultyCompleted;
            }

            file.Close();
        }
        else
        {
            SaveLevelInfo();
        }
    }

    #endregion

    #region Private Methods

    private void DeleteCurrentLevel()
    {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag("PathNode");

        foreach(GameObject node in nodes)
        {
            Destroy(node);
        }

        if (GameObject.FindGameObjectWithTag("Map"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Map"));
        }
    }

    private Vector3 GetVector3FromString(string stringVector)
    {
        if (stringVector.StartsWith("(") && stringVector.EndsWith(")"))
        {
            stringVector = stringVector.Substring(1, stringVector.Length - 2);
        }

        // split the items
        string[] stringArray = stringVector.Split(',');

        // return result
        return new Vector3(float.Parse(stringArray[0]), float.Parse(stringArray[1]), float.Parse(stringArray[2]));
    }

    #endregion
}

#region Level Data Classes

[Serializable]
class LevelData
{
    public LevelNumber level;
    public bool star1Unlocked;
    public bool star2Unlocked;
    public bool star3Unlocked;
    public string difficultyCompleted;

    public LevelData(bool s1Unlocked, bool s2Unlocked, bool s3Unlocked, string difficulty, LevelNumber levelNumber)
    {
        level = levelNumber;
        star1Unlocked = s1Unlocked;
        star2Unlocked = s2Unlocked;
        star3Unlocked = s3Unlocked;
        difficultyCompleted = difficulty;
    }
}

[Serializable]
class AllLevels
{
    public LevelData[] levelData;

    public AllLevels(LevelData[] data)
    {
        levelData = data;
    }
}

#endregion