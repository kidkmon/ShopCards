using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class PlayerPrefsHelper 
{
    public static void AddIntList(string key, int intToInsert)
    {
        string serialized = PlayerPrefs.GetString(key, "");
        serialized =  $"{serialized},{intToInsert}";
        PlayerPrefs.SetString(key, serialized);
        PlayerPrefs.Save();
    }

    public static void SaveIntList(string key, List<int> list)
    {
        string serialized = string.Join(",", list);
        PlayerPrefs.SetString(key, serialized);
        PlayerPrefs.Save();
    }

    public static List<int> LoadIntList(string key)
    {
        string serialized = PlayerPrefs.GetString(key, "");
        if (string.IsNullOrEmpty(serialized))
            return new List<int>();

        return serialized
            .Split(',')
            .Where(s => int.TryParse(s, out _))
            .Select(s => int.Parse(s))
            .ToList();
    }

    public static void DeleteIntList(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}