using System;
using System.Collections.Generic;
using System.Text;
using DialogSystem.Dialogs.Components.Managers;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
namespace Postive.SimpleDialogAssetManager.Runtime.Dialogs.Events
{

    [Serializable]
#if ODIN_INSPECTOR
    [InlineProperty,HideLabel]
#endif
    public class DialogEventHolder : IEventState
    {
        public bool UseSkip {
            get {
                if (_dialogEvents == null||_dialogEvents.Count <= 0) return true;
                foreach (var dialogEvent in _dialogEvents) {
                    if (dialogEvent.UseSkip) return true;
                }
                return false;
            }
        }
        public bool IsEventFinished {
            get {
                if (_dialogEvents == null||_dialogEvents.Count <= 0) return true;
                foreach (var dialogEvent in _dialogEvents) {
                    if (!dialogEvent.IsEventFinished) return false;
                }
                return true;
            }
        }

        public string Content {
            get {
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < _dialogEvents.Count; i++){
                    if (_dialogEvents[i] == null) continue;
                    sb.Append(_dialogEvents[i].Content);
                    if (i == _dialogEvents.Count - 1) continue;
                    sb.Append("\n<size=16><b>--------------------</size></b>\n");
                }
                return sb.ToString();
            }
        }
        [SerializeReference] private List<IDialogEvent> _dialogEvents;
#if UNITY_EDITOR && !ODIN_INSPECTOR
        [SerializeField] private string _type = string.Empty;
#endif
        public DialogEventHolder(List<IDialogEvent> dialogEvents) {
            _dialogEvents = dialogEvents;
        }
        public void Invoke(DialogManager manager) {
            if (_dialogEvents == null||_dialogEvents.Count <= 0) return;
            for(int i = 0; i < _dialogEvents.Count; i++){
                var dialogEvent = _dialogEvents[i];
                if (dialogEvent == null) continue;
                dialogEvent.Invoke(manager);
            }
        }
        public void AddEvent(DialogEvent dialogEvent) {
            if (_dialogEvents == null) _dialogEvents = new List<IDialogEvent>();
            _dialogEvents.Add(dialogEvent);
        }
        public void RemoveEvent(DialogEvent dialogEvent) {
            if (_dialogEvents == null) return;
            _dialogEvents.Remove(dialogEvent);
        }
    }
}