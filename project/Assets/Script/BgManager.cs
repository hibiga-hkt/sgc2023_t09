using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BgManager : SingletonMonoBehaviour<BgManager>
{
    public float posYMin = -500.0f;
    public float rotateSpeed = 0.9f;

    private void Update()
    {
        // test
        this.MoveUp(5.0f);

        this.transform.Rotate(Vector3.up, -this.rotateSpeed * Time.deltaTime);
    }

    public void MoveUp(float y)
    {
        this.transform.localPosition -= Vector3.up * y * Time.deltaTime;
        if (this.transform.localPosition.y < this.posYMin)
        {
            var pos = this.transform.localPosition;
            pos.y = this.posYMin;
            this.transform.localPosition = pos;
        }
    }
}
