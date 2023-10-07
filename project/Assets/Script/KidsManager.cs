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
    }

    public void ListOut(Kids my)
    {
        // ���X�g���玩�����g���폜����
        if (m_Top == this)
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
        else if (m_Cur == this)
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
    }
}
