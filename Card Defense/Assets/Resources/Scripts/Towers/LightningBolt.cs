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
    private Vector3 towerOffset;
    private Vector3 enemyOffset;
    private LineRenderer line;
    private int startDelay = 0;
    private int destroyTimer = 0;
    private const float xOffsetMax = .5f;
    private const float yOffsetMax = .5f;

    #endregion

    // Use this for initialization
    void Start ()
    {
        line = GetComponent<LineRenderer>();
        startDelay = Random.Range(0, 16);
        destroyTimer = Random.Range(30, 61);

        if(startDelay == 0)
        {
            DrawLightningBolt();
        }

        towerOffset = Vector3.zero - startPosition;
        enemyOffset = Vector3.zero - endPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(startDelay > 0)
        {
            startDelay--;

            if(startDelay == 0)
            {
                DrawLightningBolt();
            }
        }

        if(destroyTimer > 0)
        {
            destroyTimer--;

            if(destroyTimer == 0)
            {
                Destroy(gameObject);
            }
        }
	}

    public void DrawLightningBolt()
    {
        linePoints.Add(startPosition);

        offsetPoint1 = new Vector3((enemyOffset.x * .25f) + enemyOffset.x, (enemyOffset.y * .25f) + enemyOffset.y, enemyOffset.z);
        offsetPoint2 = new Vector3((enemyOffset.x * .75f) + enemyOffset.x, (enemyOffset.y * .75f) + enemyOffset.y, enemyOffset.z);
        offsetPoint1 = SkewPoint(offsetPoint1);
        offsetPoint2 = SkewPoint(offsetPoint2);

        linePoints.Add(offsetPoint1);
        linePoints.Add(offsetPoint2);
        linePoints.Add(endPosition);

        line.SetPositions(linePoints.ToArray());
    }

    public Vector3 SkewPoint(Vector3 point)
    {
        int positiveOrNegative = Random.Range(-1, 2);

        point = new Vector3(positiveOrNegative * (point.x + Random.Range(0, xOffsetMax)), point.y, point.z);
        positiveOrNegative = Random.Range(-1, 2);
        point = new Vector3(point.x, positiveOrNegative * (point.y + Random.Range(0, yOffsetMax)), point.z);

        return point;
    }
}
