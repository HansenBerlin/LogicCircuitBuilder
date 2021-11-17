using System;
using UnityEngine;
using System.Threading.Tasks;

public class HalfAdderSimple : MonoBehaviour
{
    //public bool TestsPassed { get; private set; }
    //public string TestStatus  = "Run...";
    //public int lastSuceeded = 0;
    public InputSignal signalOne;
    public InputSignal signalTwo;
    public OutputSignal signalZeroOut;
    public OutputSignal signalOneOut;
    public SignalSpawner signalSpawner;
    //public bool startTest { get; set; }

    void Start()
    {
        
    }

    private void Update()
    {
        if (signalSpawner == null)
            signalSpawner = FindObjectOfType<SignalSpawner>();

        if (signalSpawner == null)
            return;
        
        signalOne = signalSpawner.CreateInputSignal(-2f);
        signalTwo = signalSpawner.CreateInputSignal(2f);
        signalZeroOut = signalSpawner.CreateOutputSignal(-2f);
        signalOneOut = signalSpawner.CreateOutputSignal(2f);
        signalZeroOut.UpdateSignalName("SUM");
        signalOneOut.UpdateSignalName("CARRY");
        signalOne.UpdateSignalName("A0");
        signalTwo.UpdateSignalName("B0");
    }

    public async Task<int> StartTest(int one, int two, int oneAssert, int twoAssert, int testCase)
    {
        ToggleInputs(one, two);
        var success = await Test(oneAssert, twoAssert).ConfigureAwait(false);
        return success ? testCase : testCase - 1;
    }

    private void ToggleInputs(int signalOneSet, int signalTwoSet)
    {
        if (signalOne.currentState != signalOneSet)
            signalOne.ToggleActive();

        if (signalTwo.currentState != signalTwoSet)
            signalTwo.ToggleActive();
    }

    async Task<bool> Test(int signalOneOutAssert, int signalTwoOutAssert)
    {
        await Task.Delay(2000);
        return signalZeroOut.currentState == signalOneOutAssert && signalOneOut.currentState == signalTwoOutAssert;
    }
}