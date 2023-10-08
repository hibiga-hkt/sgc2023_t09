using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BgManager : SingletonMonoBehaviour<BgManager>
{
    public float posYMin = -500.0f;
    public float rotateSpeed = 0.9f;
    private float m_fPosY;

    private void Start()
    {
        m_fPosY = this.transform.localPosition.y;
    }

    private void Update()
    {
        this.transform.Rotate(Vector3.up, -this.rotateSpeed * Time.deltaTime);

        if (!GameManager.Instance.IsPlaying)
        {
            return;
        }

        this.transform.Rotate(Vector3.up, -this.rotateSpeed * Time.deltaTime);

        var DestPos = new Vector3(this.transform.localPosition.x, m_fPosY, this.transform.localPosition.z) - this.transform.localPosition;
        this.transform.localPosition += DestPos * Time.deltaTime * 0.1f;

        if (this.transform.localPosition.y < this.posYMin)
        {
            var pos = this.transform.localPosition;
            pos.y = this.posYMin;
            this.transform.localPosition = pos;
        }
        else if (this.transform.localPosition.y > -10.0f)
        {
            var pos = this.transform.localPosition;
            pos.y = -10.0f;
            this.transform.localPosition = pos;
        }
    }

    public void MoveUp(float y)
    {
        m_fPosY -= Vector3.up.y * y;
        if (this.transform.localPosition.y < this.posYMin)
        {
            var pos = this.transform.localPosition;
            pos.y = this.posYMin;
            this.transform.localPosition = pos;
        }
    }
}
