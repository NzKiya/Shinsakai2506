using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{    
    [SerializeField] KeyCode m_keyUp = default;
    [SerializeField] KeyCode m_keyRight = default;
    [SerializeField] KeyCode m_keyDown = default;
    [SerializeField] KeyCode m_keyLeft = default;

    [SerializeField] GameObject m_boxObject = default;
    [SerializeField] Vector2 m_firstBoxPosition = default;
    [SerializeField] float m_boxDistance = default;

    GameManager m_gameManager;
    Color m_colorUp;
    Color m_colorRight;
    Color m_colorDown;
    Color m_colorLeft;

    ScoreManager m_scoreManager;

    GameObject[] m_boxes = new GameObject[4];
    
    public int[] m_commandPlayer;
    int m_commandNow = 0;
    int[] m_nextCommand = new int[4];
    public int m_score = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        var sm = GameObject.Find("ScoreManager");
        m_scoreManager = sm.GetComponent<ScoreManager>();
        //m_scoreManager.AddScore();

        var gm = GameObject.Find("GameManager");
        m_gameManager = gm.GetComponent<GameManager>();
        m_commandPlayer = new int[m_gameManager.m_commandNum];

        //コマンドボックスを生成
        for (int i = 0; i < 4; i++)
        {
            Vector3 boxPosition = new Vector3(0f, 0f, 0f);
            boxPosition.x = m_firstBoxPosition.x + m_boxDistance * i;
            boxPosition.y = m_firstBoxPosition.y;

            m_boxes[i] = Instantiate(m_boxObject, boxPosition, Quaternion.identity);
            m_boxes[i].GetComponent<SpriteRenderer>().enabled = false;

            m_nextCommand[i] = i;
        }

        //色を設定
        m_colorUp = m_gameManager.m_colorUp;
        m_colorRight = m_gameManager.m_colorRight;
        m_colorDown = m_gameManager.m_colorDown;
        m_colorLeft = m_gameManager.m_colorLeft;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gameManager.m_gamePlaying)
        {
            for (int i = 0; i < 4; i++)
            {
                m_boxes[i].GetComponent<SpriteRenderer>().enabled = true;
            }

            CommandBoxUpdate();

            if (CommandEntered())
            {
                m_commandNow++;
                if (m_commandNow > 99)
                {
                    m_commandNow = 0;
                }
                m_score++;
                m_scoreManager.AddScore();

            }
        }
    }

    void CommandBoxUpdate()
    {
        for (int i = 0; i < m_nextCommand.Length; i++)
        {
            m_nextCommand[i]++;
            
            if (m_nextCommand[i] > 99)
            {
                m_nextCommand[i] = 0;
            }
        }

        //コマンドボックスを更新
        for (int i = 0; i < 4; i++)
        {
            var boxSR = m_boxes[i].GetComponent<SpriteRenderer>();

            if (m_commandPlayer[m_commandNow + i] % 4 == 0)
            {
                m_boxes[i].transform.eulerAngles = new Vector3(0, 0, 0);
                boxSR.color = m_colorUp;
            }
            else if (m_commandPlayer[m_commandNow + i] % 4 == 1)
            {
                m_boxes[i].transform.eulerAngles = new Vector3(0, 0, 270);
                boxSR.color = m_colorRight;
            }
            else if (m_commandPlayer[m_commandNow + i] % 4 == 2)
            {
                m_boxes[i].transform.eulerAngles = new Vector3(0, 0, 180);
                boxSR.color = m_colorDown;
            }
            else if (m_commandPlayer[m_commandNow + i] % 4 == 3)
            {
                m_boxes[i].transform.eulerAngles = new Vector3(0, 0, 90);
                boxSR.color = m_colorLeft;
            }
        }
    }

    bool CommandEntered()
    {
        //正しいキーが入力されたら
        if (Input.GetKeyDown(m_keyUp) && m_commandPlayer[m_commandNow] % 4 == 0)
        {
            if (!Input.GetKeyDown(m_keyRight) && !Input.GetKeyDown(m_keyDown) && !Input.GetKeyDown(m_keyLeft))
            {
                return true;
            }
        }

        if (Input.GetKeyDown(m_keyRight) && m_commandPlayer[m_commandNow] % 4 == 1)
        {
            if (!Input.GetKeyDown(m_keyUp) && !Input.GetKeyDown(m_keyDown) && !Input.GetKeyDown(m_keyLeft))
            {
                return true;
            }
        }

        if (Input.GetKeyDown(m_keyDown) && m_commandPlayer[m_commandNow] % 4 == 2)
        {
            if (!Input.GetKeyDown(m_keyUp) && !Input.GetKeyDown(m_keyRight) && !Input.GetKeyDown(m_keyLeft))
            {
                return true;
            }
        }

        if (Input.GetKeyDown(m_keyLeft) && m_commandPlayer[m_commandNow] % 4 == 3)
        {
            if (!Input.GetKeyDown(m_keyUp) && !Input.GetKeyDown(m_keyRight) && !Input.GetKeyDown(m_keyDown))
            {
                return true;
            }
        }

        return false;
    }
}
