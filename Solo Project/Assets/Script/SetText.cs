using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class SetText : MonoBehaviour
{
    public Text text;
    Sword sword;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("SwordText"))
        {
            sword = GameObject.Find("Sword").GetComponent<Sword>(); // update���� ��� �����ǹǷ� ��ȿ������.
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (text.name)
        {
            case "(Text)Coin":
                text.text = UserData.gold.ToString();
                break;
            case "(Text)CurrentForge":
                text.text = "���� ��ȭ : " + UserData.currentswordlevel.ToString();
                break;
            case "(Text)Chance":
                text.text = "���� Ȯ�� : " + ((1000 - UserData.currentswordlevel * 50)/10).ToString() + "%";
                break;
            case "(Text)SwordName":
                text.text = sword.swordname[UserData.currentswordlevel];
                break;
            case "(Text)NeedMoney":
                text.text = "�ʿ� ����: " + sword.forgegold[UserData.currentswordlevel].ToString();
                break;
            case "(Text)SellMoney":
                text.text = "�ǸŰ�: " + sword.sellgold[UserData.currentswordlevel].ToString();
                break;
            case "GLevel0":
                text.text = UserData.Gupgrade[0].ToString();
                break;
            case "GLevel1":
                text.text = UserData.Gupgrade[1].ToString();
                break;
            case "GLevel2":
                text.text = UserData.Gupgrade[2].ToString();
                break;
            case "GLevel3":
                text.text = UserData.Gupgrade[3].ToString();
                break;
            case "GLevel4":
                text.text = UserData.Gupgrade[4].ToString();
                break;
        }
    }
}
