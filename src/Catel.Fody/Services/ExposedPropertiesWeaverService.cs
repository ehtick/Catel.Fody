﻿namespace Catel.Fody.Services
{
    using Catel.Fody.Weaving.ExposedProperties;

    public class ExposedPropertiesWeaverService
    {
        private readonly ModuleWeaver _moduleWeaver;
        private readonly Configuration _configuration;
        private readonly CatelTypeNodeBuilder _catelTypeNodeBuilder;
        private readonly MsCoreReferenceFinder _msCoreReferenceFinder;

        public ExposedPropertiesWeaverService(ModuleWeaver moduleWeaver, Configuration configuration, CatelTypeNodeBuilder catelTypeNodeBuilder,
            MsCoreReferenceFinder msCoreReferenceFinder)
        {
            _moduleWeaver = moduleWeaver;
            _configuration = configuration;
            _catelTypeNodeBuilder = catelTypeNodeBuilder;
            _msCoreReferenceFinder = msCoreReferenceFinder;
        }

        public void Execute()
        {
            if (!FodyEnvironment.IsCatelMvvmAvailable)
            {
                FodyEnvironment.WriteInfo("Skipping weaving of exposed properties because this is an MVVM feature");
                return;
            }

            var warningChecker = new ExposedPropertiesWarningChecker(_catelTypeNodeBuilder);
            warningChecker.Execute();

            var weaver = new ExposedPropertiesWeaver(_catelTypeNodeBuilder, _moduleWeaver, _configuration, _msCoreReferenceFinder);
            weaver.Execute();
        }
    }
}
