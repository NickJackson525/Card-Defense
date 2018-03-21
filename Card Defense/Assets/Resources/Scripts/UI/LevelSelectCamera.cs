using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectCamera : MonoBehaviour
{
    #region Variables

    public GameObject leftClamp;
    public GameObject rightClamp;
    public GameObject moveLeftButton;
    public GameObject moveRightButton;

    #endregion

    #region Update

    // Update is called once per frame
    void Update ()
    {
        #region Scale Camera Clamps

        //5: 4 aspect ratio
        if (Camera.main.aspect == (5f / 4f))
        {
            leftClamp.transform.position = new Vector3(0, 0, -10);
            rightClamp.transform.position = new Vector3(110, 0, -10);
        }
        //4:3 aspect ratio
        else if (Camera.main.aspect == (4f / 3f))
        {
            leftClamp.transform.position = new Vector3(0, 0, -10);
            rightClamp.transform.position = new Vector3(110, 0, -10);
        }
        //3 : 2 aspect ratio
        else if (Camera.main.aspect == (3f / 2f))
        {
            leftClamp.transform.position = new Vector3(4, 0, -10);
            rightClamp.transform.position = new Vector3(106, 0, -10);
        }
        //16 : 10 aspect ratio
        else if (Camera.main.aspect == (16f / 10f))
        {
            leftClamp.transform.position = new Vector3(6.25f, 0, -10);
            rightClamp.transform.position = new Vector3(104, 0, -10);
        }
        //16 : 9 aspect ratio
        else if (Camera.main.aspect == (16f / 9f))
        {
            leftClamp.transform.position = new Vector3(10.5f, 0, -10);
            rightClamp.transform.position = new Vector3(100, 0, -10);
        }
        //default to 4:3 aspect ratio
        else
        {
            leftClamp.transform.position = new Vector3(0, 0, -10);
            rightClamp.transform.position = new Vector3(110, 0, -10);
        }

        #endregion

        #region Camera Movement

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || (Input.GetMouseButton(0) && moveLeftButton.GetComponent<CheckMouseHover>().mouseHover))
        {
            transform.Translate(Vector2.left * 30 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || (Input.GetMouseButton(0) && moveRightButton.GetComponent<CheckMouseHover>().mouseHover))
        {
            transform.Translate(Vector2.right * 30 * Time.deltaTime);
        }

        #endregion

        #region Clamp Camera

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftClamp.transform.position.x, rightClamp.transform.position.x), 
                                         Mathf.Clamp(transform.position.y, leftClamp.transform.position.y, rightClamp.transform.position.y), 
                                         Mathf.Clamp(transform.position.z, leftClamp.transform.position.z, rightClamp.transform.position.z));
        #endregion
    }

    #endregion
}
