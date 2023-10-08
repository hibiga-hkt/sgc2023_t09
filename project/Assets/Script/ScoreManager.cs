using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public GameObject m_scoreText;
    private int nSunFish;
    // Start is called before the first frame update
    void Start()
    {
        nSunFish = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int addScore)
    {
        nSunFish += addScore;
        m_scoreText.GetComponent<Text>().text = this.nSunFish.ToString("D9");
    }
}
