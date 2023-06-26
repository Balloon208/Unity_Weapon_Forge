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
            sword = GameObject.Find("Sword").GetComponent<Sword>(); // update���� ��� �����ǹǷ� ��ȿ������.
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
        switch (text.name)
        {
            case "(Text)Coin":
                text.text = UserData.gold.ToString();
                break;
            case "(Text)SwordStone":
                text.text = UserData.swordstone.ToString();
                break;
            case "(Text)CurrentForge":
                text.text = "���� ��ȭ : " + UserData.currentswordlevel.ToString();
                break;
            case "(Text)Chance":
                // 200 + successball / baseball + successball - removeball
                double chance = Math.Round((double)(200 + UserData.successball) / (sword.baseball[UserData.currentswordlevel] + UserData.successball - UserData.removeball) *100,1);
                text.text = "���� Ȯ�� : " + chance.ToString() + "%";
                break;
            case "(Text)SwordName":
                text.text = sword.swordname[UserData.currentswordlevel];
                break;
            case "(Text)NeedMoney":
                text.text = "�ʿ� ����: " + sword.forgegold[UserData.currentswordlevel].ToString();
                break;
            case "(Text)SellMoney":
                text.text = "�ǸŰ�: " + (sword.sellgold[UserData.currentswordlevel] * (100 + UserData.marginadd) / 100).ToString();
                break;
            case "GLevel0":
                text.text = UserData.Gupgrade[0].ToString();
                break;
            case "GLevel0_Cost":
                text.text = "����: " + findtext(0) + "���";
                break;
            case "GLevel1":
                text.text = UserData.Gupgrade[1].ToString();
                break;
            case "GLevel1_Cost":
                text.text = "����: " + findtext(1) + "���";
                break;
            case "GLevel2":
                text.text = UserData.Gupgrade[2].ToString();
                break;
            case "GLevel2_Cost":
                text.text = "����: " + findtext(2) + "���";
                break;
            case "GLevel3":
                text.text = UserData.Gupgrade[3].ToString();
                break;
            case "GLevel3_Cost":
                text.text = "����: " + findtext(3) + "���";
                break;
            case "GLevel4":
                text.text = UserData.Gupgrade[4].ToString();
                break;
            case "GLevel4_Cost":
                text.text = "����: " + findtext(4) + "���";
                break;
        }
    }
}
