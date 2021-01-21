using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBullet : MonoBehaviour
{
    private Transform BotTransform;
    private BotController BotController;

    private float bulletDistance = 10;
    private int BulletDamage;
    private float BulletSpeed;

    void Start()
    {
        BotTransform = GetComponentInParent<Transform>().parent;
        BotController = GetComponentInParent<BotController>();
        BulletDamage = BotController.BulletDamage;
        BulletSpeed = BotController.BulletSpeed;
        gameObject.transform.parent = null;
    }




    void Update()
    {
        transform.Translate(new Vector2(BulletSpeed * Time.deltaTime, 0));

        if (BotTransform != null)
        {
            if (Vector2.Distance(transform.position, BotTransform.position) >= bulletDistance)
                Destroy(this.gameObject);
        }
        else
        {
            Transform PlayerTranform = GameObject.FindGameObjectWithTag("Player").transform;
            if (Vector2.Distance(transform.position, PlayerTranform.position) >= bulletDistance)
                Destroy(this.gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            collision.GetComponent<PlayerController>().TakeDamage(BulletDamage);
        }
    }
}
