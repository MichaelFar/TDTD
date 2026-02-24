using TMPro;
using UnityEngine;

public class PlayerMoneyManager : MonoBehaviour
{
    float _player_current_money = 0.0f;

    public WaveText moneyLabel;
    public float playerCurrentMoney
        {
        get { return _player_current_money; }
            set {
            _player_current_money = value;
            moneyLabel.SetCurrentWave((int)(value));
        }
    }
    public float startingMoney = 100.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCurrentMoney = startingMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CheckIfCanPurchase(float price)
    {
        if(price <= playerCurrentMoney)
        {
            
            return true;
        }
        return false;
    }

    public void Purchase(float price)
    {
        playerCurrentMoney -= price;
    }

    public void Refund(float amount_to_refund)
    {
        playerCurrentMoney += amount_to_refund;
    }
}
