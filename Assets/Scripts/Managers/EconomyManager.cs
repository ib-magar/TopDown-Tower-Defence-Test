
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance { get; private set; }

    private int coins;
    [SerializeField] int startCoins;

    public int Coins
    {
        get { return coins; }
        private set { coins = Mathf.Max(value, 0); }
    }

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

    
    private void Start()
    {
        coins = startCoins;
        UpdateCoinsUI(coins);
    }

    public void GainCoins(int amount=1)
    {
        Coins += amount;
        UpdateCoinsUI(coins);
    }

    public void ReduceCoins(int amount)
    {
        Coins -= amount;
        UpdateCoinsUI(coins);
    }
    public bool CheckPrice(int amount)
    {
        if(coins>=amount)
        {
           ReduceCoins(amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateCoinsUI(int amount)
    {
        UIManager.Instance.UpdateCoins(amount);
    }
}

