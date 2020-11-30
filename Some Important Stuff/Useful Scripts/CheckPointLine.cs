using UnityEngine;

public class CheckPointLine : MonoBehaviour
{

    private GameObject pointLine;
    private Vector3 pointLineLoc;
    private int _score;

    private PauseMenu _pauseMenu;
    
    public bool controlPlStatus = false; // send info to GameControl
    private ScoreManager _scoreManager;

    private void Start()
    {
        pointLine = GameObject.FindGameObjectWithTag("PointLine");
        pointLineLoc = pointLine.transform.position;
        _scoreManager = FindObjectOfType<ScoreManager>();
        _pauseMenu = FindObjectOfType<PauseMenu>();
    }

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        
        if (this.GetComponentInChildren<RaycastControl>().controlRcStatus == true)
        {
            if (this.transform.position.y < pointLineLoc.y)
            {
                ComboController();
                _scoreManager.AddScore(_scoreManager.point);
                Destroy(this.gameObject);
                controlPlStatus = true;
                _pauseMenu.life = 3;
                Debug.Log(_scoreManager.comboCounter);
            }
        }
        else
        {
            if (this.transform.position.y < pointLineLoc.y)
            {
                _scoreManager.comboCounter = 0;
                _scoreManager.point = 5;
                _pauseMenu.life--;
                Destroy(this.gameObject);
                Debug.Log(_scoreManager.comboCounter);
            }
        }
        
    }

    private void ComboController()
    {
        _scoreManager.comboCounter++;
        if (_scoreManager.comboCounter == 10)
            _scoreManager.point = 10;

        else if (_scoreManager.comboCounter == 20)
            _scoreManager.point = 20;

        else if (_scoreManager.comboCounter == 30)
            _scoreManager.point = 30;

        else if (_scoreManager.comboCounter == 40)
            _scoreManager.point = 40;

        else if (_scoreManager.comboCounter == 50)
        {
            _scoreManager.point = 50;
        }

    }
}
