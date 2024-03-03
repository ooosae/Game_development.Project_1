using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerController playerController;

    public event System.Action OnPlayerControllerSet;

    public void SetPlayerController(PlayerController controller)
    {
        playerController = controller;
        OnPlayerControllerSet?.Invoke();
    }

    public PlayerController GetPlayerController()
    {
        return playerController;
    }
}