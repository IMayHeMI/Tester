using UnityEngine;

public class Ammo_Behave : MonoBehaviour
{
    private float lifeTime = 3;

    [SerializeField] private int ammoDamage;

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
