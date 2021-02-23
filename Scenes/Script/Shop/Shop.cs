using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopPanel;
    public int CurrentSelectionItem;
    public int CurrentItemCount;
    private player _player;

    // Start is called before the first frame update
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
             _player = other.GetComponent<player>();
            if (_player != null)
            {
                UiManager.IUnstance.openShop(_player.Diamonds);
            }
            ShopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ShopPanel.SetActive(false);
        }
        
    }
    public void Selection(int item)
    {
        switch (item)
        {
            case 0:
                UiManager.IUnstance.UpdateShopSelection(149);
                CurrentSelectionItem = 0;
                CurrentItemCount = 100;
                break;
            case 1:
                UiManager.IUnstance.UpdateShopSelection(38);
                CurrentSelectionItem = 1;
                CurrentItemCount = 200;
                break;
            case 2:
                UiManager.IUnstance.UpdateShopSelection(-88);
                CurrentSelectionItem = 2;
                CurrentItemCount = 300;
                break;
        }
        Debug.Log("hit shop");
    }
    public void BuyItem()
    {
        
        if (_player.Diamonds >= CurrentItemCount)
        {
            if (CurrentSelectionItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            _player.Diamonds -= CurrentItemCount;
            ShopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("shop close");
            ShopPanel.SetActive(false);
        }
    }
}
