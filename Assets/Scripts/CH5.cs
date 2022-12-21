using System.Threading;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

// Class for creating Chart for channel 5
public class CH5 : MonoBehaviour
{


    public static float valueFromClass;
    float elapsed = 0f;
    public float INTERVAL = 1f;
    // Number of how much data can be shown to each graph
    public int maxCache = 100;
    private float m_LastTime = 0f;
    private LineChart chart;

    void Awake()
    {
        chart = gameObject.GetComponent<LineChart>();
        createChart();
        chart.SetMaxCache(maxCache);
    }

    // Method which creates the chart -> parameters can be changed and some additions can be made
    void createChart()
    {
        if (chart == null)
        {
            chart = gameObject.AddComponent<LineChart>();
        }
        chart.title.show = true;
        chart.title.text = "CH5";
        chart.title.location.align = Location.Align.CenterRight;
        chart.theme.backgroundColor = Color.clear;
        chart.RemoveData();
        chart.AddSerie(SerieType.Line);
        chart.theme.serie.lineSymbolSize = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Gets data from the Hybrid8Test class and adds it to the line of the chart
    void Update()
    {
        valueFromClass = Hybrid8Test.valueCH5;
        if (Time.realtimeSinceStartup - m_LastTime >= INTERVAL)
        {
            m_LastTime = Time.realtimeSinceStartup;
            chart.AddData(0, valueFromClass);
        }
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
        }
    }
}
