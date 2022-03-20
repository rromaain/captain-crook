using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public int health;

    //100 health => 1 fill amount
    //45 health => 0.45 fill amount

    public void LoseHealth(int value)
    {
        //Do nothing if you are out of health
        if (health <= 0)
            return;
        //Reduce the health 
        health -= value;
        //Refresh the UI fillBar
        fillBar.fillAmount = health / 100;
        //Check if your health is zero or less => Dead
        if(health<=0)
        {
            Debug.Log("There we are");
        }
    }
    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //        LoseHealth(25);
    // }
}