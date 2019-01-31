using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sputnikScr : MonoBehaviour
{

    public GameObject sputnik;
    public Canvas_controller cvc;

    public moneySystem ms;
    public void createNewSputnik()
    {
        if (ms.money >= ms.sputnikPrice)
        {
            cvc.Shop_Click.PlayOneShot(cvc.shop_click_Enough_money);

            GameObject sputnikClone = Instantiate(sputnik);
            sputnikClone.transform.position = transform.position;
            sputnikClone.transform.SetParent(transform);

            float ankyun = 360f / transform.childCount;

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.GetChild(i).transform.Rotate(0, 0, i * ankyun);
            }

            ms.buySputnik();
        }
        else
        {
            cvc.Shop_Click.PlayOneShot(cvc.shop_click_not_money);
        }
       
    }
}
