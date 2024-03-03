using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Main : MonoBehaviour
{
    [SerializeField] private TMP_Text recordsText;
    private RecordsManager recordsManager;

    void Start()
    {
        recordsManager = RecordsManager.Instance;
        if (recordsManager != null)
        {
            LoadRecords();
        }
        else
        {
            Debug.LogError("RecordsManager not found!");
        }
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void LoadRecords()
    {
        recordsText.text = "TOP 3 RESULTS\n\n";
        List<RecordsManager.Record> records = recordsManager.GetRecords();
        foreach (var record in records)
        {
            recordsText.text += "Distance: " + record.distance + ", Date: " + record.dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "\n";
        }
    }

    void Update()
    {
        
    }
}