﻿using System;

namespace CSharp.Helpers.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }

        public static bool IsNullOrEmpty(this Guid guid)
        {
            return guid == null || guid == Guid.Empty;
        }
    }
}
