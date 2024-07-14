using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    [SerializeField] float spinSpeed;
    float totalSpinAmmount;

    public void SetSpinning(bool isSpinning)
    {
        totalSpinAmmount = 0;

        this.isActive = isSpinning;
    }

    void Update()
    {
        if (!isActive)
        {return;}


        float spinAmmount = spinSpeed * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, spinAmmount, 0);

        totalSpinAmmount += spinAmmount;

        if (totalSpinAmmount >= 360)
        {
            isActive=false;
        }

    }

}
