using System;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.Waypoints
{
    [CustomEditor(typeof(Waypoint))]
    public class WaypointEditor : Editor
    {
        private Waypoint waypoint => target as Waypoint;

        private void OnSceneGUI()
        {
            Handles.color = Color.cyan;
            for (int i = 0; i < waypoint.Points.Length; i++)
            {
                EditorGUI.BeginChangeCheck();

                Vector3 currentWaypointPoint = waypoint.CurrentPosition + waypoint.Points[i];
                Vector3 newWaypointPoint = Handles.FreeMoveHandle(currentWaypointPoint, Quaternion.identity, 0.7f,
                    new Vector3(0.3f, 0.3f, 0.3f), Handles.SphereHandleCap);

                GUIStyle textstyle = new GUIStyle();
                textstyle.fontStyle = FontStyle.Bold;
                textstyle.fontSize = 36;
                textstyle.normal.textColor = Color.white;
                Vector3 textAlligment = Vector3.down * 0.35f + Vector3.right * 0.35f;
                Handles.Label(waypoint.CurrentPosition+ waypoint.Points[i] + textAlligment, $"{i+1}", textstyle);
                EditorGUI.EndChangeCheck();

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(target, "Free Move handle");
                    waypoint.Points[i] = newWaypointPoint - waypoint.CurrentPosition;
                }
            }
        }
    }
}