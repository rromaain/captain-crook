using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Awake()
    {
        // Init Position
        this.InitPositions();

        // Register to health events
        this.RegisterToHealthEvents();
    }

    #region Save Positions / Spawning
    // Vars
    private CharacterController2D characterController2D = null;
    private PlayerMovement playerMovement = null;
    public CharacterController2D CharacterController2D
    {
        get
        {
            if (this.characterController2D == null)
                this.characterController2D = this.gameObject.GetComponentInChildren<CharacterController2D>();
            return this.characterController2D;
        }
    }

    public PlayerMovement PlayerMovement
    {
        get
        {
            if (this.playerMovement == null)
                this.playerMovement = this.gameObject.GetComponentInChildren<PlayerMovement>();
            return this.playerMovement;
        }
    }

    // Spawn / Respawn position
    private Vector2 spawnPosition = Vector2.zero;
    void InitPositions()
    {
        if (this.CharacterController2D != null)
        {
            this.spawnPosition = this.CharacterController2D.transform.position;
        }
    }
    #endregion

    #region Health
    // Vars
    private PlayerCharacterHealth playerCharacterHealth = null;
    public PlayerCharacterHealth PlayerCharacterHealth
    {
        get
        {
            if (this.playerCharacterHealth == null)
                this.playerCharacterHealth = this.gameObject.GetComponentInChildren<PlayerCharacterHealth>();
            return this.playerCharacterHealth;
        }
    }

    // Called in Awake / OnEnable / OnDisable
    void RegisterToHealthEvents()
    {
        // Register to health events
        if (this.PlayerCharacterHealth != null)
        {
            this.PlayerCharacterHealth.OnDead.AddListener(this.OnDead);
            this.PlayerCharacterHealth.OnRevive.AddListener(this.OnRevive);
        }
    }

    // Health - Events
    private void OnRevive()
    {
        if (this.CharacterController2D != null && this.PlayerMovement != null)
        {
            // Set back to respawn position
            this.CharacterController2D.transform.position = this.spawnPosition;

            // Enable back the various components
            {
                // Controller
                this.CharacterController2D.enabled = true;
                this.PlayerMovement.enabled = true;

                // Camera
                Camera camera = this.GetComponentInChildren<Camera>();
                if (camera != null)
                {
                    FollowCamera cameraFollowTransform = camera.GetComponent<FollowCamera>();
                    if (cameraFollowTransform != null)
                    {
                        // Enable back
                        cameraFollowTransform.enabled = true;

                        // Reset camera position
                        cameraFollowTransform.transform.position = new Vector3(this.spawnPosition.x, this.spawnPosition.y, cameraFollowTransform.transform.position.z);
                    }
                }

                // Box collider
                BoxCollider2D boxCollider2D = this.CharacterController2D.GetComponent<BoxCollider2D>();
                if (boxCollider2D != null)
                    boxCollider2D.enabled = true;

                // Rigidbody
                Rigidbody2D rigidbody2D = this.CharacterController2D.GetComponent<Rigidbody2D>();
                if (rigidbody2D != null)
                {
                    // Enable rigidbody to fall again
                    rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                    
                    // Reset the velocity
                    rigidbody2D.velocity = Vector2.zero;
                }
            }
        }
    }

    private void OnDead()
    {
        if (this.CharacterController2D != null && this.PlayerMovement != null)
        {
            // Disable components
            {
                // Controller
                this.CharacterController2D.enabled = false;
                this.PlayerMovement.enabled = false;
                // Camera
                Camera camera = this.GetComponentInChildren<Camera>();
                if (camera != null)
                {
                    FollowCamera cameraFollowTransform = camera.GetComponent<FollowCamera>();
                    if (cameraFollowTransform != null)
                    {
                        cameraFollowTransform.enabled = false;
                    }
                }

                // Box collider
                BoxCollider2D boxCollider2D = this.CharacterController2D.GetComponent<BoxCollider2D>();
                if (boxCollider2D != null)
                    boxCollider2D.enabled = false;

                // Rigidbody
                Rigidbody2D rigidbody2D = this.CharacterController2D.GetComponent<Rigidbody2D>();
                if (rigidbody2D != null)
                {
                    // Do not be affected by physics anymore
                    rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

                    // Reset the velocity
                    rigidbody2D.velocity = Vector2.zero;
                }

                // PlayerInventory playerInventory =  this.gameObject.GetComponent<PlayerInventory>();
                // if (playerInventory != null)
                // {
                //     playerInventory.gemCount = 0;
                //     playerInventory.keyCount = 0;
                // }
            }
        }
    }
    #endregion
}