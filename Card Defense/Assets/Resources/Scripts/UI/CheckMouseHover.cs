using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMouseHover : MonoBehaviour
{
    public bool mouseHover = false;

    private void OnMouseEnter()
    {
        mouseHover = true;
    }

    private void OnMouseExit()
    {
        mouseHover = false;
    }
}
