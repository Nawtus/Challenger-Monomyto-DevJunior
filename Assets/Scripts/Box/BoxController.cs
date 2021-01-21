using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    public BoxData[] boxs;

    [SerializeField] int CurrentBox;

    private Image HealthBar;
    private float BoxHealth;
    private GameObject RewardType;
    private int ScoreValue;
    private SpriteRenderer render;

    void Start()
    {
        HealthBar = GetComponentInChildren<Image>();
        BoxHealth = boxs[CurrentBox].boxHealth;
        RewardType = boxs[CurrentBox].rewardType;
        ScoreValue = boxs[CurrentBox].scoreValue;
        render = GetComponentInChildren<SpriteRenderer>();
        render.color = boxs[CurrentBox].boxColor;
    }



    void Update()
    {
        if (BoxHealth <= 0)
        {
            Instantiate(RewardType, transform.position, transform.rotation).AddComponent<BoxReward>().CurrentBox = CurrentBox;
            CanvasController.Scoring(ScoreValue);
            Destroy(this.gameObject);
        }

        HealthBar.fillAmount = (BoxHealth / boxs[CurrentBox].boxHealth);
    }



    float TakeDamage(int damage)
    {
        return BoxHealth -= damage;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int PlayerBodyDamage = collision.gameObject.GetComponent<PlayerController>().PlayerBodyDamage;
            TakeDamage(PlayerBodyDamage);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            int PlayerBulletDamage = collision.GetComponent<PlayerBullet>().PlayerBulletDamage;
            TakeDamage(PlayerBulletDamage);
            Destroy(collision.gameObject);
        }
    }
}
