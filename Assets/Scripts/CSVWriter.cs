using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;

public class CSVWriter : MonoBehaviour
{
    // Class variables
    string filename = "";
    private static float valueFromClassCH1;
    private static float valueFromClassCH2;
    private static float valueFromClassCH3;
    private static float valueFromClassCH4;
    private static float valueFromClassCH5;
    private static float valueFromClassCH6;
    private static float valueFromClassCH7;
    private static float valueFromClassCH8;
    private float m_LastTime = 0f;
    private bool counterToWriteOnlyOnce = true;
  

    // Interval in which to write to the document
    public float INTERVAL = 1f;
    float elapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Naming the file in (can be changed) - if the file is non existent a new file will be generated with the same name
        filename = Application.dataPath + "/ChartData.csv";
    }

    // Update is called once per frame
    void Update()
    {
        WriteCSV();
    }

    /// <summary>
    /// Method which writes the incoming data to the file
    /// If the data has not changed or the aquisition has not started
    /// the data will not be written on the file
    /// </summary>
    public void WriteCSV()
    {
        float OldCH1 =valueFromClassCH1;
        float OldCH2 = valueFromClassCH2;
        float OldCH3 = valueFromClassCH3;
        float OldCH4 = valueFromClassCH4;
        float OldCH5 = valueFromClassCH5;
        float OldCH6 = valueFromClassCH6;
        float OldCH7 = valueFromClassCH7;
        float OldCH8 = valueFromClassCH8;

        valueFromClassCH1 = Hybrid8Test.valueCH1;
        valueFromClassCH2 = Hybrid8Test.valueCH2;
        valueFromClassCH3 = Hybrid8Test.valueCH3;
        valueFromClassCH4 = Hybrid8Test.valueCH4;
        valueFromClassCH5 = Hybrid8Test.valueCH5;
        valueFromClassCH6 = Hybrid8Test.valueCH6;
        valueFromClassCH7 = Hybrid8Test.valueCH7;
        valueFromClassCH8 = Hybrid8Test.valueCH8;
        
        // Creating a new writer 
        TextWriter tw = new StreamWriter(filename, true);

        // Checking if the values have changed and the if the aquisition has started

        if (valueFromClassCH1 != 0 || valueFromClassCH2 != 0 || valueFromClassCH3 != 0 || valueFromClassCH4 != 0 || 
            valueFromClassCH5 != 0
            || valueFromClassCH6 != 0 || valueFromClassCH7 != 0 || valueFromClassCH8 != 0)
        {
            if (valueFromClassCH1 != OldCH1 || valueFromClassCH2 != OldCH2
             || valueFromClassCH3 != OldCH3 || valueFromClassCH4 != OldCH4 || valueFromClassCH5 != OldCH5 || 
             valueFromClassCH6 != OldCH6
              || valueFromClassCH7 != OldCH7 || valueFromClassCH8 != OldCH8)
            {
                 OldCH1 = valueFromClassCH1;
                 OldCH2 = valueFromClassCH1;
                 OldCH3 = valueFromClassCH1;
                 OldCH4 = valueFromClassCH1;
                 OldCH5 = valueFromClassCH1;
                 OldCH6 = valueFromClassCH1;
                 OldCH7 = valueFromClassCH1;
                 OldCH8 = valueFromClassCH1;

                if (counterToWriteOnlyOnce == true)
                {
                    tw.WriteLine("CH1    CH2    CH3    CH4    CH5    CH6    CH7    CH8");
                    counterToWriteOnlyOnce = false;
                }

                if (Time.realtimeSinceStartup - m_LastTime >= INTERVAL)
                {
                    tw.WriteLine(valueFromClassCH1 + "    " + valueFromClassCH2 + "    " + valueFromClassCH3 +
                        "    " + valueFromClassCH4 + "    " + valueFromClassCH5 + "    " + valueFromClassCH6 + "    " + 
                        valueFromClassCH7 + "    " + valueFromClassCH8);
                }
                elapsed += Time.deltaTime;
                if (elapsed >= 1f)
                {
                    elapsed = elapsed % 1f;

                }
            }
            tw.Close();

        }
    }
}
