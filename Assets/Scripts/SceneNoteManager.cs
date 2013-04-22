using UnityEngine;
using System.Collections;

public class SceneNoteManager : MonoBehaviour {
	
	SceneNote currentNote;
	
	void ViewNote (SceneNote note)
	{
		currentNote = note;
	}
	
	void HideNotes ()
	{
		currentNote = null;
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.BackQuote)) {
			CreateNoteWithRaycast ();
		}
	}
	
	void CreateNoteWithRaycast ()
	{
		var ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
			CreateNoteAtPosition (hit.point);
		}
	}
	
	void CreateNoteAtPosition (Vector3 position)
	{
		GameObject go = new GameObject ("Note");
		go.transform.position = position;
		var note = go.AddComponent<SceneNote> ();
		currentNote = note;
	}
	
	
	void OnGUI ()
	{
		if (currentNote != null) {
			if (Input.GetMouseButtonDown (0)) {
				currentNote = null;
				GUI.FocusControl (null);
			} else {
				var pos = WorldToGUIPoint (currentNote.transform.position);
				var r = new Rect (pos.x, pos.y, 100, 200);
				GUI.BeginGroup (r, (GUIStyle)"box");
				GUI.SetNextControlName ("note");
				currentNote.text = GUILayout.TextArea (currentNote.text, GUILayout.Width (100), GUILayout.Height (200));
				GUI.FocusControl ("note");
				GUI.EndGroup ();
			}
		}
	}
	
	Vector2 WorldToGUIPoint (Vector3 position)
	{
		Vector3 point = Camera.main.WorldToScreenPoint (position);
		return new Vector2 (point.x, Camera.main.pixelHeight - point.y);
	}
}
