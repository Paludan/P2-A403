﻿using System;
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
        public void helpTextController()
        {
            String[] helpText = SaveLoadTools.loadHelpText("vejledning.txt");
            currentLine = -1;
            if (helpText == null) { helpText = new String[1]; helpText[1] = "Ingen vejledning fundet."; }
        }

        public String[] Next()
        {
            currentLine++;
            String[] output = new String[2];
            if (currentLine > helpText.Length) { currentLine = 0; }
            else if (currentLine == helpText.Length) { output[0] = helpText.ElementAt(currentLine - 1); output[1] = "Færdig."; }
            else { output[0] = helpText.ElementAt(currentLine - 1); output[1] = helpText.ElementAt(currentLine); }
            return output;
        }
    }
}
