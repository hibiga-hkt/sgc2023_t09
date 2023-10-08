using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    [SerializeField]
    public GameObject m_TimeText;
    [SerializeField]
    public float fTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float TimeCount = fTime - Time.time;
        if(TimeCount <= 0)
        {
            TimeCount = 0;
        }

    
        m_TimeText.GetComponent<Text>().text = TimeCount.ToString("00.0");
    }

    public void AddTime(float Add)
    {
        fTime += Add;
    }
}