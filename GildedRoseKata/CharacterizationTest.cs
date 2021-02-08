using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace GildedRoseKata
{
    public class CharacterizationTest
    {
        [Fact]
        public void DoesWhatItDoes()
        {
            var sb = new StringBuilder();
            Console.SetOut(new StringWriter(sb));
            Console.SetIn(new StringReader("a\n"));
            Program.Main(new string[] { });
            String output = sb.ToString();


            string expectedOutput = File.ReadAllText("CharacterizationTest.txt");

            Assert.Equal(expectedOutput.Trim(), output.Trim());
        }
    }
}
