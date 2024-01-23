using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    [SerializeField] Rigidbody2D rigidBody;

    [SerializeField] Transform target;

    private float currentTime;

    private bool jumped = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        currentTime = 3;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3 (target.position.x, transform.position.y, transform.position.z), enemy.Speed * Time.deltaTime);

        Jump();
        if (jumped == true) Timer();
        ResetTime();
    }

    public void Jump()
    {
        if (jumped == false)
        {
            rigidBody.AddForce(Vector2.up * enemy.JumpForce, ForceMode2D.Impulse);
            jumped = true;
        }

    }

    public void Timer()
    {
        currentTime -= Time.deltaTime;
    }

    public void ResetTime()
    {
        if (currentTime <= 0)
        {
            currentTime = Random.Range(1f, 4f);
            jumped = false;           
        }

    }
}
