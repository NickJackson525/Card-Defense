using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SortOrder : MonoBehaviour
{
    public GameObject parent;
    public int orderOffset;

    private int position;

    void Update ()
    {
        position = Mathf.RoundToInt(parent.transform.position.y);
        GetComponent<SortingGroup>().sortingOrder = (position * -1) + orderOffset;
    }
}
