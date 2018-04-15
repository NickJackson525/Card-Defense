using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortOrder : MonoBehaviour
{
    public GameObject parent;
    public int orderOffset;

    private int position;

	void Update ()
    {
        position = Mathf.RoundToInt(parent.transform.position.y);
        GetComponent<SpriteRenderer>().sortingOrder = (position * -1) + orderOffset;
    }
}
