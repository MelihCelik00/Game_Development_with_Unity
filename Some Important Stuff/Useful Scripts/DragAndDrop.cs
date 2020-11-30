using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    private Vector3 mouseOffSet;
    private float mouseZCoord;
    
    
    private void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffSet = gameObject.transform.position - mouseWorldPos();
    }
    
    private Vector3 mouseWorldPos()
    {
        //pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;
        
        //z coordinate of game object on screen but its not important in our 2d game. Its extra!
        mousePoint.z = mouseZCoord;

        return Camera.main.WorldToScreenPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = mouseWorldPos() + mouseOffSet;
    }
}
