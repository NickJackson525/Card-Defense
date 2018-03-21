using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region Enums

public enum LevelNumber { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven }

public enum LevelElements
{
    NodePrefab, Node1, Node2, Node3, Node4, Node5, Node6, Node7, Node8, Node9, Node10,
    Node11, Node12, Node13, Node14, Node15, Node16, Node17, Node18, Node19, NumberOfNodes, Map, MapLocation, SpawnerLocation
}

#endregion

public class LevelSelectManager : MonoBehaviour
{
    #region Variables

    public Dictionary<LevelNumber, Dictionary<LevelElements, string>> LevelLibrary = new Dictionary<LevelNumber, Dictionary<LevelElements, string>>
    {
        #region Level One

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
                {LevelElements.NumberOfNodes, "19" },                  // position to move the spawner to for this map
                {LevelElements.SpawnerLocation, "-28.65,12.97,0" },    // position to move the spawner to for this map
            }
        },

        #endregion

        #region Level Two

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
            }
        },

        #endregion
    };

    public GameObject popupPanel;

    private GameObject mapPrefab;
    private GameObject nodePrefab;
    private GameObject createdNode;

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
        if (SceneManager.GetActiveScene().name == "Map 1")
        {
            LoadLevel(GameManager.Instance.currentLevel);
        }
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
		
	}

    #endregion

    #region Public Methods

    public void LevelInfoPanel(LevelNumber level)
    {
        //TODO: open info panel and populate it with this level's info (create method to call in infopanel.cs)
        //TODO: will have to add more elements to levellibrary, and add them to save() somehow
    }

    public void SelectLevel(LevelNumber level)
    {
        //TODO: make this method update the currently selected level, and load the "Map 1" scene, this will be called when the battle button is called
    }

    public void LoadLevel(LevelNumber level)
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
