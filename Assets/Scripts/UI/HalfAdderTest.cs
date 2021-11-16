using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HalfAdderTest : MonoBehaviour
{
    public HalfAdderSimple halfAdderTest;
    public TMP_Text m_TextComponent;
    public GameObject buttonStartTests;
    public GameObject testStatusHeader;
    public FindGameObjects scriptsContainer;
    //private string testState = "Run...";
    private int testState = -2;
    private int counter = 5;
    
    //public CreateMenu creator;
    

    void Start()
    {
        GetGameObjects();
    }

    void GetGameObjects()
    {
        GameObject playerGameObj = GameObject.Find("Tests");
        if (playerGameObj != null)
            halfAdderTest = playerGameObj.GetComponent<HalfAdderSimple>();
        m_TextComponent.text = "leer";
    }

    public async void StartTest()
    {
        //buttonStartTests.gameObject.SetActive(false);
        //testStatusHeader.gameObject.SetActive(true);
        
        //m_TextComponent.text = halfAdderTest.TestStatus;
        testState = 0;
        UpdateText();
        testState = await halfAdderTest.StartTest(1, 0 ,1, 0, 1);
        Debug.Log("State: " + testState);

        if (testState != -1)
        {
            testState = await halfAdderTest.StartTest(0, 1 ,1, 0, 2);
            //UpdateText(testState);
            Debug.Log("State: " + testState);
        }
        if (testState != -1)
        {
            testState = await halfAdderTest.StartTest(0, 0 ,0, 0, 3);
            //UpdateText(testState);
            Debug.Log("State: " + testState);
        }
        if (testState != -1)
        {
            testState = await halfAdderTest.StartTest(1, 1 ,0, 1, 4);
            //UpdateText(testState);
            Debug.Log("State: " + testState);
        }

        
        //Debug.Log("Status: " + halfAdderTest.TestsPassed);
        
        if (testState == -1)
        {
            buttonStartTests.gameObject.SetActive(true);
            testStatusHeader.gameObject.SetActive(false);
        }
        else
        {
            await Task.Delay(2000);
            counter--;
            await Task.Delay(1000);
            counter--;           
            await Task.Delay(1000);
            counter--;          
            await Task.Delay(1000);
            counter--;           
            await Task.Delay(1000);
            counter--;           
            await Task.Delay(1000);
            scriptsContainer.createChip.CreateNewChip("Half Adder DEL");
            //scriptsContainer.createChip.FinishCreation();

        }
    }

    private async Task UpdateText()
    {
        if (testState == 4)
            m_TextComponent.text = $"Building Chip...{counter}";
        else if (testState == 0)
            m_TextComponent.text = "Testing...";
        else if (testState == -2)
            m_TextComponent.text = $"No test running";
        else if (testState == -1)
            m_TextComponent.text = $"Failed on test {testState}";
        else
            m_TextComponent.text = $"Test {testState} passed";
        //Debug.Log();
    }

    void Update()
    {
        while (halfAdderTest == null)
            GetGameObjects();
        //m_TextComponent.text = testState;
        UpdateText();
    }
}
