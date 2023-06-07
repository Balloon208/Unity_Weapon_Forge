using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    public Sprite[] weapons;
    public int[] totalball;
    public int[] forgegold;
    public int[] sellgold;
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
            int random = Random.Range(1, totalball[level]);

            if (UserData.successball >= random)
            {
                Debug.Log("강화 성공");
                level++;
                Success.Play();
            }
            else
            {
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
        UserData.gold += sellgold[level];

        Debug.Log("판매 완료");
        level = 0;
        UserData.currentswordlevel = level;
    }
}
