using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Transform PlayerTransform;
    private PlayerController PlayerController;
    private float PlayerBulletSpeed;
    private float PlayerbulletDistance = 10;

    private int PlayerbulletDamage;
    public int PlayerBulletDamage => PlayerbulletDamage;

    private void Start()
    {
        PlayerTransform = GetComponentInParent<Transform>().parent;
        PlayerController = GetComponentInParent<PlayerController>();
        PlayerBulletSpeed = PlayerController.PlayerBulletSpeed;
        PlayerbulletDamage = PlayerController.PlayerBulletDamage;
        gameObject.transform.parent = null;
    }



    private void Update()
    {
        transform.Translate(new Vector2(PlayerBulletSpeed * Time.deltaTime, 0));

        if (Vector2.Distance(transform.position, PlayerTransform.position) >= PlayerbulletDistance)
            Destroy(this.gameObject);
    }
}
