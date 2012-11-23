using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;
using CaliburnMicroWorkshop.ViewModels;

namespace CaliburnMicroWorkshop
{
    class AppBootstrapper : Bootstrapper<ShellViewModel>
    {
        private CompositionContainer _container;

        protected override void Configure()
        {
            var catalog = new AggregateCatalog(
                AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>());

            _container = new CompositionContainer(catalog, true);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(_container);
            batch.AddExportedValue(catalog);
            _container.Compose(batch);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var assemblies = new List<Assembly> { currentAssembly };
            var directory = new FileInfo(currentAssembly.Location).Directory;
            var assemblyFiles = directory.GetFiles("*.dll");
            foreach (var assemblyFile in assemblyFiles)
            {
                assemblies.Add(Assembly.LoadFile(assemblyFile.FullName));
            }
            return assemblies;
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = _container.GetExportedValues<object>(contract);

            if (exports.Any())
            {
                return exports.First();
            }

            throw new Exception(string.Format("Could not locate any instances of contract {0}.", contract));
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            _container.SatisfyImportsOnce(instance);
        }


        protected override void OnUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
                e.Handled = true;
            }
            else
            {
                Execute.OnUIThread(() => MessageBox.Show("An unexpected error occured, sorry about the troubles.", "Oops...",
                                                         MessageBoxButton.OK));
                e.Handled = true;
                Application.Shutdown();
            }

            base.OnUnhandledException(sender, e);
        }
    }
}
