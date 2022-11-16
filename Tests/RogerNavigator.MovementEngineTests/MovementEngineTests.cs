using NUnit.Framework;
using RoverNavigator.CommandParser.Commands;
using RoverNavigator.Contracts;
using RoverNavigator.Entities;
using RoverNavigator.Enums;
using RoverNavigator.MovementEngine;
using System.Collections.Generic;

namespace RogerNavigator.MovementEngineTests
{
    public class MovementEngineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(Direction.North, Direction.West)]
        [TestCase(Direction.East, Direction.North)]
        [TestCase(Direction.South, Direction.East)]
        [TestCase(Direction.West, Direction.South)]
        public void Given_InitialDirection_When_RotateLeft_Then_UpdateDirection(Direction initial, Direction expected)
        {
            IPlateau plateau = new Plateau(7, 7);
            IMachine rover = new Rover()
            {
                Location = new Location(1, 1),
                Direction = initial
            };
            var processedCmd1 = new List<ICommand>() { new Rotate90DegreesLeft() };
            IMovementEngine engine = new Engine(plateau);

            engine.AddMachine(rover, processedCmd1);
            engine.RunInSequence();

            Assert.AreEqual(expected, rover.Direction);
        }

        [Test]
        [TestCase(Direction.North, Direction.East)]
        [TestCase(Direction.East, Direction.South)]
        [TestCase(Direction.South, Direction.West)]
        [TestCase(Direction.West, Direction.North)]
        public void Given_InitialDirection_When_RotateRight_Then_UpdateDirection(Direction initial, Direction expected)
        {
            IPlateau plateau = new Plateau(7, 7);
            IMachine rover = new Rover()
            {
                Location = new Location(1, 1),
                Direction = initial
            };
            var processedCmd1 = new List<ICommand>() { new Rotate90DegreesRight() };
            IMovementEngine engine = new Engine(plateau);

            engine.AddMachine(rover, processedCmd1);
            engine.RunInSequence();

            Assert.AreEqual(expected, rover.Direction);
        }

        [Test]
        [TestCase(Direction.North, 1, 2)]
        [TestCase(Direction.East, 2, 1)]
        [TestCase(Direction.South, 1, 0)]
        [TestCase(Direction.West, 0, 1)]
        public void Given_InitialDirection_When_Move_Then_UpdatePosition(Direction initial, int locationX, int locationY)
        {
            IPlateau plateau = new Plateau(7, 7);
            IMachine rover = new Rover()
            {
                Location = new Location(1, 1),
                Direction = initial
            };
            var processedCmd1 = new List<ICommand>() { new MoveForward(1) };
            IMovementEngine engine = new Engine(plateau);

            engine.AddMachine(rover, processedCmd1);
            engine.RunInSequence();

            Assert.AreEqual(locationX, rover.Location.X);
            Assert.AreEqual(locationY, rover.Location.Y);
        }

        [Test]
        public void Given_MultipleRovers_When_Intersect_Then_HaveError()
        {
            IPlateau plateau = new Plateau(7, 7);
            IMachine rover1 = new Rover()
            {
                Location = new Location(2, 2),
                Direction = Direction.West
            };
            var processedCmd1 = new List<ICommand>() { new MoveForward(1) };
            IMachine rover2 = new Rover()
            {
                Location = new Location(1, 1),
                Direction = Direction.North
            };
            var processedCmd2 = new List<ICommand>() { new MoveForward(1), new MoveForward(1) };
            Engine engine = new Engine(plateau);

            engine.AddMachine(rover1, processedCmd1);
            engine.AddMachine(rover2, processedCmd2);
            engine.RunInSequence();

            Assert.AreEqual("Machine crush.", engine.Error);
            Assert.AreEqual(1, rover2.Location.X);
            Assert.AreEqual(2, rover2.Location.Y);
        }

        [Test]
        public void Given_Rover_When_ExceedsPlateau_Then_HaveError()
        {
            IPlateau plateau = new Plateau(7, 7);
            IMachine rover1 = new Rover()
            {
                Location = new Location(7, 7),
                Direction = Direction.East
            };
            var processedCmd1 = new List<ICommand>() { new MoveForward(1), new MoveForward(1) };
            Engine engine = new Engine(plateau);

            engine.AddMachine(rover1, processedCmd1);
            engine.RunInSequence();

            Assert.AreEqual("Machine not on plateau.", engine.Error);
            Assert.AreEqual(8, rover1.Location.X);
            Assert.AreEqual(7, rover1.Location.Y);
        }
    }
}