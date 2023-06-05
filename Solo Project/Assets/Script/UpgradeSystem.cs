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

        if(UserData.gold >= Cost[UserData.Gupgrade[number]])
        {
            UserData.gold -= Cost[UserData.Gupgrade[number]];
            UserData.Gupgrade[number]++;

            Debug.Log(number + " Upgraded to " + UserData.Gupgrade[number]);
        }
    }
}