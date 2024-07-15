using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    [SerializeField] float spinSpeed;


    float totalSpinAmmount;

    public void SetSpinning(bool isSpinning, Action<bool> onSpinActionCompleteDelegate)
    {
        totalSpinAmmount = 0;

        this.isActive = isSpinning;
        this.onActionCompleteDelegate = onSpinActionCompleteDelegate;
    }

    void Update()
    {
        if (!isActive)
        {return;}


        float spinAmmount = spinSpeed * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, spinAmmount, 0);

        totalSpinAmmount += spinAmmount;

        Debug.Log(totalSpinAmmount);

        if (totalSpinAmmount >= 360)
        {
            Debug.Log("pepe");
            isActive=false;
            onActionCompleteDelegate(false);
        }

    }

}
