﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CTL504.cs" company="Catel development team">
//   Copyright (c) 2008 - 2014 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Fody.TestAssembly
{
    using Data;

    public class CTL504_Model : ModelBase
    {
        public string IsoCode
        {
            get { return GetValue<string>(IsoCodeProperty); }
            set { SetValue(IsoCodeProperty, value); }
        }

#if CATEL_5
        public static readonly PropertyData IsoCodeProperty = RegisterProperty<CTL504_Model, string>(o => o.IsoCode);
#elif CATEL_6
        public static readonly IPropertyData IsoCodeProperty = RegisterProperty<CTL504_Model, string>(o => o.IsoCode);
#endif

        public string Description
        {
            get { return GetValue<string>(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

#if CATEL_5
        public static readonly PropertyData DescriptionProperty = RegisterProperty<CTL504_Model, string>(o => o.Description);
#elif CATEL_6
        public static readonly IPropertyData DescriptionProperty = RegisterProperty<CTL504_Model, string>(o => o.Description);
#endif
    }
}
