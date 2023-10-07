using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kids : MonoBehaviour
{
    private Vector3 m_setpos;   // �v���C���[����̋���
    static private int m_nSpawnCnt = 0; // ���v������
    private Kids m_Next;        // �l�N�X�g
    private Kids m_prev;        // ��O

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

    static public int SpawnCnt
    {
        get { return m_nSpawnCnt; }
        set { m_nSpawnCnt = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // ���W�̈ړ�
        Vector3 rot = transform.eulerAngles;
        
        transform.eulerAngles = rot;

        KidsManager kidsManager = GameObject.FindGameObjectWithTag("KidsManager").GetComponent<KidsManager>(); // �v���C���[���擾
        kidsManager.ListIn(this);
        SpawnCnt += 1;
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
            pos.x += vec.x * 0.0075f;
            pos.y += vec.y * 0.0075f;
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
        if (colider.gameObject.CompareTag("Enemy"))
        {
            KidsManager kidsManager = GameObject.FindGameObjectWithTag("KidsManager").GetComponent<KidsManager>(); // �v���C���[���擾
            kidsManager.ListOut(this);
            Destroy(gameObject);
        }
    }
}
