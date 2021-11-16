using UnityEngine;

public class HalfAdder : BuiltinChip {

    protected override void Awake () {
        base.Awake ();
    }

    protected override void ProcessOutput ()
    {
        int outputSignal = 0;
        int carrySignal = 0;
        if ((inputPins[0].State == 1 && inputPins[1].State == 0) ||
            (inputPins[0].State == 0 && inputPins[1].State == 1))
        {
            outputSignal = 1;
            carrySignal = 0;
        }
        else if (inputPins[0].State == 1 && inputPins[1].State == 1)
        {
            outputSignal = 0;
            carrySignal = 1;
        }
        outputPins[0].ReceiveSignal (outputSignal);
        outputPins[1].ReceiveSignal (carrySignal);
    }
}