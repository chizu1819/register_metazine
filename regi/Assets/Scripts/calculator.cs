using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;//時間を扱うとき必要

public class calculator : MonoBehaviour
{
    public Text allpriceT;
    public Text cashT;
    public Text balanceT; //お釣り

    // 式入力テキスト
    public Text Formula;
    // 各数字ボタン
    public Button[] bNumber;
    // クリアボタン
    public Button bClear;

    //時間取得系
    DateTime dt;//日付を代入する変数（DateTime構造体）
    public Text yaerT;
    public Text monthT;
    public Text dayT;

    void Start()
    {
        allpriceT= allpriceT.GetComponent<Text> ();
        cashT = cashT.GetComponent<Text> ();
        balanceT = balanceT.GetComponent<Text> ();

        balanceT.text = "";
        cashT.text = ""; 

        //Debug.Log(balance);       
    }

    void Update()
    {
        //現在日時を代入
        dt = DateTime.Now;

        yaerT.text = dt.Year.ToString();
        monthT.text = dt.Month.ToString();
        dayT.text = dt.Day.ToString();
    }

    // 数字ボタン押下
    public void InputNumber(Text number)
    {
        // 押下したボタンの数字を式欄に追記する
        cashT.text += number.text;

        int balance = int.Parse(cashT.text)-int.Parse(allpriceT.text);
        balanceT.text = balance.ToString();
    }

    // クリアボタン押下
    public void InputClear(Text equal)
    {
        //初期化
        balanceT.text = "";
        cashT.text = "";        
    }

    public void OnChancelClicked()
    {
        gameObject.SetActive (false);
    }
}
