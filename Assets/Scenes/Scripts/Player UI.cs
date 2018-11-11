using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class PlayerMovement : MonoBehaviour
{
    public Image socialBar;
    public Image happinessBar;
    //
    public Image healthBar;
    public Image sleepBar;
    //
    public Image moneyBar;

    public Text gameOverTextOne;
    public Text gameOverTextTwo;

    public void UpdateUI()
    {
        //
        moneyBar.rectTransform.sizeDelta = new Vector2(20, MoneyAmount);
        moneyBar.transform.position = new Vector3(5, 325 - MoneyAmount, 0);

        //
        socialBar.rectTransform.sizeDelta = new Vector2(20, SocialAmount);
        socialBar.transform.position = new Vector3(30, 325 - SocialAmount, 0);
        //
        happinessBar.rectTransform.sizeDelta = new Vector2(20, HappinessAmount);
        happinessBar.transform.position = new Vector3(30, 325 - SocialAmount - HappinessAmount, 0);

        //
        healthBar.rectTransform.sizeDelta = new Vector2(20, HealthAmount);
        healthBar.transform.position = new Vector3(55, 325 - HealthAmount, 0);
        //
        sleepBar.rectTransform.sizeDelta = new Vector2(20, SleepAmount);
        sleepBar.transform.position = new Vector3(55, 325 - HealthAmount - SleepAmount, 0);

        /*
        socialBar.rectTransform.height = SocialAmount;
        happinessBar.rectTransform.height = HappinessAmount;
        //
        healthBar.rectTransform.height = MoneyAmount;
        sleepBar.rectTransform.height = HealthAmount;
        //
        moneyBar.rectTransform.height = SleepAmount;
        */
    }

    public void GameOver(string gameOverMessage)
    {
        gameOverTextOne.text = "GAME OVER";
        gameOverTextTwo.text = gameOverMessage;
        GameRunning = false;
    }
}
