﻿using System.Collections.Generic;

namespace Mahamudra.Text.Analysis
{
    public class  LettersEnglish
    {
        public static Dictionary<char, double> Frequency { get; set; } = 
            new Dictionary<char, double>()
            {
                { 'a' ,  0.082 },
                { 'b' ,  0.015},
                { 'c' ,  0.028},
                { 'd' ,  0.043},
                { 'e' ,  0.013},
                { 'f' ,  0.022},
                { 'g' ,  0.02},
                { 'h' ,  0.061},
                { 'i' ,  0.07},
                { 'j' ,  0.0015},
                { 'k' ,  0.0077},
                { 'l' ,  0.04},
                { 'm' ,  0.024},
                { 'n' ,  0.067},
                { 'o' ,  0.075},
                { 'p' ,  0.019},
                { 'q' ,  0.00095},
                { 'r' ,  0.06},
                { 's' ,  0.063},
                { 't' ,  0.091},
                { 'u' ,  0.028},
                { 'v' ,  0.98},
                { 'w' ,  0.024},
                { 'x' ,  0.0015},
                { 'y' ,  0.02},
                { 'z' ,  0.00074}
            };
    }
}
