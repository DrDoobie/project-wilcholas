using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataHandler {

	public static void SaveData (PlayerStats playerStats) {
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/test.fun";
		FileStream stream = new FileStream(path, FileMode.Create);

		SavedData data = new SavedData(playerStats);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static SavedData LoadData () {
		string path = Application.persistentDataPath + "/test.fun";

		if(File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);
			SavedData data = formatter.Deserialize(stream) as SavedData;

			stream.Close();
			return data;
			
		} else {
			Debug.LogError("Save file not found in " + path);
			return null;
		}
	}
}
