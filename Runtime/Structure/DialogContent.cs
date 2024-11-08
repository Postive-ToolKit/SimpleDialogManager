using System;
using UnityEngine;

#if HAS_LOCALIZATION
using UnityEngine.Localization;
#endif

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
namespace DialogSystem.Runtime.Structure.ScriptableObjects
{
    [Serializable]
#if ODIN_INSPECTOR
    [InlineProperty,HideLabel]
#endif
    public class DialogContent
    {
        public string Content {
            #if HAS_LOCALIZATION
            get => _content.GetLocalizedString();
            #else
            get => _content;
            #endif
        }
        #if HAS_LOCALIZATION
            [SerializeField] private LocalizedString _content;
        #else
            [SerializeField][TextArea] private string _content;
        #endif

    }
}