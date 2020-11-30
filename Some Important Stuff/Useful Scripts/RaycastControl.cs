using UnityEngine;
using UnityEngine.Audio;

public class RaycastControl : MonoBehaviour
{
    private GameObject targetObj;
    private Vector3 targetObjVect;
    

    public bool controlRcStatus = false; // send info to GameControl
   
    private void Update()
    {
        Release();
        
    }

    private void Release() // Release when align is True!
    {
        if (controlRcStatus == false) 
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit,
                Mathf.Infinity)) 
            {
                targetObj = hit.transform.gameObject;
                if (this.tag == "parentA" && targetObj.CompareTag("nucleoTimin")) {
                    TakeTargetObjectInside(targetObj);
                    controlRcStatus = true;
                }
                else if (this.tag == "parentT" && targetObj.CompareTag("nucleoAdenin")) {
                    TakeTargetObjectInside(targetObj);
                    controlRcStatus = true;
                }
                else if (this.tag == "parentG" && targetObj.CompareTag("nucleoSitozin")) {
                    TakeTargetObjectInside(targetObj);
                    controlRcStatus = true;
                }
                else if (this.tag == "parentS" && targetObj.CompareTag("nucleoGuanin")) {
                    TakeTargetObjectInside(targetObj);
                    controlRcStatus = true;
                }
            }
        }
    }

    private void TakeTargetObjectInside(GameObject _gameObject) // Make target object child of main parent game object and disable its click and drag ability
    {
        if (_gameObject.transform.tag=="nucleoSitozin")
        {
            _gameObject.transform.parent = this.transform.parent;
            _gameObject.transform.position = new Vector3(0.69f,this.transform.position.y,0);
            _gameObject.GetComponent<ClickAndDrag>().enabled = false;
            _gameObject.tag = "oldNuc";
        }
        else if (_gameObject.transform.tag == "nucleoGuanin")
        {
            _gameObject.transform.parent = this.transform.parent;
            _gameObject.transform.position = new Vector3(0.67f,this.transform.position.y,0);
            _gameObject.GetComponent<ClickAndDrag>().enabled = false;
            _gameObject.tag = "oldNuc";
        }
        else if (_gameObject.transform.tag == "nucleoAdenin")
        {
            _gameObject.transform.parent = this.transform.parent;
            _gameObject.transform.position = new Vector3(0.69f,this.transform.position.y,0);
            _gameObject.GetComponent<ClickAndDrag>().enabled = false;
            _gameObject.tag = "oldNuc";
        }
        else if (_gameObject.transform.tag == "nucleoTimin")
        {
            _gameObject.transform.parent = this.transform.parent;
            _gameObject.transform.position = new Vector3(0.69f,this.transform.position.y,0);
            _gameObject.GetComponent<ClickAndDrag>().enabled = false;
            _gameObject.tag = "oldNuc";
        }

        FindObjectOfType<AudioManager>()._AudioSource.PlayOneShot(FindObjectOfType<AudioManager>()._AudioSource.clip, FindObjectOfType<AudioManager>().volume);

    }
}