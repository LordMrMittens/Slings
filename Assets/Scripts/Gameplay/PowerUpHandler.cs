using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    [SerializeField] PowerUpUI powerUpUI;
    float maxPowerupBuildup = 100;
    float currentPowerupBuildup =0 ;
    [SerializeField] int powerupBuildupRate =10; 
    [SerializeField] int killsNecesaryForIncrease =3; 
    int killCount = 0;
    [SerializeField] float powerupduration =4;
    [SerializeField] float powerupMaxIncrease = 1.10f; 
    bool isActive = false;

    private void Start() {
        powerUpUI.UpdatePowerUpUI(currentPowerupBuildup, maxPowerupBuildup);
    }
    public void ActivatePowerUp()
    {
        if(currentPowerupBuildup >= maxPowerupBuildup /2 && !isActive)
        {
            //activate powerup
            isActive = true;
            StartCoroutine(ActivatePowerup());


        }
    }
    IEnumerator ActivatePowerup()
    {
        Time.timeScale = 0;
        powerUpUI.ActivatePowerUp();
        yield return new WaitForSeconds(powerupduration);
        Time.timeScale = 1;
        currentPowerupBuildup = 0;
        maxPowerupBuildup *= powerupMaxIncrease;
        powerUpUI.UpdatePowerUpUI(currentPowerupBuildup, maxPowerupBuildup);
        isActive = false;
    }
    public void AddPowerupBuildup(int value)
    {
        killCount = value > 4? killCount + value : killCount +1;
            if(killCount % killsNecesaryForIncrease == 0)
            {
                currentPowerupBuildup += powerupBuildupRate;
                powerUpUI.UpdatePowerUpUI(currentPowerupBuildup, maxPowerupBuildup);
            }
        
    }
}
