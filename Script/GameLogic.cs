using Mono.Csv; // transder Mono.csv
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class GameLogic : MonoBehaviour
{
    public GameObject StartConvas; // Create start Canvas
    public GameObject Scenario1Convas; // Create Scenario1 Convas
    public GameObject Scenario2Convas; // Create Scenario2 Convas
    public GameObject Scenario3Convas; // Create Scenario3 Convas
    public GameObject StopConvas; // Create stop Convas
    public GameObject Animation1; // Create Animation1
    public GameObject Animation2; // Create Animation2
    public GameObject Animation3; // Create Animation3
    public InputField show_userInput;// Input partipant ID
    public Dropdown EvalutionScenario1; // Input Dropdown Evalution ( 1,2,3,4,5,6,7,8,9,10 )
    public Dropdown EvalutionScenario2;
    public Dropdown EvalutionScenario3;
    private string Text1;
    private string Text2;
    private string Text3;
    private CsvFileWriter csvFileWriter;// write csv File 
    private CsvFileReader csvFileReader; // read csv File 
    public List<List<string>> allrows = new List<List<string>>(); // string of list informations - csv File 

    // fuctions ......................................................//
    // read  Dropdown Evalution of Scenario ( 1,2,3,4,5,6,7,8,9,10 )
    public void OnValueChanged1()

    {
    Text1=  EvalutionScenario1.options[EvalutionScenario1.value].text;
    }
    public void OnValueChanged2()

    {
    Text2 = EvalutionScenario2.options[EvalutionScenario2.value].text;
     }
   public void OnValueChanged3()

    {
     Text3 = EvalutionScenario3.options[EvalutionScenario3.value].text;

    }

    // fuctions  Canvas // 

    public void StartFunction()
    {
        StartConvas.SetActive(false);// start Canvas active
    }
    public void Finish1Function()
    {
        Scenario1Convas.SetActive(false);//  Scenario1Convas deactive
        Animation1.SetActive(false);// Animation1 active
    }

    public void Finish2Function()
    {
        Scenario2Convas.SetActive(false);// Scenario2Convas deactive
        Animation2.SetActive(false);// Animation2 active
    }

    public void Finish3Function()
    {
        Scenario3Convas.SetActive(false);// Scenario3Convas deactive
        StopConvas.SetActive(true);// Stop Convas deactive
        Animation3.SetActive(false);// Animation3 active
        Logging();
    }


    // function on what happens when a participant exits triggers
    public void OnTriggerEnter (Collider other) // Participant exits triggers
    {
        // Set a Trigger of yellow square to activate
        if (other.CompareTag("Scenario1")) // Participants exits the red Square
        {
            Scenario1Convas.SetActive(true);// Scenario1Convas active
            Animation1.SetActive(true);// Animation1 active
        }

        // Set a Trigger of blue square to activate
        else if (other.CompareTag("Scenario2")) // Participants crosses the start line
        {
            Scenario2Convas.SetActive(true);// Scenario2Convas active
            Animation2.SetActive(true);// Animation2 active
        

        }
        // Set a Trigger of green square to activate
        else if (other.CompareTag("Scenario3"))
        {
            Scenario3Convas.SetActive(true);// Scenario3Convas active
            Animation3.SetActive(true);// Animation3 active
           
        }

    }

    //############# LOGGING---- CONDITION NUMBER, CONDITION NAME,PARTICIPANT ID,EXIT,TIME IN ONE CSV.file ######################//

    //gets the path of the directory where we want to store our logs
    static string GetDirectoryPath()
    {
        return Application.dataPath + "/StreamingAssets/_Logs/";

    }
    //if your folder and file has not been created yet, it will be created. This also ensures your data goes to the correct file and folder:

    public void Logging()
    {     // read informations of csv File 
        allrows = CsvFileReader.ReadAll(Application.streamingAssetsPath + "/_Logs/Studydata.csv", Encoding.UTF8);
        List<string> xx = new List<string>();
        // informations of csv File 
        xx.Add(show_userInput.text);//writes the ParticipantID since start 
        xx.Add(Text1.ToString());//writes Evalution of Scenario1
        xx.Add(Text2.ToString());//writes Evalution of Scenario2
        xx.Add(Text3.ToString());//writes Evalution of Scenario3
        // write informations of csv File 
        allrows.Add(xx);
        csvFileWriter = new CsvFileWriter(Application.streamingAssetsPath + "/_Logs/Studydata.csv");
        csvFileWriter.WriteAll(allrows);
        csvFileWriter.Dispose();
    }
}
