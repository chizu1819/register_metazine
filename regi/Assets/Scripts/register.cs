using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class register : MonoBehaviour
{
    //オブジェクトと結びつける
    public InputField productIF;
    public Text productT;

    public InputField authorIF;
    public Text authorT;

    public InputField numberIF;
    public Text numberT;

    public InputField priceIF;
    public Text priceT;

    public Text productT2,authorT2,numberT2,priceT2;

    void Start () 
    {
        //Componentを扱えるようにする
        productIF = productIF.GetComponent<InputField> ();
        productT = productT.GetComponent<Text> ();

        authorIF = authorIF.GetComponent<InputField> ();
        authorT = authorT.GetComponent<Text> ();

        numberIF = numberIF.GetComponent<InputField> ();
        numberT = numberT.GetComponent<Text> ();

        priceIF = priceIF.GetComponent<InputField> ();
        priceT = priceT.GetComponent<Text> ();

    }

    public void InputText()
    {
        //テキストにinputFieldの内容を反映
        productT.text = productIF.text;
        authorT.text = authorIF.text;
        numberT.text = numberIF.text;
        priceT.text = priceIF.text;

        productT2.text = "作品名　" + productT.text;
        authorT2.text = "作家名　" + authorT.text;
        numberT2.text = "在庫数　" + numberT.text;
        priceT2.text = "値段　　" + priceT.text;

    }

    public void SetActive(GameObject penel)
    {
        penel.SetActive(false);
    }
}
