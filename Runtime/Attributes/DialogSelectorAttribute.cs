using DialogSystem.Runtime.Structure.ScriptableObjects;
using Postive.CategorizedDB.Runtime.Categories.Interfaces;
using Runtime.Attributes;
using UnityEngine;

namespace DialogSystem.Runtime.Attributes
{
    public class DialogSelectorAttribute : CategoryElementSelectorAttribute
    {
        public override ICategoryElementFinder ElementFinder => DialogDB.Instance;
    }
}