using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    [SerializeField]
    private int m_EnemySpawnCount;   // �J�E���^�[

    [SerializeField]
    private int m_FoodSpawnCount;

    [SerializeField]
    private int m_EnemySetTimer;     // ��������^�C�}�[

    [SerializeField]
    private int m_FoodSetTimer;     // ��������^�C�}�[

    [SerializeField]
    private EnemyData[] m_aEnemy;  // �����G�I�u�W�F�N�g

    [SerializeField]
    private FoodData[] m_aFood;  // �����H�I�u�W�F�N�g

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
        m_EnemySpawnCount++;

        // ����
        if(m_EnemySpawnCount > m_EnemySetTimer)
        {
            m_EnemySpawnCount = 0;

            int nRand = Random.Range(MinRange, MaxRange);

            Enemy enemy = Instantiate(m_aEnemy[nRand].m_prefab, m_aEnemy[nRand].position, Quaternion.identity).GetComponent<Enemy>();
        }

        m_FoodSpawnCount++;

        // ����
        if (m_FoodSpawnCount > m_FoodSetTimer)
        {
            m_FoodSpawnCount = 0;

            int nRand = Random.Range(MinRange, MaxRange);

            food Food = Instantiate(m_aFood[nRand].m_prefab, m_aFood[nRand].position, Quaternion.identity).GetComponent<food>();
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
    public Vector3 position;
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
    public Vector3 position;
}