using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RPG.Dialogue { 
    [System.Serializable]
    public class DialogueNode : ScriptableObject { 
        [SerializeField] private string text;
        [SerializeField] private List<string> children;
        [SerializeField] private Rect rect = new Rect(0, 0, 200, 100); 

        public string Text {
            get => text;
#if UNITY_EDITOR
            set {
                if (!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(this))) 
                    Undo.RecordObject(this, "Changed Text");
                text = value;
            }
#endif
        }

        public List<string> Children {
            get => children;
#if UNITY_EDITOR
            set { 
                if (!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(this)))
                    Undo.RecordObject(this, "Changed Children");
                children = value;
            }
#endif
        }

        public Rect Rect {
            get => rect;
#if UNITY_EDITOR
            set {
                if (!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(this)))
                    Undo.RecordObject(this, "Changed Rect");
                rect = value;
            }
#endif
        }
    }
}