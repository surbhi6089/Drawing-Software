using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Assignment1
{
    /// <summary>
    /// Partial class Form1
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// all the necessary variables declared and/or assigned 
        /// </summary>
        ShapeFactory factory = new ShapeFactory();
        Shapes shape;
        Graphics g;
        int x = 0;
        int y = 0;
        Color shapeColour = Color.Black;
        bool fillMode;
        string command;
        string new_loop_command;

        Dictionary<string, int> variable_dict = new Dictionary<string, int>();
        Dictionary<string, List<string> > method_dict = new Dictionary<string, List<string> >();


        string main_command = "";
        bool ignore_line = false;
        bool method_invoked = false;
        bool block_closed = true;
        List<string> method_all_commands = new List<string>();
        List<string> invokation_command = new List<string>();

        int point1 = 0;
        int point2 = 0;
        int point3 = 0;
        int point4 = 0;
        int width = 0;
        int height = 0;
        int radius = 0;

        Thread newThread;
        Thread newThread2;
        Thread newThread3;
        Thread newThread4;
        Thread thread2;
        bool change_color = false, blue_yellow = false, red_green = false, black_white = false, blink = false;
        string blink_shape = "";

        /// <summary>
        /// default constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            g = outputWindow.CreateGraphics();
            thread2 = new Thread(passCommandType);
            thread2.Start();
        }

        /// <summary>
        /// method to change color of shapes every half a second
        /// does not take any parameters
        /// </summary>
        public void flashColorThread()
        {
            while (true) 
            {
                while (blue_yellow || black_white || red_green)
                {
                    if (blue_yellow)
                    {
                        if (blink == false)
                        {
                            if (blink_shape == "circle")
                            {
                                shapeColour = Color.Blue;
                                shape = factory.GetShape("circle");
                                shape.set(shapeColour, fillMode, x, y, radius);
                                shape.draw(g);
                                blink = true;
                            }
                            else if (blink_shape == "rectangle")
                            {
                                shapeColour = Color.Blue;
                                shape = factory.GetShape("rectangle");
                                shape.set(shapeColour, fillMode, x, y, width, height);
                                shape.draw(g);
                                blink = true;
                            }
                            else if (blink_shape == "triangle")
                            {
                                shapeColour = Color.Blue;
                                shape = factory.GetShape("triangle");
                                shape.set(shapeColour, fillMode, x, y, point1, point2, point3, point4);
                                shape.draw(g);
                                blink = true;
                            }
                            else if (blink_shape == "drawto")
                            {
                                shapeColour = Color.Blue;
                                shape = factory.GetShape("drawto");
                                shape.set(shapeColour, fillMode, x, y, point1, point2);
                                shape.draw(g);
                                blink = true;
                            }
                        }
                        else
                        {
                            if (blink_shape == "circle")
                            {
                                shapeColour = Color.Yellow;
                                shape = factory.GetShape("circle");
                                shape.set(shapeColour, fillMode, x, y, radius);
                                shape.draw(g);
                                blink = false;
                            }
                            else if (blink_shape == "rectangle")
                            {
                                shapeColour = Color.Yellow;
                                shape = factory.GetShape("rectangle");
                                shape.set(shapeColour, fillMode, x, y, width, height);
                                shape.draw(g);
                                blink = false;
                            }
                            else if (blink_shape == "triangle")
                            {
                                shapeColour = Color.Yellow;
                                shape = factory.GetShape("triangle");
                                shape.set(shapeColour, fillMode, x, y, point1, point2, point3, point4);
                                shape.draw(g);
                                blink = false;
                            }
                            else if (blink_shape == "drawto")
                            {
                                shapeColour = Color.Yellow;
                                shape = factory.GetShape("drawto");
                                shape.set(shapeColour, fillMode, x, y, point1, point2);
                                shape.draw(g);
                                blink = false;
                            }
                        }
                        Thread.Sleep(500);
                    }
                    else if (red_green)
                    {
                        if (blink == false)
                        {
                            if (blink_shape == "circle")
                            {
                                shapeColour = Color.Red;
                                shape = factory.GetShape("circle");
                                shape.set(shapeColour, fillMode, x, y, radius);
                                shape.draw(g);
                                blink = true;
                            }
                            else if (blink_shape == "rectangle")
                            {
                                shapeColour = Color.Red;
                                shape = factory.GetShape("rectangle");
                                shape.set(shapeColour, fillMode, x, y, width, height);
                                shape.draw(g);
                                blink = true;
                            }
                            else if (blink_shape == "triangle")
                            {
                                shapeColour = Color.Red;
                                shape = factory.GetShape("triangle");
                                shape.set(shapeColour, fillMode, x, y, point1, point2, point3, point4);
                                shape.draw(g);
                                blink = true;
                            }
                            else if (blink_shape == "drawto")
                            {
                                shapeColour = Color.Red;
                                shape = factory.GetShape("drawto");
                                shape.set(shapeColour, fillMode, x, y, point1, point2);
                                shape.draw(g);
                                blink = true;
                            }
                        }
                        else
                        {
                            if (blink_shape == "circle")
                            {
                                shapeColour = Color.Green;
                                shape = factory.GetShape("circle");
                                shape.set(shapeColour, fillMode, x, y, radius);
                                shape.draw(g);
                                blink = false;
                            }
                            else if (blink_shape == "rectangle")
                            {
                                shapeColour = Color.Green;
                                shape = factory.GetShape("rectangle");
                                shape.set(shapeColour, fillMode, x, y, width, height);
                                shape.draw(g);
                                blink = false;
                            }
                            else if (blink_shape == "triangle")
                            {
                                shapeColour = Color.Green;
                                shape = factory.GetShape("triangle");
                                shape.set(shapeColour, fillMode, x, y, point1, point2, point3, point4);
                                shape.draw(g);
                                blink = false;
                            }
                            else if (blink_shape == "drawto")
                            {
                                shapeColour = Color.Green;
                                shape = factory.GetShape("drawto");
                                shape.set(shapeColour, fillMode, x, y, point1, point2);
                                shape.draw(g);
                                blink = false;
                            }
                        }
                        Thread.Sleep(500);
                    }
                    else if (black_white)
                    {
                        if (blink == false)
                        {
                            if (blink_shape == "circle")
                            {
                                shapeColour = Color.Black;
                                shape = factory.GetShape("circle");
                                shape.set(shapeColour, fillMode, x, y, radius);
                                shape.draw(g);
                                blink = true;
                            }
                            else if (blink_shape == "rectangle")
                            {
                                shapeColour = Color.Black;
                                shape = factory.GetShape("rectangle");
                                shape.set(shapeColour, fillMode, x, y, width, height);
                                shape.draw(g);
                                blink = true;
                            }
                            else if (blink_shape == "triangle")
                            {
                                shapeColour = Color.Black;
                                shape = factory.GetShape("triangle");
                                shape.set(shapeColour, fillMode, x, y, point1, point2, point3, point4);
                                shape.draw(g);
                                blink = true;
                            }
                            else if (blink_shape == "drawto")
                            {
                                shapeColour = Color.Black;
                                shape = factory.GetShape("drawto");
                                shape.set(shapeColour, fillMode, x, y, point1, point2);
                                shape.draw(g);
                                blink = true;
                            }
                        }
                        else
                        {
                            if (blink_shape == "circle")
                            {
                                shapeColour = Color.White;
                                shape = factory.GetShape("circle");
                                shape.set(shapeColour, fillMode, x, y, radius);
                                shape.draw(g);
                                blink = false;
                            }
                            else if (blink_shape == "rectangle")
                            {
                                shapeColour = Color.White;
                                shape = factory.GetShape("rectangle");
                                shape.set(shapeColour, fillMode, x, y, width, height);
                                shape.draw(g);
                                blink = false;
                            }
                            else if (blink_shape == "triangle")
                            {
                                shapeColour = Color.White;
                                shape = factory.GetShape("triangle");
                                shape.set(shapeColour, fillMode, x, y, point1, point2, point3, point4);
                                shape.draw(g);
                                blink = false;
                            }
                            else if (blink_shape == "drawto")
                            {
                                shapeColour = Color.White;
                                shape = factory.GetShape("drawto");
                                shape.set(shapeColour, fillMode, x, y, point1, point2);
                                shape.draw(g);
                                blink = false;
                            }
                        }
                        Thread.Sleep(500);
                    }

                }


            }
        }
        /// <summary>
        /// method that checks what kind of command is given by the user and draws the shape
        /// the type of command/value of main_command is assigned by the method passCommandType()
        /// </summary>
        public void runProgram()
        {
            if (main_command.Equals("moveto"))
            {
                Move m = new Move();
                m.moveCursor(x, y);
            }
            else if (main_command.Equals("pen"))
            {
                PenColor pen = new PenColor();
                pen.SetColor(shapeColour);
            }
            else if (main_command.Equals("colour"))
            {
                PenColor pen = new PenColor();
                pen.SetColor(shapeColour);
            }
            else if (main_command.Equals("fill"))
            {
                FillShapes fill = new FillShapes();
                fill.fillColour(fillMode);
            }
            else if (main_command.Equals("drawto"))
            {
                if (change_color)
                {
                    newThread = new Thread(flashColorThread);
                    blink_shape = "drawto";
                    newThread.Start();
                }
                else
                {
                    shape = factory.GetShape("drawto");
                    shape.set(shapeColour, fillMode, x, y, point1, point2);
                    shape.draw(g);
                }
            }

            else if (main_command.Equals("rectangle"))
            {
                if (change_color)
                {
                    newThread2 = new Thread(flashColorThread);
                    blink_shape = "rectangle";
                    newThread2.Start();
                }
                else
                {
                    shape = factory.GetShape("rectangle");
                    shape.set(shapeColour, fillMode, x, y, width, height);
                    shape.draw(g);
                }

            }
            else if (main_command.Equals("circle"))
            {
                if (change_color)
                {
                    newThread3 = new Thread(flashColorThread);
                    blink_shape = "circle";
                    newThread3.Start();
                }
                else
                {
                    shape = factory.GetShape("circle");
                    shape.set(shapeColour, fillMode, x, y, radius);
                    shape.draw(g);
                }

            }
            else if (main_command.Equals("triangle"))
            {
                if (change_color)
                {
                    newThread4 = new Thread(flashColorThread);
                    blink_shape = "triangle";
                    newThread4.Start();
                }
                else
                {
                    shape = factory.GetShape("triangle");
                    shape.set(shapeColour, fillMode, x, y, point1, point2, point3, point4);
                    shape.draw(g);
                }

            }
        }

        /// <summary>
        /// method that passes user command and necessary parameter to the Validation class and gets the validated values passed from the Calidate method of Validation class
        /// </summary>
        public void passCommandType()
        {
            int lineNumber = userInput.Lines.Count();
            int count = 0;
            bool condition_result = false;

            for (int i = 0; i < lineNumber; i++)
            {
                count++;
                command = userInput.Lines[i];
                Validation validateInput = Validation.GetInstance;
                String[] valueArray = validateInput.validate(command, x, y);
                String[] split_lines = userInput.Text.Trim().ToLower().Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
                List<String> stored_commands = split_lines.ToList();

                //if the loop, method or the if block are closed used appropriate command it sets the value of blocked_closed to true
                if (stored_commands.Contains("endif") || stored_commands.Contains("endloop") || stored_commands.Contains("endmethod"))
                {
                    block_closed = true;
                }

                //if ignore_line is true or if block_closed is false then one iteration is skipped by the program
                if (ignore_line || !block_closed)
                {
                    continue;
                }

                //try block to set/add values to variables, dictionaries, lists and invoke runProgram() method according to the user command
                try
                {
                    //if user gives moveto command and there are no errors then it sets the value of main_command to "moveto" and calls the runProgram() method
                    if (valueArray[0].Equals("moveto"))
                    {
                        if (!Regex.IsMatch(valueArray[1], @"^[0-9]+$"))
                        {
                            if (variable_dict.ContainsKey(valueArray[1]))
                            {
                                variable_dict.TryGetValue(valueArray[1], out x);

                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }
                        }
                        else
                        {
                            x = int.Parse(valueArray[1]);
                        }
                        if (!Regex.IsMatch(valueArray[2], @"^[0-9]+$"))
                        {
                            if (variable_dict.ContainsKey(valueArray[1]))
                            {
                                variable_dict.TryGetValue(valueArray[2], out y);

                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }                       
                        }
                        else
                        {
                            y = int.Parse(valueArray[2]);
                        }

                        main_command = "moveto";
                        runProgram();
                    }
                    //if user gives pen command and there are no errors then it sets the value of main_command to "pen" and calls the runProgram() method
                    else if (valueArray[0].Equals("pen"))
                    {
                        try
                        {
                            if (Regex.IsMatch(valueArray[1], @"^[0-9]+$"))
                            {
                                throw new Exception("Pen takes string parameters." + " Line No: " + lineNumber);
                            }
                            else
                            {
                                if (valueArray[1].Equals("red"))
                                {
                                    shapeColour = Color.Red;
                                }
                                else if (valueArray[1].Equals("blue"))
                                {
                                    shapeColour = Color.Blue;

                                }
                                else if (valueArray[1].Equals("green"))
                                {
                                    shapeColour = Color.GreenYellow;

                                }
                                else if (valueArray[1].Equals("black"))
                                {
                                    shapeColour = Color.Black;

                                }
                                else
                                {
                                    errorBox.Text = "Colour not available. Please enter either red, blue, green or black | line no." + lineNumber;
                                }
                                main_command = "pen";
                                runProgram();
                            }
                        }
                        catch(Exception e)
                        {
                            errorBox.Text = e.Message;
                        }
                        
                    }
                    //if user gives pen command and there are no errors then it sets the value of main_command to "pen" and calls the runProgram() method
                    else if (valueArray[0].Equals("colour"))
                    {
                        try
                        {
                            if (Regex.IsMatch(valueArray[1], @"^[0-9]+$"))
                            {
                                throw new Exception("Colour takes string parameters." + " Line No: " + lineNumber);
                            }
                            else
                            {
                                if (valueArray[1].Equals("blueyellow") || valueArray[1].Equals("redgreen") || valueArray[1].Equals("blackwhite"))
                                {
                                    change_color = true;

                                    if (valueArray[1].Equals("blueyellow"))
                                    {
                                        blue_yellow = true;
                                    }
                                    else if (valueArray[1].Equals("redgreen"))
                                    {
                                        red_green = true;
                                    }
                                    else if (valueArray[1].Equals("blackwhite"))
                                    {
                                        black_white = true;
                                    }
                                }
                                else
                                {
                                    errorBox.Text = "Colour not available. Please enter either red, blue, green, black, blueyellow, redgreen or blackwhite | line no." + lineNumber;
                                }
                                main_command = "colour";
                                runProgram();
                            }
                        }
                        catch (Exception e)
                        {
                            errorBox.Text = e.Message;
                        }

                    }
                    //if user gives fill command and there are no errors then it sets the value of main_command to "fill" and calls the runProgram() method
                    else if (valueArray[0].Equals("fill"))
                    {
                        try
                        {
                            if(Regex.IsMatch(valueArray[1], @"^[0-9]+$"))
                            {
                                throw new Exception("Fill takes string parameter" + " || Line No: " + lineNumber);
                            }
                            else
                            {
                                if (valueArray[1].Equals("on"))
                                {
                                    fillMode = true;

                                }
                                else if (valueArray[1].Equals("off"))
                                {
                                    fillMode = false;

                                }
                                else
                                {
                                    errorBox.Text = "Wrong command for fill. Please enter either \"on\" or \"off\" | line no." + lineNumber;
                                }
                                main_command = "fill";
                                runProgram();
                            }
                        }
                        catch(Exception e)
                        {
                            errorBox.Text = e.Message;
                        }
                        
                    }

                    //if user gives drawto command and there are no errors then it sets the value of main_command to "drawto" and calls the runProgram() method
                    else if (valueArray[0].Equals("drawto"))
                    {

                        if (!Regex.IsMatch(valueArray[1], @"^[0-9]+$"))
                        {
                            if (variable_dict.ContainsKey(valueArray[1]))
                            {
                                variable_dict.TryGetValue(valueArray[1], out point1);

                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }
                        }
                        else
                        {
                            point1 = int.Parse(valueArray[1]);
                        }
                        if (!Regex.IsMatch(valueArray[2], @"^[0-9]+$"))
                        {
                            if (variable_dict.ContainsKey(valueArray[2]))
                            {
                                variable_dict.TryGetValue(valueArray[2], out point2);
                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }

                        }
                        else
                        {
                            point2 = int.Parse(valueArray[2]);
                        }
                        main_command = "drawto";
                        runProgram();
                    }

                    //if user gives command to draw rectangle and there are no errors then it sets the value of main_command to "rectangle" and calls the runProgram() method
                    else if (valueArray[0].Equals("rectangle"))
                    {
                        if (!Regex.IsMatch(valueArray[1], @"^[0-9]+$"))
                        {
                            if (variable_dict.ContainsKey(valueArray[1]))
                            {
                                variable_dict.TryGetValue(valueArray[1], out width);
                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }
                        }
                        else
                        {
                            width = int.Parse(valueArray[1]);
                        }
                        if (!Regex.IsMatch(valueArray[2], @"^[0-9]+$"))
                        {
                            if (variable_dict.ContainsKey(valueArray[2]))
                            {
                                variable_dict.TryGetValue(valueArray[2], out height);
                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }
                        }
                        else
                        {
                            height = int.Parse(valueArray[2]);
                        }
                        main_command = "rectangle";
                        runProgram();

                    }

                    //if user gives command to draw circle and there are no errors then it sets the value of main_command to "circle" and calls the runProgram() method
                    else if (valueArray[0].Equals("circle"))
                    {
                        if (!Regex.IsMatch(valueArray[1], @"^[0-9]+$"))
                        {
                            if (variable_dict.ContainsKey(valueArray[1]))
                            {
                                variable_dict.TryGetValue(valueArray[1], out radius);
                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }
                        }
                        else
                        {
                            radius = int.Parse(valueArray[1]);
                        }
                        main_command = "circle";
                        runProgram();

                    }

                    //if user gives command to draw triangle and there are no errors then it sets the value of main_command to "triangle" and calls the runProgram() method
                    else if (valueArray[0].Equals("triangle"))
                    {
                        if (!Regex.IsMatch(valueArray[1], @"^[0-9]+$"))
                        {
                            if (variable_dict.ContainsKey(valueArray[1]))
                            {
                                variable_dict.TryGetValue(valueArray[1], out point1);
                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }
                        }
                        else
                        {
                            point1 = int.Parse(valueArray[1]);
                        }
                        if (!Regex.IsMatch(valueArray[2], @"^[0-9]+$"))
                        {
                            if (variable_dict.ContainsKey(valueArray[2]))
                            {
                                variable_dict.TryGetValue(valueArray[2], out point2);
                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }
                        }
                        else
                        {
                            point2 = int.Parse(valueArray[2]);
                        }

                        if (!Regex.IsMatch(valueArray[3], @"^[0-9]+$"))
                        {
                            if (variable_dict.ContainsKey(valueArray[3]))
                            {
                                variable_dict.TryGetValue(valueArray[3], out point3);
                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }
                        }
                        else
                        {
                            point3 = int.Parse(valueArray[3]);
                        }
                        if (!Regex.IsMatch(valueArray[4], @"^[0-9]+$")) { 
                            if (variable_dict.ContainsKey(valueArray[4]))
                            {
                                variable_dict.TryGetValue(valueArray[4], out point4);
                            }
                            else
                            {
                                errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                            }
                        }
                        else
                        {
                            point4 = int.Parse(valueArray[4]);
                        }
                        main_command = "triangle";
                        runProgram();

                    }
                    //if the user gives command to assign value to a variable then the codes inside this block are executed
                    else if (valueArray[0].Equals("assignValue"))
                    {
                        string variable = valueArray[1];
                        int value = int.Parse(valueArray[2]);

                        //if variable is not already present in dictionary variable_dict, both the variable and the value it's assigned are stored in variable_dict
                        if (!variable_dict.ContainsKey(variable))
                        {
                            variable_dict.Add(variable, value);
                        }
                        //if the variable already exists then it's old value is replaced by the newly assigned value
                        else
                        {
                            variable_dict[variable] = value;
                        }
                    }
                    //condition to check if the user has given command to do certain operation on a variable
                    else if (valueArray[0].Equals("variable_operation"))
                    {
                        string variable_to_operate_on = valueArray[1];
                        string operation = valueArray[2];
                        string sign = "";

                        if (operation.Contains("+"))
                        {
                            sign = "+";

                            string[] operation_array = operation.Split(new string[] { sign }, StringSplitOptions.RemoveEmptyEntries);
                            string operation_value1 = operation_array[0];
                            string operation_value2 = operation_array[1];

                            if (!Regex.IsMatch(operation_value1, @"^[0-9]+$") && !Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                            {
                                if (variable_dict.ContainsKey(operation_value1) && variable_dict.ContainsKey(variable_to_operate_on) && variable_dict.ContainsKey(operation_value2))
                                {
                                    int final_value = variable_dict[operation_value1] + variable_dict[operation_value2];
                                    variable_dict[variable_to_operate_on] = final_value;
                                }
                                else
                                {
                                    errorBox.Text = "Variables not declared"+ " | Line No: "+lineNumber;
                                }
                            }
                            else if (Regex.IsMatch(operation_value1, @"^[0-9]+$") && !Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                            {
                                if (variable_dict.ContainsKey(variable_to_operate_on) && variable_dict.ContainsKey(operation_value2))
                                {
                                    int final_value = int.Parse(operation_value1) + variable_dict[operation_value2];
                                    variable_dict[variable_to_operate_on] = final_value;
                                }
                                else
                                {
                                    errorBox.Text = "Variable "+operation_value2+" not declared" + " | Line No: " + lineNumber;
                                }
                            }
                            else if (!Regex.IsMatch(operation_value1, @"^[0-9]+$") && Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                            {
                                if (variable_dict.ContainsKey(operation_value1) && variable_dict.ContainsKey(variable_to_operate_on))
                                {
                                    int final_value = variable_dict[operation_value1] + int.Parse(operation_value2);
                                    variable_dict[variable_to_operate_on] = final_value;
                                }
                                else
                                {
                                    errorBox.Text = "Variable "+operation_value1+" not declared" + " | Line No: " + lineNumber;
                                }
                            }
                            else if (Regex.IsMatch(operation_value1, @"^[0-9]+$") && Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                            {
                                if (variable_dict.ContainsKey(variable_to_operate_on))
                                {
                                    int final_value = int.Parse(operation_value1) + int.Parse(operation_value2);
                                    variable_dict[variable_to_operate_on] = final_value;
                                }
                                else
                                {
                                    errorBox.Text = "Variable "+ variable_to_operate_on+" not declared" + " | Line No: " + lineNumber;
                                }
                            }
                        }
                        else
                        {
                            errorBox.Text = "This operation is not supported. Please use + sign" + " | Line No: " + lineNumber;
                        }

                    }
                    else if (valueArray[0].Equals("singleif"))
                    {

                        string single_if_condition = valueArray[1];
                        string single_line_command = valueArray[2];
                        string condition_Operator = "";

                        if (single_if_condition.Contains("==") && !single_if_condition.Contains("!<>"))
                        {
                            condition_Operator = "==";
                        }
                        else if (single_if_condition.Contains("<=") && !single_if_condition.Contains("!>"))
                        {
                            condition_Operator = "<=";
                        }
                        else if (single_if_condition.Contains(">=") && !single_if_condition.Contains("!<"))
                        {
                            condition_Operator = ">=";
                        }
                        else if (single_if_condition.Contains("!=") && !single_if_condition.Contains("<>"))
                        {
                            condition_Operator = "!=";
                        }
                        else if (single_if_condition.Contains("<") && !single_if_condition.Contains("!=>"))
                        {
                            condition_Operator = "<";
                        }
                        else if (single_if_condition.Contains(">") && !single_if_condition.Contains("!=<"))
                        {
                            condition_Operator = ">";
                        }

                        //splits the condition given by user using condition_Operator as delimiter
                        string[] singleConditionArray = single_if_condition.Split(new string[] { condition_Operator }, StringSplitOptions.RemoveEmptyEntries);
                        //stores the variable
                        string singleConditionVariable = singleConditionArray[0];
                        //stores the value of the variable
                        string singleConditionValue = singleConditionArray[1];

                        //checking to see if the dicitionary contains the variable given by user in the condition
                        if (variable_dict.ContainsKey(singleConditionVariable))
                        {
                            int check_stored_value = 0;
                            variable_dict.TryGetValue(singleConditionVariable, out check_stored_value);
                            //int index = inputVariable.IndexOf(conditionVariable);
                            if (condition_Operator.Equals("=="))
                            {
                                if (int.Parse(singleConditionValue) == check_stored_value)
                                {
                                    condition_result = true;
                                }
                                else
                                {
                                    ignore_line = true;
                                }
                            }
                            else if (condition_Operator.Equals("<="))
                            {
                                if (check_stored_value <= int.Parse(singleConditionValue))
                                {
                                    condition_result = true;

                                }
                                else
                                {
                                    ignore_line = true;
                                }

                            }
                            else if (condition_Operator.Equals(">="))
                            {
                                if (check_stored_value >= int.Parse(singleConditionValue))
                                {
                                    condition_result = true;

                                }
                                else
                                {
                                    ignore_line = true;
                                }

                            }
                            else if (condition_Operator.Equals("!="))
                            {
                                if (check_stored_value != int.Parse(singleConditionValue))
                                {
                                    condition_result = true;

                                }
                                else
                                {
                                    ignore_line = true;
                                }

                            }
                            else if (condition_Operator.Equals("<"))
                            {
                                if (check_stored_value < int.Parse(singleConditionValue))
                                {
                                    condition_result = true;

                                }
                                else
                                {
                                    ignore_line = true;
                                }

                            }
                            else if (condition_Operator.Equals(">"))
                            {
                                if (check_stored_value > int.Parse(singleConditionValue))
                                {
                                    condition_result = true;

                                }
                                else
                                {
                                    ignore_line = true;
                                }

                            }
                        }
                        else
                        {
                            errorBox.Text = "Variable not found | Line Number: " + lineNumber;
                        }
                        if (condition_result)
                        {
                            Validation validate_single_command = Validation.GetInstance;
                            String[] split_single_command = validate_single_command.validate(single_line_command, x, y);

                            try
                            {
                                if (split_single_command[0].Equals("moveto"))
                                {
                                    if (!Regex.IsMatch(split_single_command[1], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[1]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[1], out x);

                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }
                                    }
                                    else
                                    {
                                        x = int.Parse(split_single_command[1]);
                                    }
                                    if (!Regex.IsMatch(split_single_command[2], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[1]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[2], out y);

                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }
                                    }
                                    else
                                    {
                                        y = int.Parse(split_single_command[2]);
                                    }

                                    main_command = "moveto";
                                    runProgram();
                                }

                                else if (split_single_command[0].Equals("pen"))
                                {
                                    try
                                    {
                                        if (Regex.IsMatch(split_single_command[1], @"^[0-9]+$"))
                                        {
                                            throw new Exception("Pen takes string parameters." + " Line No: " + lineNumber);
                                        }
                                        else
                                        {
                                            if (split_single_command[1].Equals("red"))
                                            {
                                                shapeColour = Color.Red;
                                            }
                                            else if (split_single_command[1].Equals("blue"))
                                            {
                                                shapeColour = Color.Blue;

                                            }
                                            else if (split_single_command[1].Equals("green"))
                                            {
                                                shapeColour = Color.GreenYellow;

                                            }
                                            else if (split_single_command[1].Equals("black"))
                                            {
                                                shapeColour = Color.Black;

                                            }
                                            else if (split_single_command[1].Equals("blueyellow") || split_single_command[1].Equals("redgreen") || split_single_command[1].Equals("blackwhite"))
                                            {
                                                change_color = true;

                                                if (split_single_command[1].Equals("blueyellow"))
                                                {
                                                    blue_yellow = true;
                                                }
                                                else if (split_single_command[1].Equals("redgreen"))
                                                {
                                                    red_green = true;
                                                }
                                                else if (split_single_command[1].Equals("blackwhite"))
                                                {
                                                    black_white = true;
                                                }
                                            }
                                            else
                                            {
                                                errorBox.Text = "Colour not available. Please enter either red, blue, green, black, blueyellow, redgreen or blackwhite | line no." + lineNumber;
                                            }
                                            main_command = "pen";
                                            runProgram();
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        errorBox.Text = e.Message;
                                    }

                                }
                                //if user gives fill command and there are no errors then it sets the value of main_command to "fill" and calls the runProgram() method
                                else if (split_single_command[0].Equals("fill"))
                                {
                                    try
                                    {
                                        if (Regex.IsMatch(split_single_command[1], @"^[0-9]+$"))
                                        {
                                            throw new Exception("Fill takes string parameter" + " || Line No: " + lineNumber);
                                        }
                                        else
                                        {
                                            if (split_single_command[1].Equals("on"))
                                            {
                                                fillMode = true;

                                            }
                                            else if (split_single_command[1].Equals("off"))
                                            {
                                                fillMode = false;

                                            }
                                            else
                                            {
                                                errorBox.Text = "Wrong command for fill. Please enter either \"on\" or \"off\" | line no." + lineNumber;
                                            }
                                            main_command = "fill";
                                            runProgram();
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        errorBox.Text = e.Message;
                                    }

                                }
                                else if (split_single_command[0].Equals("drawto"))
                                {

                                    if (!Regex.IsMatch(split_single_command[1], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[1]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[1], out point1);

                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }
                                    }
                                    else
                                    {
                                        point1 = int.Parse(split_single_command[1]);
                                    }
                                    if (!Regex.IsMatch(split_single_command[2], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[2]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[2], out point2);
                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }

                                    }
                                    else
                                    {
                                        point2 = int.Parse(split_single_command[2]);
                                    }
                                    main_command = "drawto";
                                    runProgram();
                                }

                                else if (split_single_command[0].Equals("rectangle"))
                                {
                                    if (!Regex.IsMatch(split_single_command[1], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[1]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[1], out width);
                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }
                                    }
                                    else
                                    {
                                        width = int.Parse(split_single_command[1]);
                                    }
                                    if (!Regex.IsMatch(split_single_command[2], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[2]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[2], out height);
                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }
                                    }
                                    else
                                    {
                                        height = int.Parse(split_single_command[2]);
                                    }
                                    main_command = "rectangle";
                                    runProgram();

                                }
                                else if (split_single_command[0].Equals("circle"))
                                {
                                    if (!Regex.IsMatch(split_single_command[1], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[1]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[1], out radius);
                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }
                                    }
                                    else
                                    {
                                        radius = int.Parse(split_single_command[1]);
                                    }
                                    main_command = "circle";
                                    runProgram();

                                }
                                else if (split_single_command[0].Equals("triangle"))
                                {
                                    if (!Regex.IsMatch(split_single_command[1], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[1]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[1], out point1);
                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }
                                    }
                                    else
                                    {
                                        point1 = int.Parse(split_single_command[1]);
                                    }
                                    if (!Regex.IsMatch(split_single_command[2], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[2]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[2], out point2);
                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }
                                    }
                                    else
                                    {
                                        point2 = int.Parse(split_single_command[2]);
                                    }

                                    if (!Regex.IsMatch(split_single_command[3], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[3]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[3], out point3);
                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }
                                    }
                                    else
                                    {
                                        point3 = int.Parse(split_single_command[3]);
                                    }
                                    if (!Regex.IsMatch(split_single_command[4], @"^[0-9]+$"))
                                    {
                                        if (variable_dict.ContainsKey(split_single_command[4]))
                                        {
                                            variable_dict.TryGetValue(split_single_command[4], out point4);
                                        }
                                        else
                                        {
                                            errorBox.Text = "Variable not assigned value | Line No: " + lineNumber;
                                        }
                                    }
                                    else
                                    {
                                        point4 = int.Parse(split_single_command[4]);
                                    }
                                    main_command = "triangle";
                                    runProgram();

                                }
                                else if (split_single_command[0].Equals("assignValue"))
                                {
                                    string variable = split_single_command[1];
                                    int value = int.Parse(split_single_command[2]);
                                    if (!variable_dict.ContainsKey(variable))
                                    {
                                        variable_dict.Add(variable, value);
                                    }
                                    else
                                    {
                                        variable_dict[variable] = value;
                                    }
                                }
                                else if (split_single_command[0].Equals("variable_operation"))
                                {
                                    string variable_to_operate_on = split_single_command[1];
                                    string operation = split_single_command[2];
                                    string sign = "";

                                    if (operation.Contains("+"))
                                    {
                                        sign = "+";

                                        string[] operation_array = operation.Split(new string[] { sign }, StringSplitOptions.RemoveEmptyEntries);
                                        string operation_value1 = operation_array[0];
                                        string operation_value2 = operation_array[1];

                                        if (!Regex.IsMatch(operation_value1, @"^[0-9]+$") && !Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(operation_value1) && variable_dict.ContainsKey(variable_to_operate_on) && variable_dict.ContainsKey(operation_value2))
                                            {
                                                int final_value = variable_dict[operation_value1] + variable_dict[operation_value2];
                                                variable_dict[variable_to_operate_on] = final_value;
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variables not declared";
                                            }
                                        }
                                        else if (Regex.IsMatch(operation_value1, @"^[0-9]+$") && !Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(variable_to_operate_on) && variable_dict.ContainsKey(operation_value2))
                                            {
                                                int final_value = int.Parse(operation_value1) + variable_dict[operation_value2];
                                                variable_dict[variable_to_operate_on] = final_value;
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variable "+ operation_value2 + "not declared";
                                            }
                                        }
                                        else if (!Regex.IsMatch(operation_value1, @"^[0-9]+$") && Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(operation_value1) && variable_dict.ContainsKey(variable_to_operate_on))
                                            {
                                                int final_value = variable_dict[operation_value1] + int.Parse(operation_value2);
                                                variable_dict[variable_to_operate_on] = final_value;
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variables not declared";
                                            }
                                        }
                                        else if (Regex.IsMatch(operation_value1, @"^[0-9]+$") && Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(variable_to_operate_on))
                                            {
                                                int final_value = int.Parse(operation_value1) + int.Parse(operation_value2);
                                                variable_dict[variable_to_operate_on] = final_value;
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variables not declared";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        errorBox.Text = "This operation is not supported. Please use + sign";
                                    }
                                }

                                else if (split_single_command[0].Equals("error"))
                                {
                                    errorBox.Text = "Invalid Command | Line no." + lineNumber;
                                }
                            }
                            catch (FormatException e)
                            {
                                errorBox.Text = e.Message + " Please enter parameter of right data type";
                            }
                            catch (IndexOutOfRangeException e)
                            {
                                errorBox.Text = "Wrong number of parameters";
                            }
                        }

                    }
                    //if user gives block if command this block runs
                    else if (valueArray[0].Equals("if"))
                    {
                        bool if_closed = false;

                        for (int x = count; x < lineNumber; x++)
                        {
                            if (stored_commands[x].Equals("endif"))
                            {
                                if_closed = true;
                            }
                        }
                        //if the if block is closed i.e. if endif keyword is used at the end of the block
                        if (if_closed)
                        {
                            string if_condition = valueArray[1];
                            string condition_Operator = "";

                            if (if_condition.Contains("==") && !if_condition.Contains("!<>"))
                            {
                                condition_Operator = "==";
                            }
                            else if (if_condition.Contains("<=") && !if_condition.Contains("!>"))
                            {
                                condition_Operator = "<=";
                            }
                            else if (if_condition.Contains(">=") && !if_condition.Contains("!<"))
                            {
                                condition_Operator = ">=";
                            }
                            else if (if_condition.Contains("!=") && !if_condition.Contains("<>"))
                            {
                                condition_Operator = "!=";
                            }
                            else if (if_condition.Contains("<") && !if_condition.Contains("!=>"))
                            {
                                condition_Operator = "<";
                            }
                            else if (if_condition.Contains(">") && !if_condition.Contains("!=<"))
                            {
                                condition_Operator = ">";
                            }
                            else
                            {
                                errorBox.Text = "Wrong operation combinations. Line number: " + lineNumber;
                            }

                            //splits the condition given by user using condition_Operator as delimiter
                            string[] conditionArray = if_condition.Split(new string[] { condition_Operator }, StringSplitOptions.RemoveEmptyEntries);
                            //stores the variable
                            string conditionVariable = conditionArray[0];
                            //stores the value of the variable
                            string conditionValue = conditionArray[1];

                            //checking to see if the dicitionary contains the variable given by user in the condition
                            if (variable_dict.ContainsKey(conditionVariable))
                            {
                                int check_stored_value = 0;
                                variable_dict.TryGetValue(conditionVariable, out check_stored_value);
                                //int index = inputVariable.IndexOf(conditionVariable);
                                if (condition_Operator.Equals("=="))
                                {
                                    if (int.Parse(conditionValue) == check_stored_value)
                                    {
                                        condition_result = true;
                                    }
                                    else
                                    {
                                        ignore_line = true;
                                    }
                                }
                                else if (condition_Operator.Equals("<="))
                                {
                                    if (check_stored_value <= int.Parse(conditionValue))
                                    {
                                        condition_result = true;

                                    }
                                    else
                                    {
                                        ignore_line = true;
                                    }

                                }
                                else if (condition_Operator.Equals(">="))
                                {
                                    if (check_stored_value >= int.Parse(conditionValue))
                                    {
                                        condition_result = true;

                                    }
                                    else
                                    {
                                        ignore_line = true;
                                    }

                                }
                                else if (condition_Operator.Equals("!="))
                                {
                                    if (check_stored_value != int.Parse(conditionValue))
                                    {
                                        condition_result = true;

                                    }
                                    else
                                    {
                                        ignore_line = true;
                                    }

                                }
                                else if (condition_Operator.Equals("<"))
                                {
                                    if (check_stored_value < int.Parse(conditionValue))
                                    {
                                        condition_result = true;

                                    }
                                    else
                                    {
                                        ignore_line = true;
                                    }

                                }
                                else if (condition_Operator.Equals(">"))
                                {
                                    if (check_stored_value > int.Parse(conditionValue))
                                    {
                                        condition_result = true;

                                    }
                                    else
                                    {
                                        ignore_line = true;
                                    }

                                }
                            }
                            else
                            {
                                errorBox.Text = "Variable " + conditionVariable +" not found";
                                ignore_line = true;
                            }
                        }
                        else if (if_closed == false)
                        {
                            errorBox.Text = "If not closed";
                            ignore_line = true;
                        }
                    }
                    //if user gives loop command
                    else if (valueArray[0].Equals("loop"))
                    {
                        //stores the number of times the program needs to loop
                        int no_of_loops = int.Parse(valueArray[1]);
                        int loop_count = 0;
                        bool loop_closed = false;
                        List<string> loopCommands = new List<string>();

                        //checking if loop block has been closed
                        for (int x = count; x < lineNumber; x++)
                        {
                            if (stored_commands[x].Equals("endloop"))
                            {
                                loop_closed = true;
                            }
                        }
                        //if loop block is closed
                        if (loop_closed)
                        {
                            for (int x = count; x < lineNumber; x++)
                            {
                                if (!stored_commands[x].Equals("endloop"))
                                {
                                    loopCommands.Add(stored_commands[x]);
                                }
                            }
                            int total_loop_lines = loopCommands.Count();
                            int loop_stored_command_index = 0;

                            //looping through the commands inside loop block
                            for (int loop_index = 0; loop_index < ((no_of_loops * total_loop_lines) - 1); loop_index++)
                            {
                                new_loop_command = loopCommands[loop_stored_command_index];
                                Validation loop_validate_input = Validation.GetInstance;
                                String[] loop_value_array = loop_validate_input.validate(new_loop_command, x, y);

                                if (loop_stored_command_index >= total_loop_lines - 1)
                                {
                                    loop_stored_command_index = 0;
                                }

                                else if (loop_stored_command_index <= total_loop_lines - 1)
                                {
                                    loop_stored_command_index++;
                                }

                                try
                                {
                                    if (loop_value_array[0].Equals("pen"))
                                    {
                                        try
                                        {
                                            if (Regex.IsMatch(loop_value_array[1], @"^[0-9]+$"))
                                            {
                                                throw new Exception("Pen takes string parameters." + " Line No: " + lineNumber);
                                            }
                                            else
                                            {
                                                if (loop_value_array[1].Equals("red"))
                                                {
                                                    shapeColour = Color.Red;
                                                }
                                                else if (loop_value_array[1].Equals("blue"))
                                                {
                                                    shapeColour = Color.Blue;

                                                }
                                                else if (loop_value_array[1].Equals("green"))
                                                {
                                                    shapeColour = Color.GreenYellow;

                                                }
                                                else if (loop_value_array[1].Equals("black"))
                                                {
                                                    shapeColour = Color.Black;

                                                }
                                                else if (loop_value_array[1].Equals("blueyellow") || loop_value_array[1].Equals("redgreen") || loop_value_array[1].Equals("blackwhite"))
                                                {
                                                    change_color = true;

                                                    if (loop_value_array[1].Equals("blueyellow"))
                                                    {
                                                        blue_yellow = true;
                                                    }
                                                    else if (loop_value_array[1].Equals("redgreen"))
                                                    {
                                                        red_green = true;
                                                    }
                                                    else if (loop_value_array[1].Equals("blackwhite"))
                                                    {
                                                        black_white = true;
                                                    }
                                                }
                                                else
                                                {
                                                    errorBox.Text = "Colour not available. Please enter either red, blue, green, black, blueyellow, redgreen or blackwhite | line no." + lineNumber;
                                                }
                                                main_command = "pen";
                                                runProgram();
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            errorBox.Text = e.Message;
                                        }

                                    }
                                    else if (loop_value_array[0].Equals("fill"))
                                    {
                                        try
                                        {
                                            if (Regex.IsMatch(loop_value_array[1], @"^[0-9]+$"))
                                            {
                                                throw new Exception("Fill takes string parameter" + " || Line No: " + lineNumber);
                                            }
                                            else
                                            {
                                                if (loop_value_array[1].Equals("on"))
                                                {
                                                    fillMode = true;

                                                }
                                                else if (loop_value_array[1].Equals("off"))
                                                {
                                                    fillMode = false;

                                                }
                                                else
                                                {
                                                    errorBox.Text = "Wrong command for fill. Please enter either \"on\" or \"off\" | line no." + lineNumber;
                                                }
                                                main_command = "fill";
                                                runProgram();
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            errorBox.Text = e.Message;
                                        }

                                    }
                                    if (loop_value_array[0].Equals("drawto"))
                                    {

                                        if (!Regex.IsMatch(loop_value_array[1], @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(loop_value_array[1]))
                                            {
                                                variable_dict.TryGetValue(loop_value_array[1], out point1);

                                            }
                                            else
                                            {
                                                errorBox.Text = "Variable not assigned value";
                                            }
                                        }
                                        else
                                        {
                                            point1 = int.Parse(loop_value_array[1]);
                                        }
                                        if (!Regex.IsMatch(loop_value_array[2], @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(loop_value_array[2]))
                                            {
                                                variable_dict.TryGetValue(loop_value_array[2], out point2);
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variable not assigned value";
                                            }

                                        }
                                        else
                                        {
                                            point2 = int.Parse(loop_value_array[2]);
                                        }
                                        main_command = "drawto";
                                        runProgram();
                                    }

                                    else if (loop_value_array[0].Equals("rectangle"))
                                    {
                                        if (!Regex.IsMatch(loop_value_array[1], @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(loop_value_array[1]))
                                            {
                                                variable_dict.TryGetValue(loop_value_array[1], out width);
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variable not assigned value ";
                                            }
                                        }
                                        else
                                        {
                                            width = int.Parse(loop_value_array[1]);
                                        }
                                        if (!Regex.IsMatch(loop_value_array[2], @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(loop_value_array[2]))
                                            {
                                                variable_dict.TryGetValue(loop_value_array[2], out height);
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variable not assigned value";
                                            }
                                        }
                                        else
                                        {
                                            height = int.Parse(loop_value_array[2]);
                                        }
                                        main_command = "rectangle";
                                        runProgram();

                                    }
                                    else if (loop_value_array[0].Equals("circle"))
                                    {
                                        if (!Regex.IsMatch(loop_value_array[1], @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(loop_value_array[1]))
                                            {
                                                variable_dict.TryGetValue(loop_value_array[1], out radius);
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variable not assigned value";
                                            }
                                        }
                                        else
                                        {
                                            radius = int.Parse(loop_value_array[1]);
                                        }
                                        main_command = "circle";
                                        runProgram();

                                    }
                                    else if (loop_value_array[0].Equals("triangle"))
                                    {
                                        if (!Regex.IsMatch(loop_value_array[1], @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(loop_value_array[1]))
                                            {
                                                variable_dict.TryGetValue(loop_value_array[1], out point1);
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variable not assigned value";
                                            }
                                        }
                                        else
                                        {
                                            point1 = int.Parse(loop_value_array[1]);
                                        }
                                        if (!Regex.IsMatch(loop_value_array[2], @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(loop_value_array[2]))
                                            {
                                                variable_dict.TryGetValue(loop_value_array[2], out point2);
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variable not assigned value";
                                            }
                                        }
                                        else
                                        {
                                            point2 = int.Parse(loop_value_array[2]);
                                        }

                                        if (!Regex.IsMatch(loop_value_array[3], @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(loop_value_array[3]))
                                            {
                                                variable_dict.TryGetValue(loop_value_array[3], out point3);
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variable not assigned value";
                                            }
                                        }
                                        else
                                        {
                                            point3 = int.Parse(loop_value_array[3]);
                                        }
                                        if (!Regex.IsMatch(loop_value_array[4], @"^[0-9]+$"))
                                        {
                                            if (variable_dict.ContainsKey(loop_value_array[4]))
                                            {
                                                variable_dict.TryGetValue(loop_value_array[4], out point4);
                                            }
                                            else
                                            {
                                                errorBox.Text = "Variable not assigned value";
                                            }
                                        }
                                        else
                                        {
                                            point4 = int.Parse(loop_value_array[4]);
                                        }
                                        main_command = "triangle";
                                        runProgram();


                                    }
                                    else if (loop_value_array[0].Equals("assignValue"))
                                    {
                                        string variable = loop_value_array[1];
                                        int value = int.Parse(loop_value_array[2]);
                                        if (!variable_dict.ContainsKey(variable))
                                        {
                                            variable_dict.Add(variable, value);
                                        }
                                        else
                                        {
                                            variable_dict[variable] = value;
                                        }
                                    }
                                    else if (loop_value_array[0].Equals("variable_operation"))
                                    {
                                        string variable_to_operate_on = loop_value_array[1];
                                        string operation = loop_value_array[2];
                                        string sign = "";

                                        if (operation.Contains("+"))
                                        {
                                            sign = "+";

                                            string[] operation_array = operation.Split(new string[] { sign }, StringSplitOptions.RemoveEmptyEntries);
                                            string operation_value1 = operation_array[0];
                                            string operation_value2 = operation_array[1];

                                            if (!Regex.IsMatch(operation_value1, @"^[0-9]+$") && !Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                                            {
                                                if (variable_dict.ContainsKey(operation_value1) && variable_dict.ContainsKey(variable_to_operate_on) && variable_dict.ContainsKey(operation_value2))
                                                {
                                                    int final_value = variable_dict[operation_value1] + variable_dict[operation_value2];
                                                    variable_dict[variable_to_operate_on] = final_value;
                                                }
                                                else
                                                {
                                                    errorBox.Text = "Variables not assigned value";
                                                }
                                            }
                                            else if (Regex.IsMatch(operation_value1, @"^[0-9]+$") && !Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                                            {
                                                if (variable_dict.ContainsKey(variable_to_operate_on) && variable_dict.ContainsKey(operation_value2))
                                                {
                                                    int final_value = int.Parse(operation_value1) + variable_dict[operation_value2];
                                                    variable_dict[variable_to_operate_on] = final_value;
                                                }
                                                else
                                                {
                                                    errorBox.Text = "Variable " + operation_value2 + " not assigned a value";
                                                }
                                            }
                                            else if (!Regex.IsMatch(operation_value1, @"^[0-9]+$") && Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                                            {
                                                if (variable_dict.ContainsKey(operation_value1) && variable_dict.ContainsKey(variable_to_operate_on))
                                                {
                                                    int final_value = variable_dict[operation_value1] + int.Parse(operation_value2);
                                                    variable_dict[variable_to_operate_on] = final_value;
                                                }
                                                else
                                                {
                                                    errorBox.Text = "Variable " + operation_value1 + " not assigned a value";
                                                }
                                            }
                                            else if (Regex.IsMatch(operation_value1, @"^[0-9]+$") && Regex.IsMatch(operation_value2, @"^[0-9]+$"))
                                            {
                                                if (variable_dict.ContainsKey(variable_to_operate_on))
                                                {
                                                    int final_value = int.Parse(operation_value1) + int.Parse(operation_value2);
                                                    variable_dict[variable_to_operate_on] = final_value;
                                                }
                                                else
                                                {
                                                    errorBox.Text = "Variable " + variable_to_operate_on + " assigned a value";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            errorBox.Text = "This operation is not supported. Please use + sign";
                                        }
                                    }
                                    else if (loop_value_array[0].Equals("error"))
                                    {
                                        errorBox.Text = "Invalid Command inside loop";
                                    }
                                }
                                catch (IndexOutOfRangeException e)
                                {
                                    errorBox.Text = "Wrong number of parameters inside loop command";
                                }
                            }
                            ignore_line = true;
                        }
                        //if loop block is not closed error message is shown
                        else if (loop_closed == false)
                        {
                            errorBox.Text = "Loop not closed";
                            ignore_line = true;
                        }
                    }
                    //if user give method without parameter command
                    else if (valueArray[0].Equals("no_parameter_method"))
                    {
                        foreach(string line in stored_commands)
                        {
                            string[] each_word = line.Split(' ');
                            foreach(string word in each_word)
                            {
                                method_all_commands.Add(word);
                            }

                        }
                        //if the method name is correct
                        if (valueArray[1].ToLower().Equals("mymethod()"))
                        {
                            bool method_closed = false;

                            for (int x = count; x < lineNumber; x++)
                            {
                                if (stored_commands[x].Equals("endmethod"))
                                {
                                    method_closed = true;
                                }
                            }
                            if (method_closed)
                            {
                                invokeMethod();

                                if (method_invoked == false)
                                {
                                    ignore_line = true;
                                }

                            }
                            else if (method_closed == false)
                            {
                                errorBox.Text = "Method not closed. Please close it with closing tag: endmethod";
                                ignore_line = true;
                            }

                            void invokeMethod()
                            {
                                foreach(string element in method_all_commands)
                                {
                                    if (element.Equals("mymethod()"))
                                    {
                                        invokation_command.Add(element);
                                    }
                                }
                 
                                if (invokation_command.Count() >= 2)
                                {
                                    method_invoked = true;
                                }
                            }
                        }
                        //shows error if wrong method name is given
                        else
                        {
                            ignore_line = true;
                            errorBox.Text = "Invalid method name. Please use \"mymethod()\" as method name.";
                        }

                    }
                    //if method with parameter command is given
                    else if (valueArray[0].Equals("parameter_method"))
                    {
                        foreach (string line in stored_commands)
                        {
                            string[] each_word = line.Split(' ');
                            foreach (string word in each_word)
                            {
                                method_all_commands.Add(word);
                            }
                        }
                        if (valueArray[1].ToLower().Contains("mymethod"))
                        {
                            bool method_closed = false;

                            for (int x = count; x < lineNumber; x++)
                            {
                                if (stored_commands[x].Equals("endmethod"))
                                {
                                    method_closed = true;
                                }
                            }
                            if (method_closed)
                            {
                                invokeMethod();

                                if (method_invoked == false)
                                {
                                    ignore_line = true;
                                }
                                else
                                {
                                    string method = "";
                                    List<string> method_parameters = new List<string>();

                                    string[] split_all = valueArray[1].Split(new string[] { "(", ")", " " }, StringSplitOptions.RemoveEmptyEntries);
                                    foreach (string element in split_all)
                                    {
                                        if (element == "mymethod")
                                        {
                                            method = element;
                                        }
                                        else if (element != "mymethod")
                                        {
                                            method_parameters.Add(element);
                                        }
                                    }
                                    if (!method_dict.ContainsKey(method))
                                    {
                                        method_dict.Add(method, method_parameters);

                                    }
                                    else
                                    {
                                        ignore_line = true;
                                        errorBox.Text = "Method already exists. Can not duplicate method";
                                    }
                                    List<string> collect_method = new List<string>();
                                    foreach (string item in stored_commands)
                                    {
                                        if (item.Contains("mymethod"))
                                        {
                                            collect_method.Add(item);
                                        }
                                    }
                                    int no_in_collect_method = collect_method.Count();
                                    if(no_in_collect_method >1)
                                    {
                                        List<string> argument = new List<string>();
                                        string[] split_parameter = collect_method[1].Split(new string[] { "(", ")", "," }, StringSplitOptions.RemoveEmptyEntries);
                                        foreach (string para in split_parameter)
                                        {
                                            if (para != "mymethod")
                                            {
                                                argument.Add(para);
                                            }
                                        }
                                        List<string> values = method_dict["mymethod"];

                                        int num_of_parameter = values.Count();
                                        int num_of_arguments = argument.Count();

                                        //if the number of parameters and the argument passed by the user is same then this block runs
                                        if (num_of_arguments == num_of_parameter)
                                        {
                                            for (int index = 0; index < num_of_parameter; index++)
                                            {
                                                string parameter = method_parameters[index];
                                                int value = int.Parse(argument[index]);
                                                if (!variable_dict.ContainsKey(parameter))
                                                {
                                                    variable_dict.Add(parameter, value);
                                                }
                                                else
                                                {
                                                    variable_dict[parameter] = value;
                                                }
                                            }
                                        }
                                        //if number of parameters and it's values passed do not match error message is shown
                                        else
                                        {
                                            ignore_line = true;
                                            errorBox.Text = "Number of arguments do not match number of parameters";
                                        }
                                    }
                                    else
                                    {
                                        ignore_line = true;
                                    }
                                }
                            }
                            else if (method_closed == false)
                            {
                                errorBox.Text = "Method not closed. Please close it with closing tag: endmethod";
                                ignore_line = true;
                            }
                            void invokeMethod()
                            {
                                foreach (string element in method_all_commands)
                                {
                                    if (element.Contains("mymethod"))
                                    {
                                        invokation_command.Add(element);
                                    }
                                }

                                if (invokation_command.Count() >= 2)
                                {
                                    method_invoked = true;
                                }
                            }
                        }
                        else
                        {
                            ignore_line = true;
                            errorBox.Text = "Invalid method name. Please use \"mymethod()\" as method name.";
                        }
                    }
                    //if block closing commands are given the codes below check if the starting command of block commands are present or not and shows error message if starting commands
                    //are not present
                    else if (valueArray[0].Equals("endif") || valueArray[0].Equals("endloop") || valueArray[0].Equals("endmethod"))
                    {
                        List<string> end_list = new List<string>();
                        foreach (string element in stored_commands)
                        {
                            string[] commands = element.Split(' ');

                            foreach(string word in commands)
                            {
                                end_list.Add(word);
                            }
                        }
                        if (valueArray[0].Equals("endif"))
                        {
                            if (end_list.Contains("endif") && !end_list.Contains("if"))
                            {
                                errorBox.Text = "Starting command for if block not present";
                            }
                            else
                            {
                                block_closed = true;
                                ignore_line = false;
                            }
                        }
                        if (valueArray[0].Equals("endloop"))
                        {
                            if (end_list.Contains("endloop") && !end_list.Contains("loop"))
                            {
                                errorBox.Text = "Starting command for loop not present";
                            }
                            else
                            {
                                block_closed = true;
                                ignore_line = false;
                            }
                        }
                        if (valueArray[0].Equals("endmethod"))
                        {
                            string[] split_words = { };
                            List<string> store_words = new List<string>();
                            foreach (string element in end_list)
                            {
                                split_words = element.Split(new string[] { "(", ")", "," }, StringSplitOptions.RemoveEmptyEntries);
                                foreach(string word in split_words)
                                {
                                    store_words.Add(word);
                                }

                            }
                            if (store_words.Contains("endmethod") && !store_words.Contains("mymethod"))
                            {
                                errorBox.Text = "Starting command for method not present";
                            }
                            else
                            {
                                block_closed = true;
                                ignore_line = false;
                            }
                        }
                    }
                    else if (valueArray[0].Equals("method_called"))
                    {
                        bool method_called = true;
                    }
                    //shows error message if command not supported by the program is given by the user
                    else if (valueArray[0].Equals("error"))
                    {
                        errorBox.Text = "Invalid Command | Line no." + lineNumber;
                    }
                }
                //catch blocks to catch errors and give appropriate message
                catch (FormatException e)
                {
                    errorBox.Text = e.Message + " Please enter parameter of right data type | Line no." + lineNumber;
                }
                catch (IndexOutOfRangeException e)
                {
                    errorBox.Text = "Wrong number of parameters | Line no: " + lineNumber;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Clears the output window, error messages, empties necessary variables, methods and dictionaries and aborts the running threads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            outputWindow.Refresh();
            errorBox.Clear();
            change_color = false; blue_yellow = false; red_green = false; black_white = false; blink = false;
            invokation_command.Clear();
            method_invoked = false;
            ignore_line = false;
            fillMode = false;
            block_closed = true;
            shapeColour = Color.Black;
            invokation_command.Clear();
            method_dict.Clear();
            variable_dict.Clear();
            point1 = 0;
            point2 = 0;
            point3 = 0;
            point4 = 0;
            width = 0;
            height = 0;
            radius = 0;
            thread2.Abort();
            if (newThread != null)
            {
                newThread.Abort();
            }
            if (newThread2 != null)
            {
                newThread2.Abort();
            }
            if (newThread3 != null)
            {
                newThread3.Abort();
            }
            if (newThread4 != null)
            {
                newThread4.Abort();
            }
        }

        /// <summary>
        /// when clicked by the user inside help menu it shows message containing guide to draw shape commands including command examples
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawingCommandGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Draw Circle: Give command \"circle\" then pass 1 integer parameter or variable name if value had been assigned to it. \n\r" +
                "Eg: circle 50 \n\r " +
                "or \n\r radius = 50 " +
                "\n\r circle radius"+
                "\n\r \n\rDraw Rectangle: Give command \"rectangle\" then pass 2 integer parameter or variable name if value had been assigned to it. \n\r" +
                "Eg: rectangle 100,50 \n\r " +
                "or \n\r width = 150 \n\r " +
                "height = 50"+
                "\n\r rectangle width,height"+
                "\n\r \n\rDraw Triangle: Give command \"triangle\" then pass 4 integer parameter or variable name if value had been assigned to it. \n\r" +
                "Eg: triangle 100,50,90,20 \n\r " +
                "or \n\r point1 = 150 \n\r " +
                "point2 = 50 \n\r " +
                "point3 = 100 \n\r" +
                "point4 = 20"+
                "\n\r triangle point1,point2,point3,point4"+
                "\n\r \n\rDraw line: Give command \"drawto\" then pass 2 integer parameter or variable name if value had been assigned to it. \n\r" +
                "Eg: drawto 10,250\n\r " +
                "or \n\r point1 = 150 \n\r " +
                "point2 = 50 \n\r " +
                "drawto point1,point2" );
        }

        /// <summary>
        /// when clicked by the user inside help menu it shows message containing guide to run if commands including command examples
        /// has guide to run both single line if command and block if command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ifStatementGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Single Line If Command \n\rCode Eg:\n\rx = 20\n\rif x==20 then circle 50 \n\r\n\rIf Block Command\n\rCode Eg:\n\rx = 200\n\rIf x>=100\n\rrectangle 40,30\n\rcircle radius\n\rendif");
        }
        /// <summary>
        /// when clicked by the user inside help menu it shows message containing guide to run loop commands including command examples
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loopCommandGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Loop Command \n\rCode Eg:\n\rradius = 10\n\rwidth = 40\n\rheight = 20\n\rloop 10\n\rrectangle width,height\n\rcircle radius\n\rwidth = width+20\n\rheight = height+10\n\rradius = radius+10\n\rendloop");

        }
        /// <summary>
        /// when clicked by the user inside help menu it shows message containing guide to run method commands including command examples
        /// has guide to run both method without parameter command and method with parameter command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void methodCOmmandGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Method Without Parameter Command\n\rCode Eg:\n\rmethod mymethod()\n\rrectangle 110,90\n\rtriangle 10,40,100,200\n\rendmethod\n\rmymethod()\n\r" +
                "\n\rMethod With Parameter Command\n\rCode Eg:\n\rmethod mymethod(radius,width,height)\n\rcircle radius\n\rrectangle width,height\n\rendmethod\n\rmymethod(50,165,50)");
        }
        /// <summary>
        /// when clicked by the user inside help menu it shows message containing guide to run color changing commands,position changing commands, shape color fill commands and shape color flashing commands
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void extraCommandsGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pen Color Change Command\n\rAvailable colors: red,black,blue,green,blueyellow,redgreen and blackwhite\n\rCode Eg:\n\rpen red\n\r\n\rFIll Shape With Color\n\r" +
                "Code Eg\n\rfill on\n\ror\n\rfill off\n\r\n\rChange Position\n\rCode Eg:\n\rmoveto 100,234\n\r\n\rFlash Colors Command\n\rTo change the color of shapes every 0.5sec use pen command" +
                " with color options blueyellow,redgreen or blackwhite\n\rCode Eg:\n\rpen blueyellow\n\rcircle 50");
        }

        /// <summary>
        /// method that runs the program and either runs or clears or resets when typed into the execution window and run button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Run_Click(object sender, EventArgs e)
        {
            if (typeRun.Text.ToLower().Equals("run"))
            {
                passCommandType();
                typeRun.Clear();
            }
            else if (typeRun.Text.ToLower().Equals("clear"))
            {
                Clear.PerformClick();
            }
            else if (typeRun.Text.ToLower().Equals(""))
            {
                passCommandType();
            }
            else if (typeRun.Text.ToLower().Equals("reset"))
            {
                Reset.PerformClick();
            }
            else
            {
                errorBox.Text = "Invalid User Command. You can enter only 3 commands: \"run\", \"clear\" and \"reset\" ";
            }
        }

        /// <summary>
        /// method that saves the commands typed by user in the command area and saves it as a text file in the chosen folder/location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog()
            {
                Filter = "Text Documents|*.txt",
                ValidateNames = true
            })
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(save.FileName))
                    {
                        sw.WriteLine(userInput.Text);
                    }
                }
        }
        /// <summary>
        /// method that loads an existing text file into the user command window/screen area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear.PerformClick();
            using (OpenFileDialog open = new OpenFileDialog()
            {
                Filter = "Text Documents|*.txt",
                ValidateNames = true,
                Multiselect = false
            })
                if (open.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(open.FileName))
                    {
                        string data = sr.ReadToEnd();
                        userInput.Text = data;
                    }
                }
            Clear.PerformClick();
        }
        /// <summary>
        /// method that resets the position of cursor to it's initial position i.e. x-axis = 0 and y-axis = 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
        }
    }
}
