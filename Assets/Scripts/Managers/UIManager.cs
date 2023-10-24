using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text coinsCoin;

    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public Slider health;
    public void UpdateHealth(float _health)
    {
        health.value = _health; 
    }

    private void Start()
    {
        
    }

    public void UpdateCoins(int  amount)
    {
        coinsCoin.text="Coins: "+amount.ToString();
    }
}
