using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private int m_SpawnCount;   // �J�E���^�[

    [SerializeField]
    private int m_SetTimer;     // ��������^�C�}�[

    [SerializeField]
    private EnemyData[] m_aEnemy;  // �����I�u�W�F�N�g

    [SerializeField]
    private int MinRange;       // �����Œ�͈�

    [SerializeField]
    private int MaxRange;       // �����ő�͈�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_SpawnCount++;

        // ����
        if(m_SpawnCount > m_SetTimer)
        {
            m_SpawnCount = 0;

            int nRand = Random.Range(MinRange, MaxRange);
        }
    }
}

[System.Serializable]   // �N���X�̃f�[�^���C���X�y�N�^�ɕ\�������邽�߂ɕK�v
public class EnemyData
{
    // ���O
    [HideInInspector]
    public string m_name;
    // [HideInInspector] �C���X�y�N�^��Ŕ�\���ɂ���

    // ��������v���n�u
    public GameObject m_prefab;

    // �o���ʒu
    public Vector3 m_position;
}

[System.Serializable]   // �N���X�̃f�[�^���C���X�y�N�^�ɕ\�������邽�߂ɕK�v
public class FoodData
{
    // ���O
    [HideInInspector]
    public string m_name;
    // [HideInInspector] �C���X�y�N�^��Ŕ�\���ɂ���

    // ��������v���n�u
    public GameObject m_prefab;

    // �o���ʒu
    public Vector3 m_position;
}