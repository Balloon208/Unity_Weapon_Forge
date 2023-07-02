using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    private Image[] image = new Image[3];
    public Color Oncolor;
    public Color Offcolor;
    public GameObject[] UI = new GameObject[3];
    public GameObject[] BackgroundObject = new GameObject[3];

    // Update is called once per frame

    public void Start()
    {
        for(int i=0; i<3; i++)
        {
            image[i] = BackgroundObject[i].GetComponent<Image>();
        }
    }
    public void ChangeUI(int n)
    {
        bool locked = false;
        for(int i = 0; i < 3; i++)
        {
            if (i == n)
            {
                UI[i].SetActive(true);
                image[i].color = Oncolor;
            }
            else
            {
                UI[i].SetActive(false);
                image[i].color = Offcolor;
            }
        }
    }
}
