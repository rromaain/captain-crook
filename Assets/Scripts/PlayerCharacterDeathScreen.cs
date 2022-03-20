using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterDeathScreen : MonoBehaviour
{
    // Health component of player
    [SerializeField] private PlayerCharacterHealth playerCharacterHealth = null;
    public PlayerCharacterHealth PlayerCharacterHealth
    {
        get
        {
            if (this.playerCharacterHealth == null)
                this.playerCharacterHealth = this.gameObject.GetComponentInParent<PlayerCharacterHealth>();
            return this.playerCharacterHealth;
        }
    }

    // Root of the view
    [SerializeField] private Transform deathScreenRoot = null;

    void Awake()
    {
        // Register to health events
        if (this.PlayerCharacterHealth != null)
        {
            this.PlayerCharacterHealth.OnDead.AddListener(this.OnDead);
            this.PlayerCharacterHealth.OnRevive.AddListener(this.OnRevive);
        }

        // Hide
        if (this.deathScreenRoot != null)
            this.deathScreenRoot.gameObject.SetActive(false);
    }

    // UI Events
    public void OnRespawnButtonClicked()
    {
        if (this.PlayerCharacterHealth != null)
            this.PlayerCharacterHealth.Revive();
    }

    // Events
    public void OnDead()
    {
        if (this.deathScreenRoot != null)
            this.deathScreenRoot.gameObject.SetActive(true);
    }
    public void OnRevive()
    {
        if (this.deathScreenRoot != null)
            this.deathScreenRoot.gameObject.SetActive(false);
    }
}
