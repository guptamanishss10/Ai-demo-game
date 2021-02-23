using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
   private static UiManager _Instance;
   public static UiManager IUnstance
    {
        get
        {
            if (_Instance == null)
            {

            }
            return _Instance;
        }
    }
    public Text PlayerGemsCount;
    public Image Selection;
    public Text GemsCount;
    public Image[] Healthbars;
    

    
    public void openShop(int gemCount)
    {
        PlayerGemsCount.text = "" + gemCount + "G";
    }
    public void UpdateShopSelection(int yPos)
    {
        Selection.rectTransform.anchoredPosition = new Vector2(Selection.rectTransform.anchoredPosition.x, yPos);
    }
    private void Awake()
    {
        _Instance = this;
    }
    public void UpdateGemsCount(int count)
    {
        GemsCount.text = "" + count;
    }
    public void Updatelive(int liveRemaining)
    {
        for(int i = 0;i <= liveRemaining; i++)
        {
            if (i == liveRemaining)
            {
                Healthbars[i].enabled = false;
            }
        }
    }
} 
