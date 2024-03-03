using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsManager : MonoBehaviour
{
    private const string DistanceKeyPrefix = "DistanceRecord_";
    private const string DateTimeKeyPrefix = "DateTimeRecord_";
    private const int TopCount = 3;
    
    private static RecordsManager instance;
    public static RecordsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<RecordsManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("RecordsManager");
                    instance = obj.AddComponent<RecordsManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public class Record
    {
        public int distance;
        public DateTime dateTime;
    }

    private List<Record> records = new List<Record>();
    
    public List<Record> GetRecords()
    {
        return records;
    }

    void Start()
    {
        LoadRecords();
    }

    void Update()
    {
    }

    private void LoadRecords()
    {
        records.Clear();
        for (int i = 0; i < TopCount; i++)
        {
            if (PlayerPrefs.HasKey(DistanceKeyPrefix + i) && PlayerPrefs.HasKey(DateTimeKeyPrefix + i))
            {
                int distance = PlayerPrefs.GetInt(DistanceKeyPrefix + i, 0);
                DateTime dateTime = DateTime.ParseExact(PlayerPrefs.GetString(DateTimeKeyPrefix + i), "yyyy-MM-dd HH:mm:ss", null);
                Record record = new Record { distance = distance, dateTime = dateTime };
                records.Add(record);
            }
            else
            {
                break;
            }
        }
    }

    private void SaveRecords()
    {
        bool topRecordSaved = false;
        for (int i = 0; i < Mathf.Min(records.Count, TopCount); i++)
        {
            PlayerPrefs.SetInt(DistanceKeyPrefix + i, records[i].distance);
            PlayerPrefs.SetString(DateTimeKeyPrefix + i, records[i].dateTime.ToString("yyyy-MM-dd HH:mm:ss"));

            if (i == 0 && !topRecordSaved)
            {
                PlayerPrefs.Save();
                topRecordSaved = true;
            }
        }
    }

    public void AddRecord(int distance)
    {
        Record newRecord = new Record { distance = distance, dateTime = DateTime.Now };

        if (records.Count == 0)
        {
            records.Add(newRecord);
            SaveRecords();
            return;
        }

        int insertIndex = -1;
        for (int i = 0; i < records.Count; i++)
        {
            if (distance > records[i].distance)
            {
                insertIndex = i;
                break;
            }
        }

        if (insertIndex != -1)
        {
            records.Insert(insertIndex, newRecord);
            if (records.Count > TopCount)
            {
                records.RemoveAt(records.Count - 1);
            }
            SaveRecords();
        }
        else if (records.Count < TopCount)
        {
            records.Add(newRecord);
            SaveRecords();
        }
    }
}