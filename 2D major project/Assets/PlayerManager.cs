using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // set max health
    public int currentHealth;
    public int MaxHealth;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    public int coinCount;

    private void Update()
    {
        if (currentHealth <= 0)
        {
            PauseGame();
        }
    }
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
            coinCount++;
                return true;
            case "Speed+":
                playerMovement.SpeedPowerUp();
                //call function here
                return true;
            default:
                Debug.Log("Item tag or reference not set.");
                return false;
        }
        
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
       
}
