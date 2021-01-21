using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public BotData data;

    private GameObject PlayerGameObject;
    private float CronoShoot;
    private int BotHealth;
    private float BotSpeed;
    private int BotValue;
    private BotMovement Movement;
    private GameObject BulletModel;
    private Transform BulletSpawn;
    public int BulletDamage { get; private set; }
    public int BulletSpeed { get; private set; }


    private void Start()
    {
        LoadBot(data);
    }



    private void Update()
    {
        if (PlayerGameObject != null)
        {
            Movement.RotateTo(PlayerGameObject.transform.position, this.transform);

            float distanceToPlayer = Vector2.Distance(this.transform.position, PlayerGameObject.transform.position);
            if (distanceToPlayer >= 8)
            {

            }
            else if (distanceToPlayer >= 4 && distanceToPlayer < 8)
            {
                Chase();
                CronoShoot += Time.deltaTime;

                if (CronoShoot >= 2)
                {
                    Shoot();
                    CronoShoot = 0;
                }
            }
            else
            {
                CronoShoot += Time.deltaTime;
                if (CronoShoot >= 2)
                {
                    Shoot();
                    CronoShoot = 0;
                }
            }
        }

        if (BotHealth <= 0)
            Die();
    }



    void LoadBot(BotData data)
    {
        // Properties
        PlayerGameObject = GameObject.FindGameObjectWithTag("Player");
        BotHealth = data.botHealth;
        BotSpeed = data.botSpeed;
        BotValue = data.botValue;
        Movement = new BotMovement(BotSpeed);

        // Visual
        GameObject Model = Instantiate(data.botModel, this.transform);
        SpriteRenderer BotColor = Model.GetComponent<SpriteRenderer>();
        BotColor.color = data.botColor;

        // GunVisual
        GameObject GunModel = Instantiate(data.gunType, this.transform);
        SpriteRenderer GunColor = GunModel.GetComponent<SpriteRenderer>();
        GunColor.color = data.gunColor;
        BulletSpawn = GunModel.GetComponentInChildren<Transform>().GetChild(0);

        // Properties Bullet
        BulletModel = data.bulletType;
        BulletDamage = data.bulletDamage;
        BulletSpeed = data.bulletSpeed;
    }



    void Chase()
    {
        Movement.Chasing(PlayerGameObject.transform, this.transform);        
    }



    void Shoot()
    {
        Instantiate(BulletModel, BulletSpawn.position, BulletSpawn.rotation, this.transform);
    }



    void Die()
    {
        Destroy(this.gameObject);
        CanvasController.Scoring(BotValue);
    }



    int TakeDamage(int damage)
    {
        return BotHealth -= damage;
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            int PlayerBulletDamage = collision.GetComponent<PlayerBullet>().PlayerBulletDamage;
            TakeDamage(PlayerBulletDamage);
            Destroy(collision.gameObject);
        }
    }
}
