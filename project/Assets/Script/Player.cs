using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 m_move; // �ړ���

    [SerializeField]
    private float m_Speed;  // �ړ����x
    [SerializeField]
    private float m_fMulti; // ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �����蔻��
        Vector3 pos = transform.position;   // �ړ���̍��W���擾

        // ��ʂ̔�����W���擾
        Vector3 leftDown = Camera.main.ScreenToWorldPoint(new Vector2(-Screen.width, -Screen.height)); // �����̍��W
        Vector3 rightUp = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); // �E��̍��W

        // �X�v���C�g�̕������擾

        // �ړ�
        if (Input.GetKey(KeyCode.A))
        {// A�L�[�������ꂽ�Ƃ�
            if (Input.GetKey(KeyCode.W))
            {// W�L�[�������ꂽ�Ƃ�
                m_move.x += Mathf.Sin(-Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(-Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {// S�L�[�������ꂽ�Ƃ�
                m_move.x += Mathf.Sin(-Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(-Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
            }
            else
            {// ������������Ă��Ȃ�
                m_move.x += Mathf.Sin(-Mathf.PI * 0.5f) * m_Speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {// D�L�[�������ꂽ�Ƃ�
            if (Input.GetKey(KeyCode.W))
            {// W�L�[�������ꂽ�Ƃ�
                m_move.x += Mathf.Sin(Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(Mathf.PI * 0.25f) * m_Speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {// S�L�[�������ꂽ�Ƃ�
                m_move.x += Mathf.Sin(Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
                m_move.y += Mathf.Cos(Mathf.PI * 0.75f) * m_Speed * Time.deltaTime;
            }
            else
            {// ������������Ă��Ȃ�
                m_move.x += Mathf.Sin(Mathf.PI * 0.5f) * m_Speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {// W�L�[�������ꂽ�Ƃ�
            m_move.y += Mathf.Cos(Mathf.PI * 0.0f) * m_Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {// S�L�[�������ꂽ�Ƃ�
            m_move.y += Mathf.Cos(Mathf.PI * 1.0f) * m_Speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            KidsManager kidsManager = GameObject.FindGameObjectWithTag("KidsManager").GetComponent<KidsManager>(); // �v���C���[���擾
            kidsManager.SetAvoid();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            KidsManager kidsManager = GameObject.FindGameObjectWithTag("KidsManager").GetComponent<KidsManager>(); // �v���C���[���擾
            kidsManager.SetFormation();
        }

        pos += m_move;   // �ړ��ʂ����Z

        // �����蔻��
        //pos.x = Mathf.Clamp(pos.x, leftDown.x, rightUp.x);
        //pos.y = Mathf.Clamp(pos.y, leftDown.y, rightUp.y);

        // �ړ��ʌ���
        m_move.x += (0.0f - m_move.x) * m_fMulti;   //x���W
        m_move.y += (0.0f - m_move.y) * m_fMulti;	//y���W

        // ���W�X�V
        transform.position = pos;

        transform.Translate(m_move.x, m_move.y, m_move.z, Space.World); // �ړ��ʂ����Z
    }

    private void OnTriggerEnter(Collider colider)
    {
        // �G���ǂ����m�F
        if (colider.gameObject.CompareTag("Enemy") || colider.gameObject.CompareTag("Obstacle"))
        {
            // �^�C���̑���
            TimerManager timemanager = GameObject.FindGameObjectWithTag("Time").GetComponent<TimerManager>(); // �}�l�[�W���[���擾
            timemanager.AddTime(-10);
            Destroy(colider.gameObject);
        }
    }
}
