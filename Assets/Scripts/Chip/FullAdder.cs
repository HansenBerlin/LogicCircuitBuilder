using UnityEngine;

public class FullAdder : BuiltinChip {

    protected override void Awake () {
        base.Awake ();
    }

    protected override void ProcessOutput ()
    {
        int outputSignal = 0;
        int carrySignal = 0;	
		int sum = (inputPins[0].State + inputPins[1].State + inputPins[2].State);

		if (sum == 1)
        {
            outputSignal = 1;
            carrySignal = 0;
        }
        else if (sum == 2)
        {
            outputSignal = 0;
            carrySignal = 1;
        }
		else if (sum == 3)
        {
            outputSignal = 1;
            carrySignal = 1;
        }
        outputPins[0].ReceiveSignal (outputSignal);
        outputPins[1].ReceiveSignal (carrySignal);
    }
}