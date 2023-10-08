using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    private int m_HeightCnt;   // �c�ɑ��݂��鐔

    [SerializeField]
    private int m_SetHeightCnt; // �c�̊��

    [SerializeField]
    private int m_HeightLevel;  // �c�̊g�����x��

    [SerializeField]
    private int[] m_LevelUpNum; // ���x���A�b�v�̋K�萔

    [SerializeField]
    private Camera m_camera;    // �J����

    [SerializeField]
    private float m_CamZ;

    private int m_nSpawnCnt = 0; // ���v������
    private int m_nSpawnOld;

    public int HeightCnt
    {
        get { return m_HeightCnt; }
        set { m_HeightCnt = value; }
    }

    public int SpawnCnt
    {
        get { return m_nSpawnCnt; }
        set { m_nSpawnCnt = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var OldLevel = m_HeightLevel;

        if (m_HeightLevel - 1 > 0)
        {
            if (m_nSpawnCnt < m_LevelUpNum[OldLevel - 1])
            {
                m_HeightLevel -= 1;

                if (m_HeightLevel < 0)
                {
                    m_HeightLevel = 0;
                }

                m_HeightCnt = m_SetHeightCnt + m_HeightLevel;

                KidsManager.Instance.SetFormation();
            }
        }


        if (m_HeightLevel + 1 <= m_LevelUpNum.Length)
        {
            if (m_nSpawnCnt >= m_LevelUpNum[m_HeightLevel])
            {
                m_HeightLevel += 1;

                if (m_HeightLevel > m_LevelUpNum.Length)
                {
                    m_HeightLevel = m_LevelUpNum.Length;
                }

                m_HeightCnt = m_SetHeightCnt + m_HeightLevel;

                KidsManager.Instance.SetFormation();
            }
        }

        if (m_nSpawnCnt != m_nSpawnOld)
        {
            m_camera.transform.position = new Vector3(0.0f, 0.0f, m_CamZ + m_nSpawnCnt * -0.05f);
            BgManager.Instance.MoveUp((m_nSpawnCnt - m_nSpawnOld) * 2.0f);
        }

        m_nSpawnOld = m_nSpawnCnt;

        if (Input.GetKey(KeyCode.Escape))
        {// Esc�L�[�������ꂽ�Ƃ�
            Quit();
        }

        Debug.Log(m_nSpawnCnt);
    }

    // �I��
    void Quit()
    {
#if UNITY_EDITOR    // �G�f�B�^�[
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE  // ���s
        UnityEngine.Application.Quit();
#endif
    }
}
