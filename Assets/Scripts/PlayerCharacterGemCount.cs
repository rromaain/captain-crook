using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterGemCount : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory = null;
    public PlayerInventory PlayerInventory
    {
        get
        {
            if (this.playerInventory == null)
                this.playerInventory = this.gameObject.GetComponentInParent<PlayerInventory>();
            return this.playerInventory;
        }
    }

    [Header("UI References")]
    public Image gemImage = null;
    public Text gemText = null;

    void Update()
    {
        if (this.PlayerInventory != null && this.PlayerInventory.gemCount > 0)
        {
            // Show
            this.Show();

            // Update
            if (this.gemText != null)
                this.gemText.text = this.PlayerInventory.gemCount.ToString();
        }
        else
        {
            // Hide view
            this.Hide();
        }
    }

    void Show()
    {
        if (this.gemImage != null)
            this.gemImage.gameObject.SetActive(true);
        if (this.gemText != null)
            this.gemText.gameObject.SetActive(true);
    }

    void Hide()
    {
        if (this.gemImage != null)
            this.gemImage.gameObject.SetActive(false);
        if (this.gemText != null)
            this.gemText.gameObject.SetActive(false);
    }
}