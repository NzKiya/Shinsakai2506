using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] float m_waitTime = 2f;
    [SerializeField] float m_messageSetTime = 1f;
    [SerializeField] float m_messageGoTime = 1.5f;
    Text m_centerText;
    float m_timer = 0f;
    GameObject[] m_player = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        var centerText = GameObject.Find("CenterText");
        m_centerText = centerText.GetComponent<Text>();

        m_player[0] = GameObject.Find("Player1");
        m_player[1] = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        var gameManager = this.GetComponent<GameManager>();

        if (m_timer < m_waitTime)
        {
            m_centerText.text = "";
        }
        else if (m_timer < m_waitTime + m_messageSetTime)
        {
            m_centerText.text = "‚¢‚´Aqí‚É";
            foreach (var player in m_player)
            {
                var spriteChanger = player.GetComponent<SpriteChanger>();
                spriteChanger.ChangeSprite(1);

                var rb = player.GetComponent<Rigidbody2D>();
                rb.AddForce(spriteChanger.m_jumpForce, ForceMode2D.Impulse);
            }
        }
        else if (m_timer < m_waitTime + m_messageSetTime + m_messageGoTime)
        {
            foreach (var player in m_player)
            {
                //var spriteChanger = character.GetComponent<SpriteChanger>();
                //spriteChanger.ChangeSprite(1);

                var rb = player.GetComponent<Rigidbody2D>();
                rb.Sleep();

                player.GetComponent<CommandManager>().enabled = true;
            }

            //var player1 = GameObject.Find("Player1");
            //player1.GetComponent<CommandManager>().enabled = true;
            //var player2 = GameObject.Find("Player2");
            //player2.GetComponent<CommandManager>().enabled = true;

            if (!gameManager.m_gamePlaying)
            {
                gameManager.enabled = true;
                gameManager.m_gamePlaying = true;
            }

            var timerText = GameObject.Find("TimerText");
            timerText.GetComponent<Text>().enabled = true;
            var score1Text = GameObject.Find("Score1Text");
            score1Text.GetComponent<Text>().enabled = true;
            var score2Text = GameObject.Find("Score2Text");
            score2Text.GetComponent<Text>().enabled = true;

            var cursor1 = GameObject.Find("Cursor1");
            cursor1.GetComponent<SpriteRenderer>().enabled = true;
            var cursor2 = GameObject.Find("Cursor2");
            cursor2.GetComponent<SpriteRenderer>().enabled = true;

            var leafEffect = GameObject.Find("LeafEffect");
            leafEffect.GetComponent<ParticleSystem>().Pause();

            m_centerText.text = "Ÿ•‰I";
        }
        else
        {
            if (gameManager.m_gamePlaying)
            {
                m_centerText.text = "";
            }   
        }

        //if (gameManager.m_timer > gameManager.m_timeLimit)
        //{
            
        //}
    }
}
