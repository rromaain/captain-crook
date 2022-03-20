using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterKeyCount : MonoBehaviour
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
    public Image keyImage = null;
    public Text keyText = null;

    void Update()
    {
        if (this.PlayerInventory != null && this.PlayerInventory.keyCount > 0)
        {
            // Show
            this.Show();

            // Update
            if (this.keyText != null)
                this.keyText.text = this.PlayerInventory.keyCount.ToString();
        }
        else
        {
            // Hide view
            this.Hide();
        }
    }

    void Show()
    {
        if (this.keyImage != null)
            this.keyImage.gameObject.SetActive(true);
        if (this.keyText != null)
            this.keyText.gameObject.SetActive(true);
    }

    void Hide()
    {
        if (this.keyImage != null)
            this.keyImage.gameObject.SetActive(false);
        if (this.keyText != null)
            this.keyText.gameObject.SetActive(false);
    }
}