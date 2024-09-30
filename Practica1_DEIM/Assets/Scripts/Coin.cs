using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            GameManager.instance.SetScore(GameManager.instance.GetScore() + score);
            Destroy(gameObject);
        }
    }

}
