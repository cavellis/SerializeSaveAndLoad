using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;

//[JsonOptIn] = only properties that have [JsonMember] will be serialized. works with jsonfx
// this helps to hide the inherited properties like 'name,' 'tag,' 'layer,' etc. 
[JsonOptIn]
public class GameOptions : MonoBehaviour
{
	[JsonMember, Tooltip("How long until a new enemy spawns.")]
	public float enemySpawnTime = 10.0f;

	[JsonMember, Tooltip("The player's move speed."), Range(0, 10)]
	public float playerSpeed = 10;

	[JsonMember, Tooltip("The different enemy types in the game.")]
	public List<EnemyTypeVO> enemyTypes = new List<EnemyTypeVO>(0);

	//Just for fun let's do a public property. This one will show up in the inspector,
	// but it won't be saved to JSON.
	public string someTestString;

	/// <summary>
	/// Save the properties of the instance.
	/// </summary>
	/// <returns>The data.</returns>
	public string SaveData()
	{	
		string data = JsonWriter.Serialize(this);
		Debug.Log(data);
		return data;
	}

	/// <summary>
	/// Sets the properties on this instance after we load the JSON
	/// </summary>
	/// <param name="xData">X data.</param>
	public void SetData(string xData)
	{
		GameOptions oData = JsonReader.Deserialize<GameOptions>(xData);
		enemySpawnTime = oData.enemySpawnTime;
		playerSpeed = oData.playerSpeed;
		enemyTypes = oData.enemyTypes;
	}
}
