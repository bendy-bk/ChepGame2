using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    public static UIManger instance;
    //public static UIManger Instance 
    //{ 
    //    get 
    //    {

    //        if (instance == null)
    //        {
    //            instance = FindObjectOfType<UIManger>();
    //        }
    //        return instance; 
    //    } 
    //}


    private void Awake()
    {
        instance = this;
    }


    [SerializeField] Text coinText;
    public void SetCoin(int coin)
    {
        coinText.text = coin.ToString();
    }
}
