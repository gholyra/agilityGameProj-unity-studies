using UnityEngine;

public class MovingObstacles : Obstacle
{
    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;
    [SerializeField] private float velocity = 10f;
    [SerializeField] private int waitTime = 3;
    private float elapsedTime;
    private bool canMove;
    private bool canSwitch;

    private void Awake()
    {
        position1 = this.transform;
        canMove = false;
        canSwitch = false;
    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            TimeCount();
        }

        if (!canSwitch)
        {
            transform.position = Vector3.MoveTowards(transform.position, position2.position, velocity * Time.deltaTime);
        }
        else if (canSwitch)
        {
            transform.position = Vector3.MoveTowards(transform.position, position1.position, velocity * Time.deltaTime);
        }

        if (transform.position == position1.position)
        {
            canSwitch = false;
        }
        else if (transform.position == position2.position)
        {
            canSwitch = true;
        }
    }

    private void TimeCount()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= waitTime)
        {
            elapsedTime = 0;
            canMove = true;
        }
    }

}
