using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEditorInternal;

namespace Slax.EventSystem
{
    public class EventChannelSOCreatorWindow : EditorWindow
    {
        private string className = "NewEventChannelSO";
        private string menuName = "Events/Gameplay/NewEventChannelSO";
        private List<string> selectedTypes = new List<string>();
        private List<MonoScript> selectedScripts = new List<MonoScript>();
        private List<string> displayTypes = new List<string>();
        private string assetPath;
        private const string assetPathKey = "EventChannelCreator_AssetPath";

        private ReorderableList reorderableList;
        private bool addCustomClassFlag = false;
        private Vector2 scrollPosition;


        private readonly string[] supportedTypeNames = new string[]
        {
            "bool",
            "int",
            "float",
            "string",
            "AudioClip",
            "Collider",
            "GameObject",
            "MonoBehaviour",
            "Object",
            "Quaternion",
            "Rigidbody",
            "Scene",
            "ScriptableObject",
            "Sprite",
            "Texture",
            "Transform",
            "Vector2",
            "Vector3",
        };

        [MenuItem("Slax/Event System/Event Channel Creator")]
        public static void ShowWindow()
        {
            GetWindow<EventChannelSOCreatorWindow>("Event Channel Creator");
        }

        private void OnEnable()
        {
            assetPath = EditorPrefs.GetString(assetPathKey, "Assets/Scripts/Events/");
            reorderableList = new ReorderableList(displayTypes, typeof(string), true, true, true, true)
            {
                drawHeaderCallback = (Rect rect) =>
            {
                EditorGUI.LabelField(rect, "Selected Types");
            },

                drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    rect.y += 2;
                    EditorGUI.LabelField(new Rect(rect.x, rect.y, rect.width - 30, EditorGUIUtility.singleLineHeight), displayTypes[index]);
                    if (GUI.Button(new Rect(rect.x + rect.width - 30, rect.y, 20, EditorGUIUtility.singleLineHeight), "x"))
                    {
                        RemoveTypeAt(index);
                    }
                },

                onAddDropdownCallback = (Rect buttonRect, ReorderableList l) =>
                {
                    GenericMenu menu = new GenericMenu();
                    for (int i = 0; i < supportedTypeNames.Length; i++)
                    {
                        string typeName = supportedTypeNames[i];
                        menu.AddItem(new GUIContent(typeName), false, OnAddPrimitiveType, typeName);
                    }
                    menu.AddSeparator("");
                    menu.AddItem(new GUIContent("Add Custom Class"), false, OnAddCustomClass);
                    menu.ShowAsContext();
                }
            };
        }

        private void OnAddPrimitiveType(object type)
        {
            string typeName = (string)type;
            selectedTypes.Add(typeName);
            displayTypes.Add(typeName);
        }

        private void OnAddCustomClass()
        {
            addCustomClassFlag = true;
        }

        private void OnGUI()
        {
            GUILayout.Label("Create New Event Channel", EditorStyles.boldLabel);

            GUILayout.Space(10);

            scrollPosition = GUILayout.BeginScrollView(scrollPosition);

            // Display reorderable list
            reorderableList.DoLayoutList();

            // Display fields to add custom classes
            if (addCustomClassFlag)
            {
                selectedScripts.Add(null);
                addCustomClassFlag = false;
            }

            for (int i = 0; i < selectedScripts.Count; i++)
            {
                selectedScripts[i] = (MonoScript)EditorGUILayout.ObjectField($"Custom Class {i + 1}", selectedScripts[i], typeof(MonoScript), false);

                if (selectedScripts[i] != null)
                {
                    Type scriptClass = selectedScripts[i].GetClass();
                    if (scriptClass != null)
                    {
                        selectedTypes.Add(scriptClass.Name);
                        displayTypes.Add(scriptClass.Name);
                    }
                    selectedScripts.RemoveAt(i);
                    i--;
                }
            }

            if (displayTypes.Count > 0)
            {
                if (GUILayout.Button("Clear", GUILayout.Width(60)))
                {
                    ClearAll();
                }
            }

            GUILayout.Space(10);

            className = EditorGUILayout.TextField("Class Name", className);
            className = className.Trim();
            menuName = EditorGUILayout.TextField("Menu Name", menuName);

            GUILayout.Space(10);

            GUILayout.Label("Asset Path", EditorStyles.boldLabel);

            GUILayout.BeginHorizontal();
            assetPath = EditorGUILayout.TextField("Path", assetPath);
            if (GUILayout.Button("Save", GUILayout.Width(60)))
            {
                EditorPrefs.SetString(assetPathKey, assetPath);
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            if (displayTypes.Count > 0)
            {
                GUI.backgroundColor = Color.cyan;
                if (GUILayout.Button("Create Event Channel Script", GUILayout.Height(60)))
                {
                    CreateEventChannel();
                    ClearAll();
                }
            }
            else
            {
                EditorGUILayout.HelpBox("Please select at least one type.", MessageType.Info);
            }
            GUILayout.EndScrollView();
        }

        private void RemoveTypeAt(int index)
        {
            string typeName = displayTypes[index];
            displayTypes.RemoveAt(index);

            selectedTypes.Remove(typeName);
        }

        private void ClearAll()
        {
            selectedTypes.Clear();
            displayTypes.Clear();
            selectedScripts.Clear();
            className = "NewEventChannelSO";
            menuName = "Events/Gameplay/New Event Channel";
        }

        private void CreateEventChannel()
        {
            if (string.IsNullOrWhiteSpace(className) || string.IsNullOrWhiteSpace(menuName) || string.IsNullOrWhiteSpace(assetPath) || selectedTypes.Count == 0)
            {
                Debug.LogError("Please fill in all fields and select at least one type.");
                return;
            }

            string parameters = string.Join(", ", displayTypes.ConvertAll(type => $"{type} _{char.ToLower(type[0]) + type.Substring(1)}"));
            string parameterNames = string.Join(", ", displayTypes.ConvertAll(type => $"_{char.ToLower(type[0]) + type.Substring(1)}"));
            string actionTypes = string.Join(", ", selectedTypes);
            string filePath = Path.Combine(assetPath, $"{className}.cs");

            if (!Directory.Exists(assetPath))
            {
                Directory.CreateDirectory(assetPath);
            }

            string template = $@"
using UnityEngine.Events;
using UnityEngine;
using Slax.EventSystem;

[CreateAssetMenu(menuName = ""{menuName}"")]
public class {className} : EventChannelSO
{{
    public UnityAction<{actionTypes}> OnEventRaised;

    public void RaiseEvent({parameters})
    {{
        if (OnEventRaised != null)
            OnEventRaised.Invoke({parameterNames});
    }}
}}";

            File.WriteAllText(filePath, template);
            AssetDatabase.Refresh();
        }
    }
}
