using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReward : MonoBehaviour
{
    private int rewardValue = 5;
    public int CurrentBox { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().NextGun(CurrentBox);
            collision.GetComponent<PlayerController>().PlayerBullets += rewardValue;
            Destroy(this.gameObject);
        }
    }
}
