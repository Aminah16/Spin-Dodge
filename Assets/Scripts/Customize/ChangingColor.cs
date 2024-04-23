using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingColor : MonoBehaviour
{
    public GameObject panel;
    public SpriteRenderer head;

    public Color red;
    public Color green;
    public Color blue;
    public Color pink;
    public Color black;

    public int whatColor = 1;


    private void Update()
    {
        if (whatColor == 1)
        {
            head.color = red;
        } else if (whatColor == 2)
        {
            head.color = green;
        } else if (whatColor == 3)
        {
            head.color = blue;
        }
        else if (whatColor == 4)
        {
            head.color = pink;
        }
        else if( whatColor == 5)
        {
            head.color = black;
        }
    }
    // Start is called before the first frame update
    public void OpenPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void ChangeHeadRed()
    {
        whatColor = 1;
    }
    public void ChangeHeadGreen()
    {
        whatColor = 2;
    }
    public void ChangeHeadBlue()
    {
        whatColor = 3;
    }

    public void ChangeHeadPink()
    {
        whatColor = 4;
    }
    public void ChangeHeadBlack()
    {
        whatColor = 5;
    }
}