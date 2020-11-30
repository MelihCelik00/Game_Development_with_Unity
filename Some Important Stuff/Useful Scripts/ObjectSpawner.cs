using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

//using Random = System.Random;

public class ObjectSpawner : MonoBehaviour
{
    public float generatorTimer = 3f;

    public GameObject[] spawnables;
    private int randomInt;

    private int _score;
    private GameObject[] ObjArr;
    private float constant = 0.1f;
    
    private float objectFallSpeed = 1.75f;
    
    public float FallSpeed { get => objectFallSpeed; }

    private float coefficientConstant = 0.01f;
    private ScoreManager _scoreManager;
    private float SpawnLimitTime = 1.5f;
    
    // Define PlayerPrefs Keys Here 
    private const string lastFallSpeed = "Fall Speed";
    private const string lastGeneratorTimer = "Generator Time";

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        _scoreManager = FindObjectOfType<ScoreManager>();
        StartGenerator();
        ObjArr = new GameObject[] { };
    }
    
    void StartGenerator()
    {
        StartCoroutine(ObjectGeneration());
    }

    private IEnumerator ObjectGeneration()
    {
        while(true) 
        {
            ChangeSpeedOfGame();
            randomInt = Random.Range(0, spawnables.Length); // array of parent nucleotites
            Vector3 randPosition = new Vector3(0, 6, 0);  
            Instantiate(spawnables[randomInt], randPosition, Quaternion.identity);
            ChangeSpawnSpeed();
            
            PlayerPrefs.SetFloat(lastFallSpeed, objectFallSpeed); // Set Object Fall Speed Value to PlayerPrefs
            PlayerPrefs.SetFloat(lastGeneratorTimer, generatorTimer); // Set Generator Timer Value to PlayerPrefs
            
            yield return new WaitForSeconds(generatorTimer);
        }
    }
    
    private void ChangeSpeedOfGame()
    {
        switch (_scoreManager.Score)
        {
            case 50:
                objectFallSpeed = 1.75f;
                break;
            case 100:
                objectFallSpeed = 2f;
                break;
            case 200:
                objectFallSpeed = 2.25f;
                break;
            case 400:
                objectFallSpeed = 2.50f;
                break;
            case 600:
                objectFallSpeed = 2.75f;
                break;
        }
        
        /*if (objectFallSpeed <= 6f && _scoreManager.Score >= 20)
        {
            objectFallSpeed += coefficientConstant;
            //Debug.Log("Fall Speed: "+ objectFallSpeed);
        }*/
    }

    private void ChangeSpawnSpeed()
    {
        if (_scoreManager.Score<1000 && generatorTimer >= SpawnLimitTime)
        {
            generatorTimer -= constant;
            if (generatorTimer < SpawnLimitTime)
            {
                generatorTimer = SpawnLimitTime;
            }
        }
        else
        {
            generatorTimer = 1.25f;
        }

    }
}