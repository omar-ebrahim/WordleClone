using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleClone.Helpers;
using Xunit;

namespace WordleClone.Tests.Helpers
{
    public class GuessHelperTests
    {
        [Fact]
        public void GuessWord_InputWordIsNotTheSameLengthAsCompareWord_ReturnsGivenWord()
        {
            // Arrange
            var helper = new GuessHelper("ABCD");

            // Act
            var result = helper.GuessWord("FGHII");

            // Assert
            Assert.Equal("FGHII", result);
        }

        [Fact]
        public void GuessWord_NoMatchingCharacters_ReturnsWordWithNoSpecialCharacters()
        {
            // Arrange
            var helper = new GuessHelper("ABCD");

            // Act
            var result = helper.GuessWord("FGHI");

            // Assert
            Assert.Equal("FGHI", result);
        }

        [Fact]
        public void GuessWord_OneMatchingCharacterInCorrectPosition_SurroundsCharacterWithBraces()
        {
            // Arrange
            var helper = new GuessHelper("abcd");

            // Act
            var result = helper.GuessWord("aeee");

            // Assert
            Assert.Equal("{a}eee", result);
        }

        [Fact]
        public void GuessWord_LetterCorrectButInWrongPlace_SurroundsWithAngleBrackets()
        {
            // Arrange
            var helper = new GuessHelper("abcd");

            // Act
            var result = helper.GuessWord("efga");

            // Assert
            Assert.Equal("efg<a>", result);
        }

        [Fact]
        public void GuessWord_TakesMoreAttempts_NumberOfAttemptsIncreases()
        {
            // Arrange
            var helper = new GuessHelper("abcd");

            // Act
            helper.GuessWord("efga");
            helper.GuessWord("efga");
            helper.GuessWord("efga");

            // Assert
            Assert.Equal(3, helper.NumberOfGuesses);
        }
    }
}
