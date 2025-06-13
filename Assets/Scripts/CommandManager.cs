using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CommandManager : MonoBehaviour
{
    //コマンドの総数
    [SerializeField] int  m_commandNum = default;
    //コマンドのリスト
    int[] m_commandList1;
    int[] m_commandList2;

    //今入力すべきコマンド
    int m_commandNow1 = 0;
    int m_commandNow2 = 0;
    //コマンド入力した数
    int m_slashCount1 = 0;
    int m_slashCount2 = 0;

    GameObject m_commandText = default;

    [SerializeField] Color m_colorUp = default;
    [SerializeField] Color m_colorRight = default;
    [SerializeField] Color m_colorDown = default;
    [SerializeField] Color m_colorLeft = default;
    //GameObject m_commandBoxes1 = default;

    [SerializeField] float m_timer = default;

    // Start is called before the first frame update
    void Start()
    {
        m_commandList1 = new int[m_commandNum];
        m_commandList2 = new int[m_commandNum];

        for (int i = 0; i < m_commandNum; i++)
        {
            m_commandList1[i] = Random.Range(0, 4);
            m_commandList2[i] = m_commandList1[i] + 2;
        }

        m_commandText = GameObject.Find("CommandText");
        //m_commandBoxes1 = GameObject.Find("CommandBoxes1");
    }

    // Update is called once per frame
    void Update()
    {
        //string cText = $"{m_commandList1[m_commandNow1]} {m_commandList1[m_commandNow1 + 1]} {m_commandList1[m_commandNow1 + 2]} {m_commandList1[m_commandNow1 + 3]} {m_commandList1[m_commandNow1 + 4]} {m_commandList1[m_commandNow1 + 5]} {m_commandList1[m_commandNow1 + 6]}" +
        //    $"\nslashCount {m_slashCount1}";
        //m_commandText.GetComponent<Text>().text = cText;
        //string cText = $"slashCount {m_slashCount1}";
        //m_commandText.GetComponent<Text>().text = cText;

        //var cb1sr = m_commandBoxes1.GetComponentsInChildren<SpriteRenderer>();
        //var cb1trans = m_commandBoxes1.GetComponentsInChildren<Transform>();
        var cb1sr = this.GetComponentsInChildren<SpriteRenderer>();
        var cb1trans = this.GetComponentsInChildren<Transform>();

        for (int i = 0; i <= 6; i++)
        {
            if (m_commandList1[m_commandNow1 + i] % 4 == 0)
            {
                cb1sr[i].color = m_colorUp;
                cb1trans[i + 1].eulerAngles = new Vector3(0, 0, 0);
            }
            else if (m_commandList1[m_commandNow1 + i] % 4 == 1)
            {
                cb1sr[i].color = m_colorRight;
                cb1trans[i + 1].eulerAngles = new Vector3(0, 0, 270);
            }
            else if (m_commandList1[m_commandNow1 + i] % 4 == 2)
            {
                cb1sr[i].color = m_colorDown;
                cb1trans[i + 1].eulerAngles = new Vector3(0, 0, 180);
            }
            else if (m_commandList1[m_commandNow1 + i] % 4 == 3)
            {
                cb1sr[i].color = m_colorLeft;
                cb1trans[i + 1].eulerAngles = new Vector3(0, 0, 90);
            }
        }

        Debug.Log(Time.time);
        if (Time.time <= m_timer)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (m_commandList1[m_commandNow1] % 4 == 0)
                {
                    m_commandNow1++;
                    m_slashCount1++;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (m_commandList1[m_commandNow1] % 4 == 1)
                {
                    m_commandNow1++;
                    m_slashCount1++;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (m_commandList1[m_commandNow1] % 4 == 2)
                {
                    m_commandNow1++;
                    m_slashCount1++;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (m_commandList1[m_commandNow1] % 4 == 3)
                {
                    m_commandNow1++;
                    m_slashCount1++;
                }
            }
        }        
    }
}
