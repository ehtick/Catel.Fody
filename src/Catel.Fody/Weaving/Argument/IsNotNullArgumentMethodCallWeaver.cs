﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsNotNullArgumentMethodCallWeaver.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Catel.Fody.Weaving.Argument
{
    using System.Linq;

    using Mono.Cecil;

    public sealed class IsNotNullArgumentMethodCallWeaver : DefaultArgumentMethodCallWeaveBase
    {
        protected override void SelectMethod(TypeDefinition argumentTypeDefinition, out MethodDefinition selectedMethod)
        {
            selectedMethod = argumentTypeDefinition.Methods.FirstOrDefault(definition => definition.Name == "IsNotNull" && definition.Parameters.Count == 2);
        }
    }
}