using NUnit.Framework;
using RoverNavigator.CommandParser;
using RoverNavigator.CommandParser.Commands;
using RoverNavigator.Contracts;
using System.Collections.Generic;

namespace RogerNavigator.CommandParserTests
{
    public class CommandParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("MLRLRM", true)]
        [TestCase("MLRGM", false)]
        public void Given_Command_When_Validate_Then_AcceptOnlyFew(string command, bool expected)
        {
            ICommandParserValidator cmdParser = new CmdParser(command);
            cmdParser.Parse();
            var actualResult = cmdParser.Validate();

            Assert.AreEqual(expected, actualResult);
        }

        [Test]
        public void Given_CommandString_When_Parse_Then_HaveCorrectType()
        {
            const string commands = "MLRO";
            ICommandParserValidator cmdParser = new CmdParser(commands);
            List<ICommand> processedCommands = cmdParser.Parse();

            Assert.IsInstanceOf(typeof(MoveForward), processedCommands[0]);
            Assert.IsInstanceOf(typeof(Rotate90DegreesLeft), processedCommands[1]);
            Assert.IsInstanceOf(typeof(Rotate90DegreesRight), processedCommands[2]);
            Assert.IsInstanceOf(typeof(EmptyCommand), processedCommands[3]);
        }
    }
}