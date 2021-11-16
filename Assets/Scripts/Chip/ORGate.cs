using UnityEngine;

public class ORGate : BuiltinChip {

    protected override void Awake () {
        base.Awake ();
    }

    protected override void ProcessOutput ()
    {
        int outputSignal = 0;
        if (inputPins[0].State == 1 || inputPins[1].State == 1)
            outputSignal = 1;
        outputPins[0].ReceiveSignal (outputSignal);
    }

}