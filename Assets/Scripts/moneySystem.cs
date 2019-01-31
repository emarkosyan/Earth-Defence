using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneySystem : MonoBehaviour {

    public Text money_UI, sputnik_UI, earth_UI;
    public int money;
    Canvas_controller cvc;
	void Start () {
        money = 100;
        DrawMoney(money_UI, money);
        DrawMoney(earth_UI, upgradePrice);
        DrawMoney(sputnik_UI, sputnikPrice);
        cvc = gameObject.GetComponent<Canvas_controller>();
    }

    void DrawMoney(Text UI_text, int price)
    {
        UI_text.text = " " + price + "$";
    }

    public void giveMoney(int wave)
    {
        money += (wave + earthLevel) * 10;
        DrawMoney(money_UI, money);
    }
    int earthLevel, upgradePrice = 30;
    public void upgradeEarth()
    {
        if (money >= upgradePrice)
        {
            cvc.Shop_Click.PlayOneShot(cvc.shop_click_Enough_money);
            money -= upgradePrice;
            earthLevel++;
            upgradePrice *= 2;
            DrawMoney(money_UI, money);
            DrawMoney(earth_UI, upgradePrice);
        }
        else
        {
            cvc.Shop_Click.PlayOneShot(cvc.shop_click_not_money);
        }
    }

    public int sputnikPrice = 10;
    public void buySputnik()
    {
        money -= sputnikPrice;
        sputnikPrice *= 2;
        DrawMoney(money_UI, money);
        DrawMoney(sputnik_UI, sputnikPrice);
    }
    public void DestroySputnik()
    {
        sputnikPrice /= 2;
        DrawMoney(sputnik_UI, sputnikPrice);
    }
}
