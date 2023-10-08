using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kids : MonoBehaviour
{
    private Vector3 m_setpos;   // �v���C���[����̋���
    private Kids m_Next;        // �l�N�X�g
    private Kids m_prev;        // ��O
    private int m_Idx;           // �ԍ�
    private Vector3 m_move;   // �ړ���
    [SerializeField]
    private int nAddCount;  // ���Z�|�C���g��
    [SerializeField]
    public GameObject particlePrefab; // �p�[�e�B�N���V�X�e���̃v���n�u��Inspector����ݒ�

    public Kids Next
    {
        get { return m_Next; }
        set { m_Next = value; }
    }

    public Kids Prev
    {
        get { return m_prev; }
        set { m_prev = value; }
    }

    public Vector3 SetPos
    {
        get { return m_setpos; }
        set { m_setpos = value; }
    }

    public int Idx
    {
        get { return m_Idx; }
        set { m_Idx = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_move.x = 0;
        m_move.y = 0;
        m_move.z = 0;
        // ���W�̈ړ�
        Vector3 rot = transform.eulerAngles;
        
        transform.eulerAngles = rot;

        KidsManager kidsManager = KidsManager.Instance; // �v���C���[���擾
        kidsManager.ListIn(this);

        ScoreManager scoremanager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>(); // �}�l�[�W���[���擾
        scoremanager.AddScore(nAddCount);
    }

    // Update is called once per frame
    void Update()
    {
        Kids kids = m_prev;
        int nCount;
        for (nCount = 0; nCount < GameManager.Instance.HeightCnt; nCount++)
        {
            if (kids != null)
            {
                kids = kids.m_prev;
            }
            else
            {
                break;
            }
        }
      
        // ���W�̈ړ�
        Vector3 pos = transform.position;
        // �v���C���[�����ʒu�܂ł̍X�V
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // �v���C���[���擾

        if (player != null)
        {// �擾�ł����ꍇ
            if(nCount == GameManager.Instance.HeightCnt)
            {
                if (kids != null)
                {
                    Vector3 vec = kids.transform.position - transform.position;
                    Vector3 dis = vec;
                    float fDis = 0.0f;
                    if (dis.x < 0)
                    {
                        dis.x *= -1;
                    }
                    if (dis.y < 0)
                    {
                        dis.y *= -1;
                    }
                    fDis += dis.x;
                    fDis += dis.y;
                    if (fDis >= 2.5f)
                    {
                        pos.x += vec.x * 0.065f;
                        pos.y += vec.y * 0.065f;
                    }
                }
                else
                {
                    Vector3 vec = ((player.transform.position ) - transform.position);
                    Vector3 dis = vec;
                    float fDis = 0.0f;
                    if (dis.x < 0)
                    {
                        dis.x *= -1;
                    }
                    if (dis.y < 0)
                    {
                        dis.y *= -1;
                    }
                    fDis += dis.x;
                    fDis += dis.y;
                    if (fDis >= 2.5f)
                    {
                        m_move.x += vec.x * 0.0003f;
                        m_move.y += vec.y * 0.0003f;
                    }
                }
            }
            else
            {
                m_setpos.x = 0.0f;
                Vector3 vec = ((player.transform.position +m_setpos) - transform.position);
                Vector3 dis = vec;
                float fDis = 0.0f;
                if (dis.x < 0)
                {
                    dis.x *= -1;
                }
                if (dis.y < 0)
                {
                    dis.y *= -1;
                }
                fDis += dis.x;
                fDis += dis.y;
                if (fDis >= 2.5f)
                {
                    m_move.x += vec.x * 0.0003f;
                    m_move.y += vec.y * 0.0003f;
                }
            }
           
        }
        pos += m_move;
        transform.position = pos;
        m_move *= 0.98f;
    }

    public void Set(Vector3 pos, Vector3 setpos)
    {
        transform.position = pos;
        m_setpos = setpos;
    }

    private void OnTriggerEnter(Collider colider)
    {
        // �G���ǂ����m�F
        if (colider.gameObject.CompareTag("Enemy") || colider.gameObject.CompareTag("Obstacle"))
        {
            // �v���n�u���C���X�^���X��
            GameObject particleSystemInstance = Instantiate(particlePrefab);

            // �p�[�e�B�N���V�X�e�����A�N�e�B�u�ɂ���
            ParticleSystem particleSystem = particleSystemInstance.GetComponent<ParticleSystem>();
            particleSystemInstance.transform.position = transform.position;
            particleSystem.Play();

            KidsManager kidsManager = KidsManager.Instance; // �v���C���[���擾
            kidsManager.ListOut(this);

            ScoreManager scoremanager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>(); // �}�l�[�W���[���擾
            scoremanager.AddScore(-nAddCount);
            Destroy(gameObject);
        }
    }
}
