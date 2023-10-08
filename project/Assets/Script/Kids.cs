using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kids : MonoBehaviour
{
    private Vector3 m_setpos;   // �v���C���[����̋���
    private Kids m_Next;        // �l�N�X�g
    private Kids m_prev;        // ��O
    private int m_Idx;           // �ԍ�

    [SerializeField]
    private int nAddCount;  // ���Z�|�C���g��

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
        // ���W�̈ړ�
        Vector3 pos = transform.position;
        // �v���C���[�����ʒu�܂ł̍X�V
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // �v���C���[���擾

        if (player != null)
        {// �擾�ł����ꍇ
            Vector3 vec = ((player.transform.position + m_setpos) - transform.position);
            pos.x += vec.x * 0.065f;
            pos.y += vec.y * 0.065f;
        }

        transform.position = pos;
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
            KidsManager kidsManager = KidsManager.Instance; // �v���C���[���擾
            kidsManager.ListOut(this);

            ScoreManager scoremanager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>(); // �}�l�[�W���[���擾
            scoremanager.AddScore(-nAddCount);
            Destroy(gameObject);
        }
    }
}
