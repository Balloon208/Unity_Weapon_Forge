using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using System;

public class SetText : MonoBehaviour
{
    public Text text;
    Sword sword;
    UpgradeSystem upgradeSystem;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("SwordText"))
        {
            sword = GameObject.Find("Sword").GetComponent<Sword>(); // update에서 계속 참조되므로 비효율적임.
        }
    }

    string findtext(int n)
    {
        string name = "[Button]Upgrade_" + n.ToString();
        upgradeSystem = GameObject.Find(name).GetComponent<UpgradeSystem>();

        return upgradeSystem.Cost[UserData.Gupgrade[n]].ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if(text.name == "(Text)Coin")
        {
            text.text = UserData.gold.ToString();
        }
        if (text.name == "(Text)SwordStone")
        {
            text.text = UserData.swordstone.ToString();
        }
        if (text.name == "(Text)CurrentForge")
        {
            text.text = "현재 강화 : " + UserData.currentswordlevel.ToString();
        }
        if (text.name == "(Text)Chance")
        {
            // 200 + successball / baseball + successball - removeball
            double chance = Math.Round((double)(200 + UserData.successball) / (sword.baseball[UserData.currentswordlevel] + UserData.successball - UserData.removeball) * 100, 1);
            text.text = "성공 확률 : " + chance.ToString() + "%";
        }
        if (text.name == "(Text)SwordName")
        {
            text.text = sword.swordname[UserData.currentswordlevel];
        }
        if (text.name == "(Text)NeedMoney")
        {
            text.text = "필요 코인: " + sword.forgegold[UserData.currentswordlevel].ToString();
        }
        if (text.name == "(Text)SellMoney")
        {
            text.text = "판매가: " + (sword.sellgold[UserData.currentswordlevel] * (100 + UserData.marginadd) / 100).ToString();
        }
        if(text.name.Contains("GLevel"))
        {
            string Replacetext = text.name.Replace("GLevel", "");

            int number = Replacetext[0] - '0';

            if (Replacetext.Contains("_Cost"))
            {
                text.text = "가격: " + findtext(number) + "골드";
            }
            else
            {
                text.text = UserData.Gupgrade[number].ToString();
            }
        }
        if(text.name.Contains("SSLevel"))
        {
            string Replacetext = text.name.Replace("SSLevel", "");

            int number = Replacetext[0] - '0';

            if (Replacetext.Contains("_Cost"))
            {
                text.text = "가격: " + findtext(number) + "SwordStone";
            }
            else
            {
                text.text = UserData.SSupgrade[number].ToString();
            }
        }
        if (text.name.Contains("DSLevel"))
        {
            string Replacetext = text.name.Replace("DSLevel", "");

            int number = Replacetext[0] - '0';

            if (Replacetext.Contains("_Cost"))
            {
                text.text = "가격: " + findtext(number) + "DungeonStone";
            }
            else
            {
                text.text = UserData.DSupgrade[number].ToString();
            }
        }
    }
}
