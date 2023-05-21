using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGold : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UserData.gold += UserData.tapgold;
        }
    }
}
