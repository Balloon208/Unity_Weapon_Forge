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

    }
}