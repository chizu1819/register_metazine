using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panel2 : MonoBehaviour
{
    public Text priceT;
    public Text AllpriceT;

    [SerializeField] Dropdown dropdown;

    void Start()
    {
        priceT = priceT.GetComponent<Text> ();
        AllpriceT = AllpriceT.GetComponent<Text> ();

        AllpriceT.text= priceT.text;
    }

    
    void Update()
    {
        //AllpriceT.text= priceT.text;
    }

    public void OnValueChanged()
    {
        //Debug.Log(dropdown.value + 1);

        int Allprice = int.Parse(priceT.text) * (dropdown.value + 1);

        AllpriceT.text= Allprice.ToString();
    }
}
