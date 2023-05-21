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
    void Setsword()
    {
        sword = GameObject.Find("Sword").GetComponent<Sword>(); // update���� ��� �����ǹǷ� ��ȿ������.
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
                Setsword();
                text.text = sword.swordname[UserData.currentswordlevel];
                break;
            case "(Text)NeedMoney":
                Setsword();
                text.text = "�ʿ� ����: " + sword.forgegold[UserData.currentswordlevel].ToString();
                break;
            case "(Text)SellMoney":
                Setsword();
                text.text = "�ǸŰ�: " + sword.sellgold[UserData.currentswordlevel].ToString();
                break;

        }
    }
}
