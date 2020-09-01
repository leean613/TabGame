
using UnityEngine;
using UnityEngine.UI;
using UnityCore.Session;
using UnityCore.Menu;
using System.Threading.Tasks;


public class GameController : MonoBehaviour
{
    public PlayerController player;
    public CameraController camera;
    public int score { get; private set; }
    public Text scoreText;
    public Text battuTime;

    public Text battu;
    public Text Xscore;

    //public ObstacleController pickups;

    public PageController pages;
    public ObstacleController obstacles;
    private SessionController m_Session;
    private int m_process=-1;
    public static GameController instance;
    private float m_thoigianbattu=0;
    private float m_thoigianXscore=1;
    private bool m_batu=false;
    private int m_xscore=1;
    public int pickupDroprate=3;
    private bool m_DidDropPickUp;
    public bool m_GameOver;
    public int dempickup=0;



    private SessionController session

    {
        get
        {
            if (!m_Session) m_Session = SessionController.instance;
            if (!m_Session) Debug.LogWarning("game is trying to aceess this session, but no instance of SessionController was found");


            return m_Session;
        }
    }
    #region unity Functions
    private void Start()
    {
        if (!session) return;
        session.InitializeGame(this);
    }
    private void Awake()
    {
        if (!instance) instance = this;
    }

    #endregion
    #region Public Functions
    public void OnPlayerHitObstacle()
    {   if (m_batu) return;
        Debug.Log("chay endgame trong game controller");
        obstacles.Reset();
        Endgame();

    }
    public void TryAgain()
    {


        //Endgame();
        Reset();
    }
    public void OnInit()
    {

        player.OnInit();
        camera.OnInit();
        obstacles.AddObstacke(m_process);
    }
    public void HandleXscore(int _multiplier,float _duration)
    {
        m_thoigianbattu = 0;
        m_batu = false;
        m_xscore = _multiplier;
        m_thoigianXscore = _duration;
    }
    public void HandleBattu(float _duration)
    {
        m_thoigianbattu = _duration;
        m_batu = true;
       // m_thoigianXscore = 0;
        m_xscore = 1;

    }
    public void OnUpdate()
    {
        player.OnUpdate();
        camera.OnUpdate();
        CHeckPlayerProgress();
        DetectPlayerFall();
        //battuTime.text = m_thoigianbattu.ToString("#.##");
        //battu.text = m_batu.ToString();
        //Xscore.text = m_xscore.ToString();
        EnforcePickupRules();
    }

    #endregion

    #region Private Functions
    private void CHeckPlayerProgress()
    {
        if (player.transform.position.y / obstacles.interval > (m_process + 1)){
            m_process++;
            score += m_xscore;
            scoreText.text = score.ToString();
          
            obstacles.AddObstacke(m_process);
        }

        if (m_process > 0 && ((m_process % pickupDroprate) == 0))
        {
            if (!m_DidDropPickUp)
            {
                m_DidDropPickUp = true;
                obstacles.AddsPickups(m_process);
                dempickup++;
              //    Debug.Log("pick up duoc add" + dempickup);

            }
        }
        else m_DidDropPickUp = false;
    }
    private void DetectPlayerFall()
    {
        //  Debug.Log("chay detect");
        if (camera.transform.position.y - player.transform.position.y >5)
        {
            Endgame();
            Debug.Log("out of screeen");
        }
    }
    private async void Endgame()
    {
        if (m_GameOver) return;
        else m_GameOver = true;
        player.Pause();
        await Task.Delay(1500);
        pages.TurnPageOn(PageType.GameOver);

        // Reset();
    }
    private void Reset()
    {
        m_process = -1;

     
        score = 0;

        scoreText.text = score.ToString();
        obstacles.Reset();
       camera.Reset();
       player.Reset();
        m_GameOver = false;
    }
    private void EnforcePickupRules()
    {
        float _dt = Time.deltaTime;
        if(m_thoigianbattu>0) m_thoigianbattu -= _dt;
        if(m_xscore!=1) m_thoigianXscore -= _dt;
       
        battuTime.text = m_thoigianbattu.ToString("#.##");
        battu.text = m_batu.ToString();
        Xscore.text = m_xscore.ToString();
        
        
    if (m_thoigianXscore <= 0 && m_xscore!=1)
        {
            m_xscore = 1;
          
        }
        if (m_thoigianbattu <= 0) m_thoigianbattu = 0;
        if (m_thoigianbattu <= 0 && m_batu)
        {
            m_batu = false;
            m_thoigianbattu = 0;
        }
    }
    #endregion


}
