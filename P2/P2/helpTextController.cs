using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2
{
    //This class holds the help text, and cycles through it using the .Next method.
    class helpTextController
    {
        private static int currentLine;
        private String[] helpText;

        //Constructor for helpTextController
        public helpTextController()
        {
            helpText = SaveLoadTools.loadText(@"\vejledning.txt");
            currentLine = -1;
            if (helpText == null) { helpText = new String[2]; helpText[0] = "Ingen vejledning fundet."; helpText[1] = "opret 'vejledning.txt' i mappen 'Simulation Data'.\n" + SaveLoadTools.path; }
        }

        /// <summary>
        /// Cycles through vejledning.txt Once the last line is exceeded it starts over.
        /// </summary>
        /// <returns>A string[2] array containing current and next objectives</returns>
        public String[] Next()
        {
            currentLine++;
            String[] output = new String[2];
            if (currentLine >= helpText.Length) { currentLine = 0; }
            if (currentLine == helpText.Length - 1) { output[0] = helpText.ElementAt(currentLine); output[1] = "Færdig. Klik 'Videre' igen for at gentage vejledning."; }
            else { output[0] = helpText.ElementAt(currentLine); output[1] = helpText.ElementAt(currentLine + 1); }
            return output;
        }
    }
}
