using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogs : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        PlayerManager playerManager = FindObjectOfType<PlayerManager>();
        playerController = playerManager.GetPlayerController();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cat")
        {
            if (playerController.IsBoosted())
            {
                playerController.Deboost();
                Destroy(gameObject);
            }
            else
                playerController.Die();
        }
    }
}
