using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    enum MType
    {
        Gold, SwordStone, DungeonStone
    }

    [SerializeField]
    private MType MaterialType;

    public int[] Cost;

    // Start is called before the first frame update
    public void Upgrade()
    {
        int number = this.gameObject.name.Split('_')[1][0] -'0';

        switch(MaterialType)
        {
            case MType.Gold:
                if(UserData.gold >= Cost[UserData.Gupgrade[number]])
                {
                    UserData.gold -= Cost[UserData.Gupgrade[number]];
                    UserData.Gupgrade[number]++;
                    if (number==0) // 성공 확률 증가 (공 추가)
                    {
                        if (UserData.Gupgrade[0] % 10 == 0 && UserData.Gupgrade[0] != 0) UserData.successball += 64;
                        else UserData.successball += 32;
                    }
                    if (number == 1) // 판매가격 증가
                    {
                        UserData.marginadd += UserData.Gupgrade[1];
                    }

                    Debug.Log(number + " Upgraded to " + UserData.Gupgrade[number]);
                }
                break;
            case MType.SwordStone:
                if (UserData.swordstone >= Cost[UserData.SSupgrade[number]])
                {
                    UserData.swordstone -= Cost[UserData.SSupgrade[number]];
                    UserData.SSupgrade[number]++;
                    if (number == 0) // 실패 확률 감소 (실패 공 감소)
                    {
                        UserData.removeball += 16;
                    }

                    Debug.Log(number + " Upgraded to " + UserData.SSupgrade[number]);
                }
                break;
            case MType.DungeonStone:

                break;
        }
    }
}