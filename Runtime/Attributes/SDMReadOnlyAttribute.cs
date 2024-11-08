using UnityEngine;

namespace DialogSystem.Runtime.Attributes
{
    public class SDMReadOnlyAttribute : PropertyAttribute {
        public readonly bool runtimeOnly;
        public SDMReadOnlyAttribute(bool runtimeOnly = false)
        {
            this.runtimeOnly = runtimeOnly;
        }
    }
}