﻿using ContainerLibrary;
using System;
using UnitTestLibrary;

namespace SampleUnitTests
{
    public class AdderTests
    {
        private Container container;
        private Container Container
        {
            get
            {
                if (container == null)
                {
                    container = new Container();
                    container.Register(typeof(IAdder), (container) => { return new Adder(); });
                }
                return container;
            }
        }

        [TestMethod]
        public void One_Plus_One_Should_Equal_Two()
        {
            // Arrange
            int a = 1;
            int b = 1;
            IAdder adder = Container.GetInstance(typeof(IAdder)) as IAdder;
            // Act
            int result = adder.Add(a, b);
            // Assert
            Assert.ShouldEqual(2, result);
        }

        [TestMethod]
        public void One_Plus_One_Should_Equal_Three()
        {
            // Arrange
            int a = 1;
            int b = 1;
            IAdder adder = Container.GetInstance<IAdder>();
            // Act
            int result = adder.Add(a, b);
            // Assert
            Assert.ShouldEqual(3, result);
        }

        [TestMethod(ExpectedExceptionType = typeof(ApplicationException))]
        public void One_Plus_One_Should_Not_Error()
        {
            // Arrange
            int a = 1;
            int b = 1;
            IAdder adder = Container.GetInstance<IAdder>();
            // Act
            int result = adder.Add(a, b);
            // Assert
            Assert.ShouldEqual(3, result);
        }

        [TestMethod(Ignore = true)]
        public void One_Plus_One_Should_Be_Ignored()
        {
            // Arrange
            int a = 1;
            int b = 1;
            IAdder adder = Container.GetInstance<IAdder>();
            // Act
            int result = adder.Add(a, b);
            // Assert
            Assert.ShouldEqual(3, result);
        }
    }
}
