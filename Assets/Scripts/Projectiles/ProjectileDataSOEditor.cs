using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Projectiles.Components.ComponentData;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace DefaultNamespace.Projectiles
{
    public class ProjectileDataSOEditor : Editor
    {
        private static List<Type> dataCompTypes = new List<Type>();

        private ProjectileDataSO _dataSo;

        private bool showAddComponentButtons;

        private void OnEnable()
        {
            _dataSo = target as ProjectileDataSO;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            showAddComponentButtons = EditorGUILayout.Foldout(showAddComponentButtons, "Add Components");

            if (showAddComponentButtons)
            {
                foreach (var dataCompType in dataCompTypes)
                {
                    if (GUILayout.Button(dataCompType.Name))
                    {
                        var comp = Activator.CreateInstance(dataCompType) as ComponentData;

                        if (comp == null) return;
                    
                        comp.InitializeAttackData();
                    
                        _dataSo.AddData(comp);
                    }
                }
            }
        }

        [DidReloadScripts]
        private static void OnRecompile()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly => assembly.GetTypes());
            var filteredTypes = types.Where(
                type => type.IsSubclassOf(typeof(ComponentData)) && !type.ContainsGenericParameters && type.IsClass
            );
            dataCompTypes = filteredTypes.ToList();
        }
    }
}