using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
using SimpleJSON;

public class APIDataRequester : MonoBehaviour
{
    // private readonly string API = "https://8ib71h0627.execute-api.us-east-1.amazonaws.com/v1/datasets/global";
    private readonly string CSV = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
    public Canvas c1, c2, c3, c4, c5, c6, c7, c8;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getData());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator getData()
    {
        // Request CSV
        UnityWebRequest dataRequest = UnityWebRequest.Get(CSV);
        yield return dataRequest.SendWebRequest();
        if (dataRequest.result == UnityWebRequest.Result.ConnectionError ||
            dataRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(dataRequest.error);
            yield break;
        }

        // Set Constants
        int i = 0;
        // Country rows in CSV
        int[] china = {59, 92};
        int[] france = {120, 131};
        int italy = 154;
        int india = 148;
        int brazil = 31;
        int morocco = 190;
        // Year-quarter columns in CSV file
        int[] q1 = {5,136};
        int[] q2 = {136,273};
        int[] q3 = {273,405};
        int[] q4 = {405,500};

        // Get Text Response
        string dataText = dataRequest.downloadHandler.text;
        
        // Parse CSV Data
        string[] lines = dataText.Split('\n');
        string[][] records = new string[lines.Length][];
        foreach (string line in lines)
        {
            records[i++] = line.Split(',');
            // foreach (string field in fields)
            // {
            //     contentArea.text += field + "\t";
            // }
            // contentArea.text += '\n';
        }
        TextMeshProUGUI c1_text = c1.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI c2_text = c2.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI c3_text = c3.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI c4_text = c4.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI c5_text = c5.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI c6_text = c6.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI c7_text = c7.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI c8_text = c8.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        
        c1_text.fontSize=3;
        c1_text.SetText($"Cases - {records[morocco][1]}:\n{records[0][q1[0]]} - {records[0][q1[1]]}\nFrom: {string.Format("{0:n0}",records[morocco][q1[0]])}\nTo: {string.Format("{0:n0}",records[morocco][q1[1]])}");

        c2_text.fontSize=3;
        c2_text.SetText($"Cases - {records[italy][1]}:\n{records[0][q2[0]]} - {records[0][q2[1]]}\nFrom: {string.Format("{0:n0}",records[italy][q2[0]])}\nTo: {string.Format("{0:n0}",records[italy][q2[1]])}");

        c3_text.fontSize=3;
        c3_text.SetText($"Cases - {records[brazil][1]}:\n{records[0][q3[0]]} - {records[0][q3[1]]}\nFrom: {string.Format("{0:n0}",records[brazil][q3[0]])}\nTo: {string.Format("{0:n0}",records[brazil][q3[1]])}");

        c4_text.fontSize=3;
        c4_text.SetText($"Cases - {records[india][1]}:\n{records[0][q3[0]]} - {records[0][q3[1]]}\nFrom: {string.Format("{0:n0}",records[india][q3[0]])}\nTo: {string.Format("{0:n0}",records[india][q3[1]])}");

        c5_text.fontSize=3;
        c5_text.SetText($"Cases - {records[morocco][1]}:\n{records[0][q4[0]]} - {records[0][q4[1]]}\nFrom: {string.Format("{0:n0}",records[morocco][q4[0]])}\nTo: {string.Format("{0:n0}",records[morocco][q4[1]])}");

        c6_text.fontSize=3;
        c6_text.SetText($"Cases - {records[italy][1]}:\n{records[0][q4[0]]} - {records[0][q4[1]]}\nFrom: {string.Format("{0:n0}",records[italy][q4[0]])}\nTo: {string.Format("{0:n0}",records[italy][q4[1]])}");

        c7_text.fontSize=3;
        c7_text.SetText($"Cases - {records[brazil][1]}:\n{records[0][q4[0]]} - {records[0][q4[1]]}\nFrom: {string.Format("{0:n0}",records[brazil][q4[0]])}\nTo: {string.Format("{0:n0}",records[brazil][q4[1]])}");

        c8_text.fontSize=3;
        c8_text.SetText($"Cases - {records[india][1]}:\n{records[0][q4[0]]} - {records[0][q4[1]]}\nFrom: {string.Format("{0:n0}",records[india][q4[0]])}\nTo: {string.Format("{0:n0}",records[india][q4[1]])}");
        // JSONNode data = JSON.Parse(dataText);
    }
}
