using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>())
        {
            GameManager.instance.SetScore(GameManager.instance.GetScore() + 50);
            Destroy(gameObject);

        }
    }

}
