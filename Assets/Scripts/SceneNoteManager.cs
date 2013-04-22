using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class SceneNoteManager : MonoBehaviour {
	
	public Transform player;

	SceneNote currentNote;

	public List<SceneNote> notes = new List<SceneNote> ();

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
		SceneNote note = new SceneNote ();
		note.position = position;
		notes.Add (note);
	}


	SceneNote FindNearestNoteInView (Camera cam)
	{
		// Frustum check
		List<SceneNote> inView = new List<SceneNote> ();
		foreach (var note in notes) {
			var p = cam.WorldToViewportPoint (note.position);
			if (p.x < 1 && p.x > 0 && p.y < 1 && p.x > 0 && p.z > 0 && p.z < 1) {
				inView.Add (note);
			}
		}
		// Distance check
		float dist = Mathf.Infinity;
		SceneNote nearest = null;
		foreach (var note in inView) {
			float newDist = Vector3.SqrMagnitude (note.position - player.transform.position);
			if (newDist < dist) {
				dist = newDist;
				nearest = note;
			}
		}
		return nearest;
	}

	
	void OnGUI ()
	{
		if (currentNote != null) {
			if (Input.GetMouseButtonDown (0)) {
				currentNote = null;
				GUI.FocusControl (null);
			} else {
//				var pos = WorldToGUIPoint (currentNote.transform.position);
//				var r = new Rect (pos.x, pos.y, 100, 200);
//				GUI.BeginGroup (r, (GUIStyle)"box");
//				GUI.SetNextControlName ("note");
//				currentNote.text = GUILayout.TextArea (currentNote.text, GUILayout.Width (100), GUILayout.Height (200));
//				GUI.FocusControl ("note");
//				GUI.EndGroup ();
			}
		}
	}

	void OnDrawGizmos ()
	{
		// Draw note icons, and highlight the one that has focus
	}
	
	Vector2 WorldToGUIPoint (Vector3 position)
	{
		Vector3 point = Camera.main.WorldToScreenPoint (position);
		return new Vector2 (point.x, Camera.main.pixelHeight - point.y);
	}
}
