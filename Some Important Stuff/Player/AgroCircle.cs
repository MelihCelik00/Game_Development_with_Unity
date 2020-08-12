using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroCircle : MonoBehaviour
{

    [SerializeField] private float lineWidth;
    [SerializeField] private float height = .5f;

    private int vertex = 50;
    private LineRenderer lineRenderer;
    private float radius;
    private Player player;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = (vertex + 1);
        player = GetComponentInParent<Player>();
        radius = player.weapon.AttackDistance;
    }

    private void Awake()
    {

    }

    private void OnDrawGizmos()
    {
        DrawCircleDebug();
    }

    private void FixedUpdate()
    {
        DrawCircle();
    }

    private void DrawCircleDebug()
    {
        var increment = 10;
        for (int angle = 0; angle < 360; angle = angle + increment)
        {
            var heading = Vector3.forward - transform.position;
            var direction = heading / heading.magnitude;
            var point = transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * radius;
            var point2 = transform.position + Quaternion.Euler(0, angle + increment, 0) * Vector3.forward * radius;
            Debug.DrawLine(point, point2, Color.red);
        }
    }

    private void DrawCircle()
    {
        float x;
        float z;

        float change = 2 * Mathf.PI / vertex;
        float angle = change;

        for (int i = 0; i < (vertex + 1); i++)
        {
            x = Mathf.Sin(angle) * radius;
            z = Mathf.Cos(angle) * radius;

            lineRenderer.SetPosition(i, new Vector3(x, height, z));

            angle += change;
        }
    }

}


