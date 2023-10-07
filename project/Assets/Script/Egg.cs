using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private Vector3 m_move; // �ړ���
    private int m_MoveCnt;  // �ړ��J�E���g
    [SerializeField]
    private GameObject m_SpawnKidsPrefab;    // ��������q���v���n�u

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_MoveCnt < 0)
        {
            // �v���C���[�����ʒu�܂ł̍X�V
            GameManager gamemanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); // �}�l�[�W���[���擾
            int nSpawnCnt = Kids.SpawnCnt;

            // �q������
            GameObject obj = Instantiate(m_SpawnKidsPrefab, transform.position, Quaternion.identity);

            Kids kids = obj.GetComponent<Kids>();
            kids.Set(transform.position, new Vector3(-2.0f - nSpawnCnt / (gamemanager.HeightCnt)
                , -((gamemanager.HeightCnt - 1) * 0.5f) + (nSpawnCnt % (gamemanager.HeightCnt)), 0.0f));

            // ���g������
            Destroy(gameObject);
        }
        else
        {
            Vector3 pos = transform.position;
            pos += m_move;
            m_move *= 0.99f;
            m_MoveCnt--;

            transform.position = pos;
        }
    }

    public void Set(Vector3 pos, Vector3 move)
    {
        transform.position = pos;
        m_move = move;
        m_MoveCnt = 240;
    }
}
