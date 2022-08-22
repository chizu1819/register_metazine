using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdownManager : MonoBehaviour
{
    //LogSceneの 年月日の dropdownのスクリプト
    //GameObjectにアタッチ

    public Dropdown dropDownYear;
    public Dropdown dropDownMonth;
    public Dropdown dropDownDay;

    int year;
    int month;
    int day;

    // Use this for initialization
    void Start () {

        if (dropDownYear) {
            dropDownYear.ClearOptions();    //現在の要素をクリアする
            List<string> list = new List<string>();
            for (int i = 2022; i < 2023; i++) 
            {
                list.Add (i.ToString ());
            }
            dropDownYear.AddOptions(list);  //新しく要素のリストを設定する
            dropDownYear.value = 0;         //デフォルトを設定(0～n-1)
        }

        if (dropDownMonth) {
            dropDownMonth.ClearOptions();    //現在の要素をクリアする
            List<string> list = new List<string>();
            for (int i = 8; i <= 8; i++) 
            {
                list.Add (i.ToString ());
            }
            dropDownMonth.AddOptions(list);  //新しく要素のリストを設定する
            dropDownMonth.value = 0;         //デフォルトを設定(0～n-1)
        }

        if (dropDownDay) {
            dropDownDay.ClearOptions();    //現在の要素をクリアする
            List<string> list = new List<string>();
            for (int i = 20; i <= 31; i++) 
            {
                list.Add (i.ToString ());
            }
            dropDownDay.AddOptions(list);  //新しく要素のリストを設定する
            dropDownDay.value = 0;         //デフォルトを設定(0～n-1)
        }

    }

}
