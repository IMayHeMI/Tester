using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private Transform ammoSpawn;
    [SerializeField] private Player_Movement player;
    [SerializeField] private float speed;
    [SerializeField] private float cooldown = 2f;
    private float currentCooldownTime;

    private bool fired = false;

    private Vector3 offset = new Vector3(0.4f, 0, 0);


    void Start()
    {
        currentCooldownTime = cooldown;
    }

    void Update()
    {
        if (player.facingRight)
            ammoSpawn.position = playerPosition.position - offset;
        else
            ammoSpawn.position = playerPosition.position + offset;
               
        Shoot();
        if (fired) CooldownTimer();
        CooldownReset();
    }

    public void Shoot() 
    {
        if (Input.GetMouseButtonDown(0) && currentCooldownTime == cooldown)
        {
            if(player.facingRight) 
            {
                var _ammo = Instantiate(ammo, ammoSpawn.position, ammoSpawn.rotation);
                _ammo.GetComponent<Rigidbody2D>().velocity = -ammoSpawn.right * speed;
                fired = true;
            }
            else
            {
                var _ammo = Instantiate(ammo, ammoSpawn.position, ammoSpawn.rotation);
                _ammo.GetComponent<Rigidbody2D>().velocity = ammoSpawn.right * speed;
                fired= true;
            }
            
        }
    }

    public void CooldownReset()
    {
        if (currentCooldownTime <= 0)
        {
            currentCooldownTime = cooldown;
            fired = false;
        }
    }

    public void CooldownTimer() 
    { 
        currentCooldownTime -= Time.deltaTime; 
    }
}
