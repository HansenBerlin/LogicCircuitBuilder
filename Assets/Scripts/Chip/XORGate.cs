using UnityEngine;

public class XORGate : BuiltinChip 
{

    float elapsed = 0f;
    private int outputSignal = 0;

    protected override void Awake () {
        base.Awake ();
    }

    protected override void ProcessOutput ()
    {
        Debug.Log("SIgnal: " + outputSignal);
        //if (inputPins[0].State == 1) 
            outputPins[0].ReceiveSignal (outputSignal);
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f) 
        {
            elapsed = elapsed % 1f;
            if (outputSignal == 1)
                outputSignal = 0;
            else
                outputSignal = 1;
        }
    }
}