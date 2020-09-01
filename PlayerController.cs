  
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]

[RequireComponent(typeof(ParticleSystem))]
public class PlayerController : MonoBehaviour
{
    public float smooth;
    public float jumpForce;
    public float gravityAcceleration;
    public float maxGravity;
    private Vector3 m_TargetPosition;
    private float m_DownwardVeclocity;
    private bool m_Pause;
    [SerializeField] ParticleSystem collectParticle=null;

    private SpriteRenderer m_Sprite;
    private ParticleSystem m_Particles;
    // Start is called before the first frame update
    #region Unity Functions
    private void OnTriggerEnter2D(Collider2D _col)
    {
       

        if (_col.gameObject.tag.Equals("battu1"))
        {
            //Collect();
            //collectParticle.transform = gameObject.transform;
            //collectParticle.Play();
           // ParticleSystem no1= Instantiate(collectParticle,transform.position,Quaternion.identity);
            //no1.Play();
            Debug.Log("no tung");
          
        
        }

    }



    #endregion
    #region Public Functions
    public void Pause()
    {
        m_Sprite.enabled = false;
        m_Particles.Play();
        m_Pause = true;
    }
    public void Reset()
    {
        m_Pause = false;
        m_Sprite.enabled = true;
        m_TargetPosition = Vector3.up * -4;
        transform.position = m_TargetPosition; 
    }
    public void OnInit()
    {
        m_TargetPosition = transform.position;
        m_Sprite = GetComponent<SpriteRenderer>();
        m_Particles = GetComponent<ParticleSystem>();
    }
    public void OnUpdate()
    {
        if (m_Pause) return;
       // Debug.Log(transform.position);
        Jump();
        if(Jump())
        {
            ParticleSystem no1= Instantiate(collectParticle,transform.position,Quaternion.identity);
            no1.Play();
        }
        Fall();
        Move();
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Collect();
        }
        */
    }



    #endregion
    #region Private Functions
    /*private void Collect()
    { collectParticle.Play(); }
    */
    private bool Jump() {
            if(Input.GetMouseButtonUp(0)|| Input.GetKeyDown(KeyCode.Space))
        {
            m_TargetPosition.y = transform.position.y + jumpForce;
            m_DownwardVeclocity = 0;
            return true;

        }else return false;
    }
        private void Fall() {
        m_DownwardVeclocity += gravityAcceleration;
        m_DownwardVeclocity = Mathf.Clamp(m_DownwardVeclocity,0,maxGravity);
        m_TargetPosition.y -= m_DownwardVeclocity * Time.deltaTime;
        if (m_TargetPosition.y < -4) m_TargetPosition.y = -4;
    }
        private void Move() {
        transform.position = Vector3.Lerp(transform.position,m_TargetPosition,smooth*Time.deltaTime);
    } 

    #endregion
}
