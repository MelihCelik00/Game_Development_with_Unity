using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float _coeffConst = 0.05f;
    

    private void FixedUpdate()
    {
        transform.position += Vector3.down * (Time.deltaTime * FindObjectOfType<ObjectSpawner>().FallSpeed);
    }
}