using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject[] UI = new GameObject[3];

    // Update is called once per frame
    public void ChangeUI(int n)
    {
        for(int i = 0; i < 3; i++)
        {
            if(i == n) UI[i].SetActive(true);
            else UI[i].SetActive(false);
        }
        
    }
}
