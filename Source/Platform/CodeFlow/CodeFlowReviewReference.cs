﻿using Microsoft.Internal.Tools.TeamMate.Foundation.Diagnostics;
using System;

namespace Microsoft.Internal.Tools.TeamMate.Platform.CodeFlow
{
    public class CodeFlowReviewReference
    {
        public CodeFlowReviewReference(string key)
        {
            Assert.ParamIsNotNull(key, "key");

            this.Key = key;
        }

        public string Key { get; private set; }

        public override string ToString()
        {
            return Key;
        }

        public override bool Equals(object obj)
        {
            CodeFlowReviewReference other = obj as CodeFlowReviewReference;
            if (other != null)
            {
                return Object.Equals(Key, other.Key);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
