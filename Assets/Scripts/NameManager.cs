using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static string _name1 = "プレイヤー1";
    public static string _name2 = "プレイヤー2";
    //[SerializeField] Text _text1 = default;
    //[SerializeField] Text _text2 = default;

    public void SetName1(InputField input1)
    {
        NameManager._name1 = input1.text;
    }

    public void SetName2(InputField input2)
    {
        NameManager._name2 = input2.text;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
