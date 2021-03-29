using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using TMP for the text on the buttons
public class JellyCode : MonoBehaviour
{
    //score to act as the amount of 'jellies'
    //jellyCount used to show the user how many jellies they have
    //upgradeText1 to refer to the text on the first upgrade
    //upgradeText2 to refer to the text on the second upgrade
    //clickAmount as the amount of jellies you get per click from the upgrade
    //jelliesPerSecond refers to the amount of jellies you recieve per second from the upgrade
    //time to give an easy time basis
    //upgradeCost1 to refer to the cost of upgrade 1
    //upgradeCost2 to refer to the cost of upgrade 2
    //GameObject Button is used to tell which button to hide before unlocking it
    public float score = 0;
    [SerializeField]
    private TextMeshProUGUI jellyCount;
    [SerializeField]
    private TextMeshProUGUI upgradeText1;
    [SerializeField]
    private TextMeshProUGUI upgradeText2;
    private int clickAmount = 1;
    private int jelliesPerSecond;
    private float time;
    private float upgradeCost1 = 15;
    private float upgradeCost2 = 30;
    public GameObject Button;
    // the hidden unlock is set as inactive to hide it
    void Start()
    {
        Button.SetActive(false);
    }

    void Update()
    {
        //checks if the cost of the first upgrade is equal to or higher than 42 therefore unlocking the second upgrade
        if (upgradeCost1 >= 42)
        {
            Button.SetActive(true);
        }

        //sets the jellies per second upgrade up and adds the certain amount of jellies per second to your count
        jellyCount.text = score.ToString() + " Jellies";

        time += Time.deltaTime;

        if (time >= 1)
        {
            time = 0.0f;
            score += jelliesPerSecond;
        }
    }
    
    //gets the set number for the clickAmount and adds it to your score on each click of the Jelly
    public void TaskClickBUtton()
    {
        score += clickAmount;
    }

    //checks if the score is equal to or higher than the cost of upgrade 1 and increases the cost with each wach purchase also updating the text
    //to acompany the increasing price of the upgrade
    public void upgradeButton1()
    {
        if (score >= upgradeCost1)
        {
            score -= upgradeCost1;
            clickAmount += 1;
            upgradeCost1 /= 0.6f;
            upgradeCost1 = Mathf.Round(upgradeCost1 * 1);
            Debug.Log(upgradeCost1);

            upgradeText1.text = "Costs " + upgradeCost1.ToString() + " Jellies to Upgrade";
        }
    }

    //checks if the score is equal to or higher than the cost of upgrade 2 and increases the cost with each wach purchase also updating the text
    //to acompany the increasing price of the upgrade
    public void _jelliesPerSecond()
    {
        if (score >= upgradeCost2)
        {
            score -= upgradeCost2;
            jelliesPerSecond++;
            upgradeCost2 /= 0.6f;
            upgradeCost2 = Mathf.Round(upgradeCost2 * 1);
            Debug.Log(upgradeCost2);

            upgradeText2.text = "Costs " + upgradeCost2.ToString() + " Jellies to Upgrade";
        }
    }
}
