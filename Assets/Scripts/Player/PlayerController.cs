using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class PlayerController : MonoBehaviour
{
    private PlayerMovement Movement;
    private GunData[] guns = new GunData[3];
    private int currentGun = 0;

    private float maxPlayerHealth = 20;
    public float MaxPlayerHealth => maxPlayerHealth;

    private float PlayerSpeed = 4;
    public float PlayerHealth { get; private set; }

    private int playerbodyDamage { get; private set; }


    public int PlayerBullets;
    public int PlayerBulletDamage { get; private set; }
    public float PlayerBulletSpeed { get; private set; }

    private Rigidbody2D Rig;
    private Transform BulletSpawn;
    private SpriteRenderer GunRender;

    private void Awake()
    {
        guns[0] = (GunData)AssetDatabase.LoadAssetAtPath("Assets/ScriptableObject/Guns/GunDefault.asset", typeof(GunData));
        guns[1] = (GunData)AssetDatabase.LoadAssetAtPath("Assets/ScriptableObject/Guns/GunOne.asset", typeof(GunData));
        guns[2] = (GunData)AssetDatabase.LoadAssetAtPath("Assets/ScriptableObject/Guns/GunTwo.asset", typeof(GunData));
    }

    void Start()
    {
        if (guns != null)
            LoadPlayer();

    }



    private void FixedUpdate()
    {
        Movement.InputLimit();
        Movement.Moving(Rig);
        Movement.RotateToMouse(transform);
    }



    void Update()
    {
        UpdatingPlayer();

        if (Input.GetMouseButtonDown(0) && PlayerBullets >= 1)
            Shoot();

        if (PlayerHealth <= 0)
            Destroy(this.gameObject);
    }



    void LoadPlayer()
    {
        Movement = new PlayerMovement(PlayerSpeed);
        PlayerBullets = guns[currentGun].bullets;
        PlayerHealth = maxPlayerHealth;
        Rig = GetComponent<Rigidbody2D>();
        GameObject Gun = Instantiate(guns[currentGun].gunType, this.transform);
        BulletSpawn = Gun.GetComponentInChildren<Transform>().GetChild(0);
        GunRender = Gun.GetComponent<SpriteRenderer>();

    }


    void UpdatingPlayer()
    {
        GunRender.color = guns[currentGun].gunColor;
        PlayerBulletDamage = guns[currentGun].bulletDamage;
        PlayerBulletSpeed = guns[currentGun].bulletSpeed;
    }



    public int NextGun(int indexGun)
    {
        return currentGun = indexGun;
    }


    public float TakeDamage(int damage)
    {
        return PlayerHealth -= damage;
    }



    public void Shoot()
    {
        Instantiate(guns[currentGun].bulletType, BulletSpawn.position, BulletSpawn.rotation, this.transform).AddComponent<PlayerBullet>();
        PlayerBullets -= 1;
    }
}