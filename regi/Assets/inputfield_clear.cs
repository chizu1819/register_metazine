using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class inputfield_clear : MonoBehaviour
{
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
 
    public void GetText()
    {
        //InputField コンポーネントを取得
        InputField form = GameObject.Find("InputField").GetComponent<InputField>();
        form.text = "";
        
        InputField form_1 = GameObject.Find("InputField (1)").GetComponent<InputField>();
        form_1.text = "";

        InputField form_2 = GameObject.Find("InputField (2)").GetComponent<InputField>();
        form_2.text = "";

        InputField form_3 = GameObject.Find("InputField (3)").GetComponent<InputField>();
        form_3.text = "";
    }
    
 
 
}