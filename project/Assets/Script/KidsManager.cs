using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsManager : MonoBehaviour
{
    Kids m_Top; // �擪
    Kids m_Cur; // �Ō�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ListIn(Kids my)
    {
        my.Next = null;
        my.Prev = null;

        // �������g�����X�g�ɒǉ�
        if (m_Top != null)
        {// �擪�����݂��Ă���ꍇ
            m_Cur.Next = my; // ���ݍŌ���̃I�u�W�F�N�g�̃|�C���^�ɂȂ���
            my.Prev = m_Cur;
            m_Cur = my;  // �������g���Ō���ɂȂ�
        }
        else
        {// ���݂��Ȃ��ꍇ
            m_Top = my;  // �������g���擪�ɂȂ�
            m_Cur = my;  // �������g���Ō���ɂȂ�
        }

        my.Idx = GameManager.Instance.SpawnCnt;
        GameManager.Instance.SpawnCnt += 1;
    }

    public void ListOut(Kids my)
    {
        // ���X�g���玩�����g���폜����
        if (m_Top == my)
        {// ���g���擪
            if (my.Next != null)
            {// �������݂��Ă���
                m_Top = my.Next;   // ����擪�ɂ���
                my.Next.Prev = null;    // ���̑O�̃|�C���^���o���Ă��Ȃ��悤�ɂ���
            }
            else
            {// ���݂��Ă��Ȃ�
                m_Top = null;  // �擪���Ȃ���Ԃɂ���
                m_Cur = null;  // �Ō�����Ȃ���Ԃɂ���
            }
        }
        else if (m_Cur == my)
        {// ���g���Ō��
            if (my.Prev != null)
            {// �������݂��Ă���
                m_Cur = my.Prev;           // �O���Ō���ɂ���
                my.Prev.Next = null;    // �O�̎��̃|�C���^���o���Ă��Ȃ��悤�ɂ���
            }
            else
            {// ���݂��Ă��Ȃ�
                m_Top = null;  // �擪���Ȃ���Ԃɂ���
                m_Cur = null;  // �Ō�����Ȃ���Ԃɂ���
            }
        }
        else
        {
            if (my.Next != null)
            {
                my.Next.Prev = my.Prev; // ���g�̎��ɑO�̃|�C���^���o��������
            }
            if (my.Prev != null)
            {
                my.Prev.Next = my.Next; // ���g�̑O�Ɏ��̃|�C���^���o��������
            }
        }

        GameManager.Instance.SpawnCnt -= 1;

        // ������Đݒ�
        SetFormation();
    }

    public void SetFormation()
    {
        // �v���C���[�����ʒu�܂ł̍X�V
        GameManager gamemanager = GameManager.Instance; // �}�l�[�W���[���擾
        int SpawnCnt = 0;
        Kids Obj = m_Top;

        while(Obj != null)
        {
            Kids ObjNext = Obj.Next;

            Obj.Set(Obj.transform.position, new Vector3(-2.0f - SpawnCnt / (gamemanager.HeightCnt)
                 , -((gamemanager.HeightCnt - 1) * 0.5f) + (SpawnCnt % (gamemanager.HeightCnt)), 0.0f));

            Obj = ObjNext;

            SpawnCnt++;
        }
    }

    public void SetAvoid()
    {
        // �v���C���[�����ʒu�܂ł̍X�V
        GameManager gamemanager = GameManager.Instance; // �}�l�[�W���[���擾
        int SpawnCnt = 0;
        Kids Obj = m_Top;

        while (Obj != null)
        {
            Kids ObjNext = Obj.Next;

            Obj.Set(Obj.transform.position, new Vector3(-2.0f - SpawnCnt / (2)
                 , -((2 - 1) * 0.5f) + (SpawnCnt % (2)), 0.0f));

            Obj = ObjNext;

            SpawnCnt++;
        }
    }
}
