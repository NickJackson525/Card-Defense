using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : MonoBehaviour
{
    #region Variables

    public Vector3 startPosition;
    public Vector3 endPosition;

    private List<Vector3> linePoints = new List<Vector3>();
    private Vector3 offsetPoint1;
    private Vector3 offsetPoint2;
    private LineRenderer line;
    private int startDelay = 0;
    private int destroyTimer = 0;
    private const float xOffsetMax = .75f;
    private const float yOffsetMax = .75f;

    #endregion

    // Use this for initialization
    void Start ()
    {
        line = GetComponent<LineRenderer>();
        startDelay = Random.Range(0, 16);
        destroyTimer = Random.Range(16, 30);

        if(startDelay == 0)
        {
            DrawLightningBolt();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameManager.Instance.Paused)
        {
            if (startDelay > 0)
            {
                startDelay--;

                if (startDelay == 0)
                {
                    DrawLightningBolt();
                }
            }

            if (destroyTimer > 0)
            {
                destroyTimer--;

                if (destroyTimer == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
	}

    public void DrawLightningBolt()
    {
        Vector3 slopeVector = endPosition - startPosition;

        linePoints.Add(startPosition);

        offsetPoint1 = endPosition - (slopeVector * Random.Range(.2f, .3f));
        offsetPoint2 = endPosition - (slopeVector * Random.Range(.7f, .8f));
        SkewPoints();

        linePoints.Add(offsetPoint2);
        linePoints.Add(offsetPoint1);
        linePoints.Add(endPosition);

        line.SetPositions(linePoints.ToArray());
    }

    public void SkewPoints()
    {
        int positiveOrNegative = Random.Range(-1, 2);

        //50% chance to skew x values or y values
        if (Random.Range(0, 2) == 0)
        {
            //skew x values
            offsetPoint1 = new Vector3(offsetPoint1.x + (positiveOrNegative * Random.Range(0, xOffsetMax)), offsetPoint1.y, offsetPoint1.z);
            positiveOrNegative *= -1;
            offsetPoint2 = new Vector3(offsetPoint2.x + (positiveOrNegative * Random.Range(0, xOffsetMax)), offsetPoint2.y, offsetPoint2.z);
        }
        else
        {
            //skew y values
            offsetPoint1 = new Vector3(offsetPoint1.x, offsetPoint1.y + (positiveOrNegative * Random.Range(0, yOffsetMax)), offsetPoint1.z);
            positiveOrNegative *= -1;
            offsetPoint2 = new Vector3(offsetPoint2.x, offsetPoint2.y + (positiveOrNegative * Random.Range(0, yOffsetMax)), offsetPoint2.z);
        }
    }
}
