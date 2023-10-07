using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_TimeBonus : MonoBehaviour
{
    [SerializeField]
    Vector3 m_move; // �ړ���

    [SerializeField]
    float m_Life; // ����

    [SerializeField]
    float m_Bonus;    // �{�[�i�X��

    // Start is called before the first frame update
    void Start()
    {
        m_Life = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        // ���W�̈ړ�
        Vector3 pos = transform.position;
        pos += m_move * Time.deltaTime;
        transform.position = pos;

        // �����m�F
        m_Life--;
        if(m_Life < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider colider)
    {
        // �G���ǂ����m�F
        if (colider.gameObject.CompareTag("Player") || colider.gameObject.CompareTag("Kids"))
        {
            // �^�C���̑���
            TimerManager timemanager = GameObject.FindGameObjectWithTag("Time").GetComponent<TimerManager>(); // �}�l�[�W���[���擾
            timemanager.AddTime(m_Bonus);

            // ���g������
            Destroy(gameObject);
        }
    }
}
