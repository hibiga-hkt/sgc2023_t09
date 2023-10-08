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
            GameManager gamemanager = GameManager.Instance; // �}�l�[�W���[���擾

            // �q������
            GameObject obj = Instantiate(m_SpawnKidsPrefab, transform.position, Quaternion.identity);

            Kids kids = obj.GetComponent<Kids>();
            kids.Idx = gamemanager.SpawnCnt;
            //gamemanager.SpawnCnt = gamemanager.SpawnCnt + 1;
            kids.Set(transform.position, new Vector3(-2.0f - kids.Idx / (gamemanager.HeightCnt)
                , -((gamemanager.HeightCnt - 1) * 0.5f) + (kids.Idx % (gamemanager.HeightCnt)), 0.0f));

            // ���g������
            Destroy(gameObject);
        }
        else
        {
            Vector3 pos = transform.position;
            pos += m_move * Time.deltaTime;
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
