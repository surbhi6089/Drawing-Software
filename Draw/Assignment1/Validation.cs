using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// Class to check and validate the command passed by the user
    /// </summary>
    public class Validation
    {
        private static Validation instance = null;

        private Validation() { }

        /// <summary>
        /// method of return type Validation(class name) to return a single instance of the class
        /// Singleton design pattern applied
        /// </summary>
        public static Validation GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Validation();
                }
                return instance;
            }
        }
        /// <summary>
        /// a method that takes 3 parameters: command given by the user and position of cursor(x-axis and y-axis)
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <returns></returns>
        public string[] validate(string userInput, int posX, int posY)
        {
            string[] input = { };
            //splits the command given by user
            string[] splitInput = userInput.Split(',', ' ');
            List<string> each_word = new List<string>();

            //if user command is to change position
            if (splitInput[0].ToLower() == "moveto")
            {
                if (splitInput.Length == 3)
                {
                    string pox = splitInput[1];
                    string poy = splitInput[2];

                    string[] arrayInput = { "moveto", pox, poy };
                    input = arrayInput;
                }
            }
            //if user command is to change color
            else if (splitInput[0].ToLower() == "pen")
            {
                if (splitInput.Length == 2)
                {
                    string penColor = splitInput[1].ToLower();

                    string[] arrayInput = { "pen", penColor };
                    input = arrayInput;
                }
            }
            //if user command is to flash colors
            else if (splitInput[0].ToLower() == "colour")
            {
                if (splitInput.Length == 2)
                {
                    string penColor = splitInput[1].ToLower();

                    string[] arrayInput = { "colour", penColor };
                    input = arrayInput;
                }
            }
            //if user command is to turn the fill mode on or off
            else if (splitInput[0].ToLower() == "fill")
            {
                if (splitInput.Length == 2)
                {
                    string fillColor = splitInput[1].ToLower();

                    string[] arrayInput = { "fill", fillColor };
                    input = arrayInput;
                }
            }
            //if the user command is to draw line
            else if (splitInput[0].ToLower() == "drawto")
            {
                if (splitInput.Length == 3)
                {
                    string w = splitInput[1];
                    string h = splitInput[2];

                    string[] arrayInput = { "drawto", w, h };
                    input = arrayInput;
                }
            }
            //if the user command is to draw rectangle
            else if (splitInput[0].ToLower() == "rectangle")
            {
                if (splitInput.Length == 3)
                {
                    string w = splitInput[1];
                    string h = splitInput[2];

                    string[] arrayInput = { "rectangle", w, h };
                    input = arrayInput;
                }
            }
            //if the user command is to draw circle
            else if (splitInput[0].ToLower() == "circle")
            {
                if (splitInput.Length == 2)
                {
                    string r = splitInput[1];

                    string[] arrayInput = { "circle", r };
                    input = arrayInput;
                }
            }
            //if the user command is to draw triangle
            else if (splitInput[0].ToLower() == "triangle")
            {
                if (splitInput.Length == 5)
                {
                    string x2 = splitInput[1];
                    string y2 = splitInput[2];
                    string x3 = splitInput[3];
                    string y3 = splitInput[4];

                    string[] arrayInput = { "triangle", x2, y2, x3, y3 };
                    input = arrayInput;
                }
            }
            //if the user command is to run single line if command
            else if (splitInput.Contains("then"))
            {
                if (splitInput.Length >= 5)
                {
                    string joined_string = string.Join(" ", splitInput);
                    string[] joined_array = joined_string.Split(new string[] { "if", "then" }, StringSplitOptions.None);
                    string condition = joined_array[1].Trim();
                    string single_line_command = joined_array[2].Trim();

                    string[] arrayInput = { "singleif", condition, single_line_command };
                    input = arrayInput;
                }
            }
            //if the user command is to rub=n if block command
            else if (splitInput[0].ToLower() == "if")
            {
                if (splitInput.Length == 2)
                {
                    string condition = splitInput[1];

                    string[] arrayInput = { "if", condition };
                    input = arrayInput;
                }
            }
            //if the user command is to run loop command
            else if (splitInput[0].ToLower() == "loop")
            {
                if (splitInput.Length == 2)
                {
                    string loops = splitInput[1];

                    string[] arrayInput = { "loop", loops };
                    input = arrayInput;
                }
            }
            //block to return right value/array for block closing commands
            else if (splitInput[0].ToLower() == "endif" || splitInput[0].ToLower() == "endloop" || splitInput[0].ToLower() == "endmethod")
            {
                if (splitInput.Length == 1)
                {
                    string tag = splitInput[0];

                    string[] arrayInput = { tag };
                    input = arrayInput;

                }
            }
            //this single block determines if the user is giving a command to run method with parameters or method without parameter and returns appropriate value
            else if (splitInput[0].ToLower() == "method")
            {
                List<string> check_method_type = new List<string>();
                foreach (string element in splitInput)
                {
                    string[] split_all = element.Split(new string[] { "(", ")", "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in split_all)
                    {
                        check_method_type.Add(word);
                    }
                }
                if (check_method_type.Count() == 2)
                {
                    string method_name = splitInput[1].ToLower();

                    string[] arrayInput = { "no_parameter_method", method_name };
                    input = arrayInput;
                }
                else if (check_method_type.Count() > 2)
                {
                    string joined_string = string.Join(" ", splitInput);
                    string[] joined_array = joined_string.Split(new string[] {"method", "mymethod"}, StringSplitOptions.RemoveEmptyEntries);
                    string method_name = "mymethod" + joined_array[1];

                    string[] arrayInput = { "parameter_method", method_name };
                    input = arrayInput;
                }
            }
            //if user command is invoking a method
            else if (splitInput[0].ToLower().Contains("mymethod"))
            {
                string[] arrayInput = { "method_called" };
                input = arrayInput;
            }
            //this single block determines if the user is giving simple variable value assigning command or adding values to an existing variable returns
            //appropriate value
            else if (splitInput.Contains("="))
            {
                foreach (string element in splitInput)
                {
                    string[] split_all = element.Split(new string[] { "+", "-", "*", "/" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in split_all)
                    {
                        each_word.Add(word);
                    }

                }
                int range = each_word.Count();
                if (range == 3)
                {
                    string variable = splitInput[0];
                    string value = splitInput[2];

                    string[] arrayInput = { "assignValue", variable, value };
                    input = arrayInput;
                }
                else if (range == 4)
                {
                    string variable = splitInput[0];
                    string operation = splitInput[2];

                    string[] arrayInput = { "variable_operation", variable, operation };
                    input = arrayInput;
                }
            }
            //if the commands are not supported by the program
            else
            {
                string[] arrayInput = { "error" };
                input = arrayInput;
            }
            return input;
        }
    }
}
