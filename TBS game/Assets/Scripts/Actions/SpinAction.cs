using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAction : BaseAction
{
    [SerializeField] float spinSpeed;

    public delegate void OnSpinActionCompleteDelegate(bool isBusy);

    float totalSpinAmmount;

    OnSpinActionCompleteDelegate onSpinActionCompleteDelegate;
    public void SetSpinning(bool isSpinning, OnSpinActionCompleteDelegate onSpinActionCompleteDelegate)
    {
        totalSpinAmmount = 0;

        this.isActive = isSpinning;
        this.onSpinActionCompleteDelegate = onSpinActionCompleteDelegate;
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
            onSpinActionCompleteDelegate(false);
        }

    }

}
