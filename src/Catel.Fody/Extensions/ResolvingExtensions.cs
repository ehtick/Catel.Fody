﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResolvingExtensions.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Fody
{
    using System;
    using System.Collections.Generic;

    using Mono.Cecil;

    public static class ResolvingExtensions
    {
        private static readonly Dictionary<string, TypeDefinition> _definitions = new Dictionary<string, TypeDefinition>();

        public static TypeDefinition ResolveType(this TypeReference reference)
        {
            TypeDefinition definition;
            if (_definitions.TryGetValue(reference.FullName, out definition))
            {
                return definition;
            }

            return _definitions[reference.FullName] = InnerResolveType(reference);
        }

        private static TypeDefinition InnerResolveType(this TypeReference reference)
        {
            try
            {
                return reference.Resolve();
            }
            catch (Exception exception)
            {
                throw new Exception(string.Format("Could not resolve '{0}'.", reference.FullName), exception);
            }
        }
    }
}