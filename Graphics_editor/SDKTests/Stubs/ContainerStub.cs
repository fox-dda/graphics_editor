using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap.Pipeline;
using StructureMap.Query;
using System.Collections;
using System.Reflection;
using GraphicsEditor.Tests.Stubs;
using SDKTests.Exceptions;

namespace SDKTests.Stubs
{
    public class ContainerStub : IContainer
    {
        public IModel Model { get; }

        public string Name { get; set ; }

        public ContainerRole Role { get; }

        public string ProfileName { get; }

        public ITransientTracking TransientTracking { get; }

        public DisposalLock DisposalLock { get; set; }

        public void AssertConfigurationIsValid()
        {
            throw new NotImplementedException();
        }

        public void BuildUp(object target)
        {
            throw new NotImplementedException();
        }

        public void Configure(Action<ConfigurationExpression> configure)
        {
            throw new NotImplementedException();
        }

        public IContainer CreateChildContainer()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EjectAllInstancesOf<T>()
        {
            throw new NotImplementedException();
        }

        public Container.OpenGenericTypeExpression ForGenericType(Type templateType)
        {
            throw new NotImplementedException();
        }

        public CloseGenericTypeExpression ForObject(object subject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllInstances<T>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetAllInstances(Type pluginType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllInstances<T>(ExplicitArguments args)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetAllInstances(Type pluginType, ExplicitArguments args)
        {
            throw new NotImplementedException();
        }

        public T GetInstance<T>()
        {
            throw new NotImplementedException();
        }

        public T GetInstance<T>(string instanceKey)
        {
            throw new GetInstanceExeption("");
        }

        public T GetInstance<T>(Instance instance)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type pluginType)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type pluginType, string instanceKey)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type pluginType, Instance instance)
        {
            throw new NotImplementedException();
        }

        public T GetInstance<T>(ExplicitArguments args)
        {
            throw new NotImplementedException();
        }

        public T GetInstance<T>(ExplicitArguments args, string instanceKey)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type pluginType, ExplicitArguments args)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type pluginType, ExplicitArguments args, string instanceKey)
        {
            throw new NotImplementedException();
        }

        public IContainer GetNestedContainer()
        {
            throw new NotImplementedException();
        }

        public IContainer GetNestedContainer(string profileName)
        {
            throw new NotImplementedException();
        }

        public IContainer GetNestedContainer(TypeArguments arguments)
        {
            throw new NotImplementedException();
        }

        public IContainer GetProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        public void Inject<T>(T instance) where T : class
        {
            throw new NotImplementedException();
        }

        public void Inject(Type pluginType, object instance)
        {
            throw new NotImplementedException();
        }

        public void Release(object @object)
        {
            throw new NotImplementedException();
        }

        public T TryGetInstance<T>()
        {
            throw new NotImplementedException();
        }

        public T TryGetInstance<T>(string instanceKey)
        {
            throw new NotImplementedException();
        }

        public object TryGetInstance(Type pluginType)
        {
            throw new NotImplementedException();
        }

        public object TryGetInstance(Type pluginType, string instanceKey)
        {
            throw new NotImplementedException();
        }

        public T TryGetInstance<T>(ExplicitArguments args)
        {
            throw new NotImplementedException();
        }

        public T TryGetInstance<T>(ExplicitArguments args, string instanceKey)
        {
            throw new NotImplementedException();
        }

        public object TryGetInstance(Type pluginType, ExplicitArguments args)
        {
            throw new NotImplementedException();
        }

        public object TryGetInstance(Type pluginType, ExplicitArguments args, string instanceKey)
        {
            throw new NotImplementedException();
        }

        public string WhatDidIScan()
        {
            throw new NotImplementedException();
        }

        public string WhatDoIHave(Type pluginType = null, Assembly assembly = null, string @namespace = null, string typeName = null)
        {
            throw new NotImplementedException();
        }

        public ExplicitArgsExpression With(Type pluginType, object arg)
        {
            throw new NotImplementedException();
        }

        public ExplicitArgsExpression With(Action<IExplicitArgsExpression> action)
        {
            throw new NotImplementedException();
        }

        public ExplicitArgsExpression With<T>(T arg)
        {
            throw new NotImplementedException();
        }

        public IExplicitProperty With(string argName)
        {
            throw new NotImplementedException();
        }
    }
}
