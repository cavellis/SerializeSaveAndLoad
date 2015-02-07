using UnityEngine;  
using System.Collections;
using System.IO;
//Required for Editor scripts
using UnityEditor;

[CustomEditor(typeof(GameOptions))]
public class GameOptionsEditor : Editor {

	
	//Override Inspector GUI to Render custom editor
	public override void OnInspectorGUI()
	{  
		GameOptions item = (GameOptions) target;
		//Shows Default fields for editing
		DrawDefaultInspector (); 
		EditorGUILayout.HelpBox("Change game options, then hit the 'Save Game Options' button to back up the options to a JSON file. Use 'Load Game Options' to restore the options from the JSON file.", MessageType.Info);

		//Save Button
		if(GUILayout.Button("Save Game Options"))
		{
			//Set the object to dirty to make sure attributes asjusted by scripts are preserved on the object
			EditorUtility.SetDirty(target);
			Save(item.SaveData());
			EditorUtility.DisplayDialog("Save Game Options", "Game options have been saved.", "OK");
		}

		//Load Button
		if(GUILayout.Button("Load Game Options"))
		{
			//Have object load its attributes from the file
			try
			{
				string savedData = Load();

				item.SetData(savedData);
				//Mark as dirty so it is reflected in the inspector
				EditorUtility.SetDirty(target);
				EditorUtility.DisplayDialog("Load Game Options", "Game options have been loaded.", "OK");
				
			}
			catch(FileNotFoundException ex)
			{
				EditorUtility.DisplayDialog("Error", "Save data file not found.", "OK");
			}
		}
		
	}
	
	//Load Obejct data from file
	public string Load(){
		return File.ReadAllText("Assets/Resources/GameOptions.txt");
	}
	
	public void Save(string data){
		//Write File out using standard C# file IO because writing isn't supported by unity's Textasset class
        //Saved file must have .txt extension 
        File.WriteAllText("Assets/Resources/GameOptions.txt", data);
		//Call this to tell unity to reimport updated assets
		AssetDatabase.Refresh();
	}
}

