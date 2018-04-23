using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEffect : MonoBehaviour
{
    public Vector3 ManaType1Position;
    public Vector3 ManaType2Position;
    public int manaType;
	
	// Update is called once per frame
	void Update ()
    {
        if (manaType == 1)
        {
            transform.position = Vector3.Lerp(transform.position, ManaType1Position, .1f);

            if (Vector3.Distance(transform.position, ManaType1Position) <= .5f)
            {
                GameManager.Instance.UICanvas.GetComponent<InGameUIManager>().numManaType1++;
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, ManaType2Position, .1f);

            if (Vector3.Distance(transform.position, ManaType2Position) <= .5f)
            {
                GameManager.Instance.UICanvas.GetComponent<InGameUIManager>().numManaType2++;
                Destroy(gameObject);
            }
        }
    }
}
