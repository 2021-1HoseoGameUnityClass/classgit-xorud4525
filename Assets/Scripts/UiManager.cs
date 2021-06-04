using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    private static UiManager _instance = null;
    public static UiManager instance { get { return _instance; } }

    [SerializeField]
    private GameObject[] playerHP_Objs = null;
    private void Awake()
    {
        _instance = this;
    }
    
    public void PlayerHP()
    {
        int minusHP = 3 - DetaManager.instance.playerHP;
        for(int i=0;i<minusHP;i++)
        {
           playerHP_Objs[i].SetActive(false);
        }
    }
}
