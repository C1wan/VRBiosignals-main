using System.Threading;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;
public class CH2 : MonoBehaviour
{


    public static float valueFromClass;
    float elapsed = 0f;

    public float INTERVAL = 1f;
    //Anzahl  Daten welche angezeigt werden soll -> ÄNDERN damit es schneller angezeigt werden kann
    public int maxCache = 100;

    private float m_LastTime = 0f;
    private LineChart chart;

    


    void Awake()
    {

        chart = gameObject.GetComponent<LineChart>();
        createChart();
        chart.SetMaxCache(maxCache);
        // AddDatas();

    }


    void createChart()
    {
        if (chart == null)
        {
            chart = gameObject.AddComponent<LineChart>();
        }

        // transpaenter hintergrund
        //chart.ThemeStyle.transparentBackground = true  ;
        chart.title.show = true;
        chart.title.text = "CH2";
        chart.title.location.align = Location.Align.CenterRight;

        // Hintergrund Farbe auf transparenrt geändert
        chart.theme.backgroundColor = Color.clear;
       /* chart.tooltip.show = true;
        chart.legend.show = false;
        chart.xAxes[0].show = true;
        chart.xAxes[1].show = false;
        chart.yAxes[0].show = true;
        chart.yAxes[1].show = false;
        chart.xAxes[0].type = Axis.AxisType.Category;
        chart.yAxes[0].type = Axis.AxisType.Value;
        chart.xAxes[0].splitNumber = 10;
        chart.xAxes[0].boundaryGap = true;*/
        //Line symbol size
        chart.RemoveData();
        chart.AddSerie(SerieType.Line);
        chart.theme.serie.lineSymbolSize = 0;
     //  chart.LineSymbolSize = 0;
    // chart.theme.serie.line.symbol.size = 0;

    }






    // Wert von Hybrid8CS kriegen -> dann hier rüberleiten
    // in das Diagramm einfügen und weitermachen
    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        valueFromClass = Hybrid8Test.valueCH2;
        if (Time.realtimeSinceStartup - m_LastTime >= INTERVAL)
        {

            m_LastTime = Time.realtimeSinceStartup;
            chart.AddData(0, valueFromClass);

        }
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;

           // UnityEngine.Debug.Log(valueFromClass);
        }
    }
}
