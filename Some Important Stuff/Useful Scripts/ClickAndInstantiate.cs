using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class ClickAndInstantiate : MonoBehaviour
{
    private GameObject adenin;
    private GameObject thymine;
    private GameObject cytosine;
    private GameObject guanine;
    private Vector3 NucleotideCoordinate;
    private Quaternion NucleotideRotation;
    private GameObject lastSpawn;
    public bool AreThereAnyNucleotides;
    private SpawnControl sControl;

    private bool myBoolean;

    private void Start()
    {
        adenin = GameObject.FindGameObjectWithTag("Adenin");
        thymine = GameObject.FindGameObjectWithTag("thymine");
        cytosine = GameObject.FindGameObjectWithTag("cytosine");
        guanine = GameObject.FindGameObjectWithTag("guanine");

        AreThereAnyNucleotides = FindObjectOfType<SpawnControl>().isObjectSpawned;

        sControl = FindObjectOfType<SpawnControl>();
    }

    private void Update()
    {
        if (myBoolean && lastSpawn.tag != "oldNuc" )
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            lastSpawn.transform.localPosition =
                new Vector3(mousePos.x, mousePos.y, 0);
            //ebug.Log("BURADAAAAAAAAAAAAAAA!!!!!!!!!!!!!!!");
        }
    }

    private void OnMouseDown() // Detect when user clicked while cursor on collider
    {
        if (sControl.lastSpawn != null && sControl.lastSpawn.tag != "oldNuc")
        {
            Destroy(sControl.lastSpawn);
            AreThereAnyNucleotides = false;
        }

        myBoolean = true;
        if (this.gameObject.tag == "Adenin")
        {
            NucleotideCoordinate = adenin.transform.position;
            NucleotideCoordinate.y += 1;
            NucleotideRotation = adenin.transform.rotation;
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            lastSpawn =
                Instantiate(Resources.Load("Prefabs/DragableAdenin"), mousePos, NucleotideRotation) as GameObject;
            NucleotideCoordinate.y -= 1;

            AreThereAnyNucleotides = true;
        }
        else if (this.gameObject.tag == "thymine")
        {
            NucleotideCoordinate = thymine.transform.position;
            NucleotideCoordinate.y += 1;
            NucleotideRotation = thymine.transform.rotation;
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            lastSpawn = Instantiate(Resources.Load("Prefabs/DragableTimin"), mousePos,
                NucleotideRotation) as GameObject;
            NucleotideCoordinate.y -= 1;

            AreThereAnyNucleotides = true;
        }
        else if (this.gameObject.tag == "cytosine")
        {
            NucleotideCoordinate = cytosine.transform.position;
            NucleotideCoordinate.y += 1;
            NucleotideRotation = cytosine.transform.rotation;
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            lastSpawn =
                Instantiate(Resources.Load("Prefabs/DragableSitozin"), mousePos, NucleotideRotation) as GameObject;
            NucleotideCoordinate.y -= 1;

            AreThereAnyNucleotides = true;
        }
        else if (this.gameObject.tag == "guanine")
        {
            NucleotideCoordinate = guanine.transform.position;
            NucleotideCoordinate.y += 1;
            NucleotideRotation = guanine.transform.rotation;
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            lastSpawn =
                Instantiate(Resources.Load("Prefabs/DragableGuanin"), mousePos, NucleotideRotation) as GameObject;
            NucleotideCoordinate.y -= 1;

            AreThereAnyNucleotides = true;
        }

        sControl.lastSpawn = lastSpawn;

        
    }

    private void OnMouseUp()
    {
        myBoolean = false;
        if (!lastSpawn.CompareTag("oldNuc"))
        {
            Destroy(lastSpawn);
        }
    }


    /*
    private void CheckAndDestroy()
    {
        if (nucleotideA != null && nucleotideA.tag != "oldNuc")
        {
            Destroy(nucleotideA);
        }
        if (nucleotideC != null && nucleotideC.tag != "oldNuc")
        {
            Destroy(nucleotideC);
        }
        if (nucleotideT != null && nucleotideT.tag != "oldNuc")
        {
            Destroy(nucleotideT);
        }
        if (nucleotideG != null && nucleotideG.tag != "oldNuc")
        {
            Destroy(nucleotideG);
        }
    }
    */
}
