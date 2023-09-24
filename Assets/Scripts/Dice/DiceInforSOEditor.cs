using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.ScriptableObjects;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace DefaultNamespace
{
    [CustomEditor(typeof(DiceInforSO))]
    public class DiceInforSOEditor : Editor
    {
        private static List<Type> dataCompTypes;
        private bool showAddComponentsButton;

        private DiceInforSO _dataSO;

        private void OnEnable()
        {
            _dataSO = target as DiceInforSO;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            showAddComponentsButton = EditorGUILayout.Foldout(showAddComponentsButton, "Add DiceResult");
            
            foreach (var dataCompType in dataCompTypes)
            {
                if (GUILayout.Button(dataCompType.Name))
                {
                    var comp = Activator.CreateInstance(dataCompType) as IDataDiceResult;

                    if (comp == null) return;

                    _dataSO.AddData(comp);
                }
            }
        }
        
        [DidReloadScripts]
        private static void OnRecompile()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());
            var filteredTypes = types.Where(
                type => typeof(IDataDiceResult).IsAssignableFrom(type) && !type.ContainsGenericParameters && type.IsClass
            );
            Debug.Log(typeof(IDataDiceResult).IsAssignableFrom(typeof(TowerInfor)));
            dataCompTypes = filteredTypes.ToList();
        }
    }
}