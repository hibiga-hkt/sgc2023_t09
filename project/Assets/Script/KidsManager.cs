using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidsManager : MonoBehaviour
{
    Kids m_Top; // 先頭
    Kids m_Cur; // 最後

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

        // 自分自身をリストに追加
        if (m_Top != null)
        {// 先頭が存在している場合
            m_Cur.Next = my; // 現在最後尾のオブジェクトのポインタにつなげる
            my.Prev = m_Cur;
            m_Cur = my;  // 自分自身が最後尾になる
        }
        else
        {// 存在しない場合
            m_Top = my;  // 自分自身が先頭になる
            m_Cur = my;  // 自分自身が最後尾になる
        }
    }

    public void ListOut(Kids my)
    {
        // リストから自分自身を削除する
        if (m_Top == this)
        {// 自身が先頭
            if (my.Next != null)
            {// 次が存在している
                m_Top = my.Next;   // 次を先頭にする
                my.Next.Prev = null;    // 次の前のポインタを覚えていないようにする
            }
            else
            {// 存在していない
                m_Top = null;  // 先頭がない状態にする
                m_Cur = null;  // 最後尾がない状態にする
            }
        }
        else if (m_Cur == this)
        {// 自身が最後尾
            if (my.Prev != null)
            {// 次が存在している
                m_Cur = my.Prev;           // 前を最後尾にする
                my.Prev.Next = null;    // 前の次のポインタを覚えていないようにする
            }
            else
            {// 存在していない
                m_Top = null;  // 先頭がない状態にする
                m_Cur = null;  // 最後尾がない状態にする
            }
        }
        else
        {
            if (my.Next != null)
            {
                my.Next.Prev = my.Prev; // 自身の次に前のポインタを覚えさせる
            }
            if (my.Prev != null)
            {
                my.Prev.Next = my.Next; // 自身の前に次のポインタを覚えさせる
            }
        }
    }
}
