﻿using System;
using TheFipster.Munchkin.GameDomain.Exceptions;
using TheFipster.Munchkin.GameEvents.UnitTest.TestData;
using Xunit;

namespace TheFipster.Munchkin.GameEvents.UnitTest
{
    public class InventoryTest
    {
        [Fact]
        public void GetAllMessageTypesInAssembly_ResultsInNotEmptyMessageTypeList_Test()
        {
            // Arrange
            var inventory = new Inventory();

            // Act
            var types = inventory.GetMessageTypes();

            // Assert
            Assert.NotEmpty(types);
        }

        [Fact]
        public void GetAllActionTypesInAssembly_ResultsInNotEmptyMessageTypeList_Test()
        {
            // Arrange
            var inventory = new Inventory();

            // Act
            var types = inventory.GetActionTypes();

            // Assert
            Assert.NotEmpty(types);
        }

        [Fact]
        public void GetActionForUnknownMessage_ThrowsMissingMessageException_Test()
        {
            // Arrange
            var inventory = new Inventory();
            var unknownMessage = new UnknownMessage();

            // Act & Assert
            Assert.Throws<MissingMessageException>(
                () => inventory.GetActionFromMessage(unknownMessage, null));
        }
    }
}
