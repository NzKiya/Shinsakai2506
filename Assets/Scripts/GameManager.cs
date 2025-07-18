using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�R�}���h�̌��z��
    [SerializeField] public int m_commandNum = default;
    int[] m_commandList;
    //�F�ݒ�
    [SerializeField] public Color m_colorUp = Color.blue;
    [SerializeField] public Color m_colorRight = Color.red;
    [SerializeField] public Color m_colorDown = Color.yellow;
    [SerializeField] public Color m_colorLeft = Color.green;
    //���͉\���ǂ���
    public bool m_gamePlaying = false;

    public float m_timer = 0f;
    [SerializeField] public float m_timeLimit = default;
    GameObject m_timerObj;
    
    CommandManager m_cm1;
    CommandManager m_cm2;

    Text m_centerText;

    // Start is called before the first frame update
    void Start()
    {
        //[task]Start()����GameStart()�Ɉړ����ăJ�E���g�_�E����ɑ���J�n

        //�^�C�}�[�e�L�X�g�I�u�W�F�N�g
        m_timerObj = GameObject.Find("TimerText");
        var centerText = GameObject.Find("CenterText");
        m_centerText = centerText.GetComponent<Text>();
        
        GenerateCommand();        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gamePlaying)
        {
            GameUpdate();

            //���ҕ\��
            if (m_timer > m_timeLimit)
            {
                m_gamePlaying = false;

                if (m_cm1.m_score == m_cm2.m_score)
                {
                    Debug.Log("Draw");
                    this.gameObject.GetComponent<ShowResult>().EndEffect("��������");
                }
                else if (m_cm1.m_score > m_cm2.m_score)
                {
                    Debug.Log("Player1 wins!");
                    this.gameObject.GetComponent<ShowResult>().EndEffect(NameManager._name1);
                }
                else
                {
                    Debug.Log("Player2 wins!");
                    this.gameObject.GetComponent<ShowResult>().EndEffect(NameManager._name2);
                }
            }
        }
  
    }

    void GenerateCommand()
    {
        //�R�}���h�̌��z����쐬���A�v���C���[���̃R�}���h�ɕ�������
        var player1 = GameObject.Find("Player1");
        var player2 = GameObject.Find("Player2");
        m_cm1 = player1.GetComponent<CommandManager>();
        m_cm2 = player2.GetComponent<CommandManager>();

        m_commandList = new int[m_commandNum];
        m_cm1.m_commandPlayer = new int[m_commandNum];
        m_cm2.m_commandPlayer = new int[m_commandNum];

        for (int i = 0; i < m_commandNum; i++)
        {
            m_commandList[i] = Random.Range(0, 3);
            m_cm1.m_commandPlayer[i] = m_commandList[i];
            m_cm2.m_commandPlayer[i] = m_commandList[i] + 2;
        }        
    }

    void GameUpdate()
    {
        //[task]���҂�\������v���O������ǉ��iUI�j

        m_timer += Time.deltaTime;

        //�c�莞�ԕ\��
        Text timerText = m_timerObj.GetComponent<Text>();
        float timeLeft = m_timeLimit - m_timer;
        if (timeLeft < 0)
        {
            timerText.text = 0f.ToString("N2");
        }
        else
        {
            timerText.text = timeLeft.ToString("N2");
        }
    }
}
