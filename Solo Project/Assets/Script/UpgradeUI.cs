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

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            image[i] = BackgroundObject[i].GetComponent<Image>();
        }

        UI[1].SetActive(false);
        UI[2].SetActive(false);
        image[1].color = Offcolor;
        image[2].color = Offcolor;
    }

    public void ChangeUI(int n)
    {
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
