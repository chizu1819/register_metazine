using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle : MonoBehaviour
{
    //panelにつけたスクリプト
    //toggleをonするとscrollviewに表示されるとかの処理

   public Toggle toggle1;
   public GameObject panel2,scrollcontent2;
   public GameObject Title,Price,Name;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnToggleChanged()
    {
        if(toggle1.isOn)
        {
            //toggleがonされたら、panel2のprefabを生成、その作品名などなどを入れる

           GameObject ParentObject = GameObject.Find("Content2");

           GameObject prefab2 = (GameObject)Instantiate (panel2);
            prefab2.transform.SetParent (ParentObject.transform, false); 
            //作品名
            prefab2.transform.GetChild(0).gameObject.GetComponent<Text>().text=Title.gameObject.GetComponent<Text>().text;
            //作家名
            prefab2.transform.GetChild(5).gameObject.GetComponent<Text>().text=Name.gameObject.GetComponent<Text>().text;
            //値段
            prefab2.transform.GetChild(1).gameObject.GetComponent<Text>().text=Price.gameObject.GetComponent<Text>().text;
        }

        else
        {
            //Debug.Log(Title.gameObject.GetComponent<Text>().text);

            GameObject[] DetailChild;
            GameObject ParentObject = GameObject.Find("Content2");
            DetailChild = new GameObject[ParentObject.transform.childCount];
            for (int i=0; i<ParentObject.transform.childCount; i++)
            {
                DetailChild[i] = ParentObject.transform.GetChild(i).gameObject;
            }
            
            for(int q=0; q<DetailChild.Length; q++)
            {
                if(Title.gameObject.GetComponent<Text>().text == DetailChild[q].transform.GetChild(0).gameObject.GetComponent<Text>().text)
                {
                    //toggleがoffになった作品が、scrollviewの何番目にいるかを取得
                    //その番目のobjectを消す

                    //Debug.Log(q);
                    Destroy(DetailChild[q]);
                }
                else
                {
                    //Debug.Log("tigau！");
                }
            }

        }
    }
}
