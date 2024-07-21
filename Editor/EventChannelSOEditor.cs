using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Slax.EventSystem
{
    /// <summary>
    /// Enhances the default inspector to allow to find all references of a specific
    /// event channel in the currently loaded scenes
    /// </summary>
    [CustomEditor(typeof(EventChannelSO), true)]
    public class EventChannelSOEditor : Editor
    {
        List<GameObject> _referencingObjects = new List<GameObject>();
        bool _searchPerformed = false;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Find References in Scene"))
            {
                FindReferencesInScene();
                _searchPerformed = true;
            }

            if (_searchPerformed)
            {
                if (_referencingObjects.Count > 0)
                {
                    EditorGUILayout.LabelField("Referenced by:");
                    EditorGUI.indentLevel++;
                    foreach (GameObject obj in _referencingObjects)
                    {
                        if (GUILayout.Button(obj.scene.name + ": " + obj.name))
                        {
                            EditorGUIUtility.PingObject(obj);
                            Selection.activeGameObject = obj;
                        }
                    }
                    EditorGUI.indentLevel--;
                }
                else
                {
                    EditorGUILayout.HelpBox("No references found in the current scene.", MessageType.Info);
                }
            }
        }

        void FindReferencesInScene()
        {
            _referencingObjects.Clear();
            foreach (GameObject go in GetAllObjectsInScene())
            {
                var components = go.GetComponents<MonoBehaviour>();
                foreach (var component in components)
                {
                    SerializedObject so = new SerializedObject(component);
                    SerializedProperty sp = so.GetIterator();

                    while (sp.NextVisible(true))
                    {
                        if (sp.propertyType == SerializedPropertyType.ObjectReference &&
                            sp.objectReferenceValue == target)
                        {
                            _referencingObjects.Add(go);
                            break;
                        }
                    }
                }
            }
        }

        IEnumerable<GameObject> GetAllObjectsInScene()
        {
            foreach (GameObject obj in FindObjectsOfType<GameObject>())
            {
                yield return obj;
            }
        }
    }

}