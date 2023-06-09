using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    public Text text;   
    public Sprite[] weapons;
    public int[] baseball;
    public int[] forgegold;
    public int[] sellgold;
    public int[] Successswordstone;
    public int[] Breakswordstone;
    public string[] swordname;
    [SerializeField]
    ParticleSystem Success; //파티클시스템
    [SerializeField]
    ParticleSystem Fail;

    Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    void FixedUpdate()
    {
        img.sprite = weapons[UserData.currentswordlevel];
    }

    public void UpgradeSword()
    {
        int level = UserData.currentswordlevel;

        if (UserData.gold >= forgegold[level])
        {
            UserData.gold -= forgegold[level];
            int random = Random.Range(1, baseball[level]+UserData.successball - UserData.removeball);

            if (200 + UserData.successball >= random) //  (기본 공 + 성공 공 개수) >=  총 공의 개수
            {
                Debug.Log("강화 성공");
                UserData.swordstone += Successswordstone[UserData.currentswordlevel];
                level++;
                Success.Play();
            }
            else
            {
                UserData.swordstone += Breakswordstone[UserData.currentswordlevel];
                level = 0;
                Fail.Play();
            }

            UserData.currentswordlevel = level;
        }
        else
        {
            Debug.Log("골드 부족");
        }
    }

    public void SellSword()
    {
        int level = UserData.currentswordlevel;
        UserData.gold += sellgold[level] * (100 + UserData.marginadd) / 100;

        Debug.Log("판매 완료");
        level = 0;
        UserData.currentswordlevel = level;
    }
}
