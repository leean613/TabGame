
using UnityEngine;

public class pickups : MonoBehaviour
{
    private GameController m_Game;
    private bool didCollect;

    [SerializeField] ParticleSystem collectParticle=null;

    //get gamecontroller with intergrity
    protected GameController game
    {
        get
        {
            if(!m_Game)
            {
                m_Game =  GameController.instance;
            }
            if (!m_Game) Debug.LogWarning("khong ton tai game controller");
            return m_Game;
        }
    }
    #region Unity Functions
    private void OnTriggerEnter2D(Collider2D _col)
    {   
        if (!game) return;
        //Debug.Log("bat va cham1");

        if (didCollect) return;
        //Debug.Log("bat va cham2");
       
        if (_col.gameObject.tag.Equals("Player"))
        {
           
            Debug.Log("bat va cham3");
            didCollect = true;
            OnPlayerCollect();
            Collect();
          //  Destroy(gameObject, GetComponent<ParticleSystem>().duration);
            Destroy(gameObject);
           
        }

    }
    #endregion
    #region Override Funtions
    protected virtual void OnPlayerCollect()
    {
        Debug.Log("Player picked up ["+gameObject.name +"].");
    }

    #endregion
    private void Collect()
    {
        ParticleSystem no1 = Instantiate(collectParticle, transform.position, Quaternion.identity);
        no1.Play();
      

    }
  
}
    
