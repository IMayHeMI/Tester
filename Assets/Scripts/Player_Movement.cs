using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    [SerializeField] private float movementSpeed;

    [SerializeField] private float jumpForce;

    private LayerMask platformLayer;

    private LayerMask groundLayer;

    private Collider2D playerCollider;

    private bool grounded = true;

    private bool isOnPlatform = false;

    public bool facingRight;


    private void Start()
    {
        platformLayer = LayerMask.NameToLayer("Platform");

        groundLayer = LayerMask.NameToLayer("Ground");

        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {      
        Move();
        JumpOff();
        Jump();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.A)) 
        {            
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            if (facingRight == false)
            Flip();
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            if (facingRight == true)
            Flip();
        }        
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true) 
        {
            grounded = false;
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);                        
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isOnPlatform == true)
        {
            isOnPlatform = false;
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void JumpOff()
    {
        if (Input.GetKeyDown(KeyCode.S) && isOnPlatform == true)
        {
            playerCollider.enabled = false;
            isOnPlatform = false;
            StartCoroutine(EnableCollider());
        }
    }

    public void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        facingRight = !facingRight;        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == platformLayer)
        {
            grounded = false;   
            StartCoroutine (JumpOnPlatformDelay());  
        }
        if (other.gameObject.layer == groundLayer)
        {
            isOnPlatform = false;
            StartCoroutine(JumpOnGroundDelay());
        }        
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.3f);
        playerCollider.enabled = true;
    }

    private IEnumerator JumpOnPlatformDelay()
    {
        yield return new WaitForSeconds(0.2f);
        isOnPlatform = true;
    }

    private IEnumerator JumpOnGroundDelay()
    {
        yield return new WaitForSeconds(0.2f);
        grounded = true;
    }
}
