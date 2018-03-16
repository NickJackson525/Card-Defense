using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    #region Variables

    public Dictionary<LevelNumber, Dictionary<LevelElements, string>> LevelLibrary = new Dictionary<LevelNumber, Dictionary<LevelElements, string>>
    {
        #region Level One

        {
            LevelNumber.One, new Dictionary<LevelElements, string>
            {
                {LevelElements.Map, "Prefabls/Maps/GrassMap1" },       // path for resources.load to use to create the map
                {LevelElements.NodeObject, "Prefabs/Paths/PathNode" }, // path for resources.load to use to create nodes
                // TODO: get reference to the PathNodes gameobject and make it the parent for these nodes (https://answers.unity.com/questions/1134997/string-to-vector3.html)
                {LevelElements.Node, "-0.2318,0.128,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "0.1364,0.1285,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "0.1576,0.0979,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "0.139,0.0639,0" },               // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "0.0941,0.0592,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "0.0738,0.0266,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "0.029,0.044,0" },                // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "0.0104,0.0697,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "-0.016,0.0688,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "-0.0323,0.0459,0" },             // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "-0.0563,0.023,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "-0.0825,0.033,0" },              // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "-0.1072,0.0673,0" },             // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "-0.1362,0.0683,0" },             // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "-0.1552,0.0464,0" },             // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "-0.1856,0.0179,0" },             // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "-0.1894,-0.0096,0" },            // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "-0.1695,-0.0376,0" },            // position to create node at, will give them the count number in the creation loop
                {LevelElements.Node, "0.2413,-0.0343,0" },             // position to create node at, will give them the count number in the creation loop
                {LevelElements.Spawner, "-28.65,12.97,0" },            // position to move the spawner to for this map
            }
        },

        #endregion
    };

    public enum LevelNumber { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Eleven }
    public enum LevelElements { Map, NodeObject, Node, Spawner }

    #endregion

    #region Start

    // Use this for initialization
    void Start ()
    {
		
	}

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
		
	}

    #endregion
}
