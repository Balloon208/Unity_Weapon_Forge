using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUI : MonoBehaviour
{
    public GameObject currentUI;
    public GameObject AfterUI;

    public void Change()
    {
        currentUI.SetActive(false);
        AfterUI.SetActive(true);
    }
}
