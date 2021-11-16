using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalSpawner : MonoBehaviour
{
    public ChipInterfaceEditor inputEditorIn;
    public ChipInterfaceEditor inputEditorOut;
    const float forwardDepth = -0.1f;
    
    public InputSignal CreateInputSignal(float y)
    {
        ChipSignal spawnedSignal = null;
        float containerX = inputEditorIn.chipContainer.position.x + 
                           inputEditorIn.chipContainer.localScale.x / -2 ;
        
        bool isGroup = inputEditorIn.currentGroupSize > 1;
        ChipSignal[] spawnedSignals = new ChipSignal[inputEditorIn.currentGroupSize];

        for (int i = 0; i < inputEditorIn.currentGroupSize; i++) {
            Vector3 spawnPos = new Vector3 (containerX, y, inputEditorIn.chipContainer.position.z + forwardDepth);

            spawnedSignal = Instantiate (inputEditorIn.signalPrefab, spawnPos, Quaternion.identity, inputEditorIn.signalHolder);
            if (isGroup) {
                spawnedSignal.GroupID = inputEditorIn.currentGroupID;
                spawnedSignal.displayGroupDecimalValue = true;
            }
            inputEditorIn.signals.Add (spawnedSignal);
            spawnedSignals[i] = spawnedSignal;
        }

        if (isGroup) {
            inputEditorIn.groupsByID.Add (inputEditorIn.currentGroupID, spawnedSignals);
            inputEditorIn.currentGroupSize = 1;
            inputEditorIn.currentGroupID++;
        }

        return (InputSignal)spawnedSignal;
    }
    
    public OutputSignal CreateOutputSignal(float y)
    {
        ChipSignal spawnedSignal = null;
        float containerX = inputEditorOut.chipContainer.position.x + 
                           inputEditorOut.chipContainer.localScale.x / 2;
        
        bool isGroup = inputEditorOut.currentGroupSize > 1;
        ChipSignal[] spawnedSignals = new ChipSignal[inputEditorOut.currentGroupSize];

        for (int i = 0; i < inputEditorOut.currentGroupSize; i++) {
            Vector3 spawnPos = new Vector3 (containerX, y, inputEditorOut.chipContainer.position.z + forwardDepth);

            spawnedSignal = Instantiate (inputEditorOut.signalPrefab, spawnPos, Quaternion.identity, inputEditorOut.signalHolder);
            if (isGroup) {
                spawnedSignal.GroupID = inputEditorOut.currentGroupID;
                spawnedSignal.displayGroupDecimalValue = true;
            }
            inputEditorOut.signals.Add (spawnedSignal);
            spawnedSignals[i] = spawnedSignal;
        }

        if (isGroup) {
            inputEditorOut.groupsByID.Add (inputEditorOut.currentGroupID, spawnedSignals);
            inputEditorOut.currentGroupSize = 1;
            //inputEditorOut.currentGroupID++;
        }

        return (OutputSignal)spawnedSignal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
