using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    private void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = 
                new Vector3(mousePos.x - startPosX,mousePos.y - startPosY,0);
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        startPosX = mousePos.x - this.transform.localPosition.x;
        startPosY = mousePos.y - this.transform.localPosition.y;
        
        isBeingHeld = true;
    }

    private void OnMouseUp()
    {
        
        isBeingHeld = false;
        if (!this.gameObject.CompareTag("oldNuc"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
