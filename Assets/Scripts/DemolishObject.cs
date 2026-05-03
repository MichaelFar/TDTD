using TMPro;
using UnityEngine;

public class DemolishObject : MonoBehaviour
{
   
    public GameObject textLabel;
    private float _priceToDemolish = 10.0f; // field

    public float priceToDemolish   // property
    {
        get
        {
            return _priceToDemolish;
        }  // get method
        set
        {

            _priceToDemolish = value;
            textLabel.GetComponent<TextMeshProUGUI>().text = "Clear " + value + " gold";
        }  // set method
    }

    public float demolishPrice = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        priceToDemolish = demolishPrice;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
