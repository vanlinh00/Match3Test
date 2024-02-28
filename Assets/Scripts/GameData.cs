using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataGame
{
    public string key;
    public GameObject value;
}
[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public List<DataGame> dataGames;
}
