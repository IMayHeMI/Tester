using UnityEngine;

public enum EnemyType
{
    Junior = 1,
    Middle,
    Senior
}

public class Enemy : MonoBehaviour
{
    private Sprite enemySprite;

    private Mail_Box mailBox;

    [SerializeField] private int healthPoints;
    public int HealthPoints
    {
        get
        {
            return healthPoints;
        }
        set
        {
            if (healthPoints < 0)
                healthPoints = 0;
            else
                healthPoints = value;
        }
    }

    [SerializeField] private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }
        private set
        {
            speed = value;
        }
    }

    [SerializeField] private float jumpForce;
    public float JumpForce
    {
        get
        {
            return jumpForce; 
        }
        private set
        {
            jumpForce = value;
        }
    }

    private EnemyType enemyType;


    private void Start()
    {
        mailBox = GameObject.Find("MailBox").GetComponent<Mail_Box>();
    }


    void Update()
    {
        Death();
    }

    public void SetEnemyStats(EnemyType enemyType)
    {
        enemyType = this.enemyType;

        if (enemyType == EnemyType.Junior)
        {
            healthPoints = 10;
            speed = 3;
            jumpForce = 6;            
        }
        else if (enemyType == EnemyType.Middle)
        {
            healthPoints = 20;
            speed = 4;
            jumpForce = 6;
        }
        else if (enemyType == EnemyType.Senior)
        {
            healthPoints = 30;
            speed = 5;
            jumpForce = 7;
        }
    }

    public void Stealing()
    {
        mailBox.mailsCount--;
        Debug.Log($"{mailBox.mailsCount} mails in mailbox remain");
    }

    public void Death()
    {
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger) 
        { 
            Stealing();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == GameObject.Find("Newspaper(Clone)").GetComponent<BoxCollider2D>())
            Destroy(gameObject);
    }
}
