using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics.Metrics;

namespace Lab7
{
    internal class Interpreter
    {
        // contains double, int, float, string variables
        private Dictionary<String, Object> dictionaryVariables;

        // contains initialised objects
        private Dictionary<String, Object> dictionaryObjects;

        public Interpreter()
        {
            dictionaryVariables = new Dictionary<String, Object>();
            dictionaryObjects = new Dictionary<String, Object>();

            // adding objects and variables to the dictionaries
            dictionaryVariables.Add("var_int", 3);
            dictionaryVariables.Add("str_name", "Daisy");
            dictionaryVariables.Add("str_colour", "Orange");
            dictionaryVariables.Add("str_breed", "Drever");
            dictionaryObjects.Add("cat", new Cat("Arthur", "White"));
            dictionaryObjects.Add("dog", new Dog("Bella", "Beagle", 2));
        }

        public void readCommand(IEnumerable<String> lines)
        {
            int indEquel, indDot, indLeftBracket, indRightBracket = -1;
            int numberChars = 0;

            foreach (String str in lines)
            {
                // finding indexes of the sings
                indEquel = str.IndexOf("=");
                indDot = str.IndexOf(".");
                indLeftBracket = str.IndexOf("(");
                indRightBracket = str.IndexOf(")");

                // checking what command is in the string
                if (indEquel < indDot && indLeftBracket == -1 && indRightBracket == -1)
                {
                    // reading a variable name
                    int indLess1 = str.IndexOf("<") + "<".Length;
                    int indGreater1 = str.IndexOf(">");
                    numberChars = indGreater1 - indLess1;
                    String variableName = str.Substring(indLess1, numberChars);

                    //reading an object name
                    int indLess2 = str.IndexOf("<", indGreater1 + 1) + "<".Length;
                    int indGreater2 = str.IndexOf(">", indGreater1 + 1);
                    numberChars = indGreater2 - indLess2;
                    String objectName = str.Substring(indLess2, numberChars);

                    //reading a property name
                    int indLess3 = str.LastIndexOf("<") + "<".Length;
                    int indGreater3 = str.LastIndexOf(">");
                    numberChars = indGreater3 - indLess3;
                    String propertyName = str.Substring(indLess3, numberChars);

                    // reading a value from an object in the dictionary
                    readValue(variableName, objectName, propertyName);
                }
                else if (indLeftBracket != -1 && indRightBracket != -1)
                {
                    // reading the name of an object
                    int indLess1 = str.IndexOf("<") + "<".Length;
                    int indGreater1 = str.IndexOf(">");
                    numberChars = indGreater1 - indLess1;
                    String objectName = str.Substring(indLess1, numberChars);

                    // reading the name of a method
                    int indLess2 = str.IndexOf("<", indGreater1 + 1) + "<".Length;
                    int indGreater2 = str.IndexOf(">", indGreater1 + 1);
                    numberChars = indGreater2 - indLess2;
                    String methodName = str.Substring(indLess2, numberChars);

                    // using a method
                    useMethod(objectName, methodName);
                }
                else
                {
                    // reading the name of an object
                    int indLess1 = str.IndexOf("<") + "<".Length;
                    int indGreater1 = str.IndexOf(">");
                    numberChars = indGreater1 - indLess1;
                    String objectName = str.Substring(indLess1, numberChars);

                    // reading a property name
                    int indLess2 = str.IndexOf("<", indGreater1 + 1) + "<".Length;
                    int indGreater2 = str.IndexOf(">", indGreater1 + 1);
                    numberChars = indGreater2 - indLess2;
                    String propertyName = str.Substring(indLess2, numberChars);

                    // reading a variable name
                    int indLess3 = str.LastIndexOf("<") + "<".Length;
                    int indGreater3 = str.LastIndexOf(">");
                    numberChars = indGreater3 - indLess3;
                    String variableName = str.Substring(indLess3, numberChars);

                    // changing the value of a property
                    changeValue(objectName, propertyName, variableName);
                }
            }
        }

        public void readValue(String varName, String objName, String propName)
        {
            Object? obj = null;
            if (dictionaryObjects.Remove(objName, out obj))
            {
                Type t = obj.GetType();
                Object? valueObj = t.GetProperty(propName).GetValue(obj);

                // checking if the dictionary contains the variable
                Object? variable = null;
                if (dictionaryVariables.Remove(varName, out variable))
                {
                    variable = valueObj;
                    dictionaryVariables.Add(varName, variable);
                    Console.WriteLine("Read value: " + varName + " = " + variable);
                    Console.WriteLine();
                }
                else
                {
                    dictionaryVariables.Add(varName, valueObj);
                    Console.WriteLine("A new variable has been added");
                    Console.WriteLine("Read value: " + varName + " = " + valueObj);
                    Console.WriteLine();
                }

                // adding the object back to the dictionary
                dictionaryObjects.Add(objName, obj);
            }
        }

        public void useMethod(String objName, String methName)
        {
            Object? obj = null;
            if (dictionaryObjects.Remove(objName, out obj))
            {
                // invoking the method of the object
                MethodInfo method = obj.GetType().GetMethod(methName);
                method.Invoke(obj, null);

                // adding the object back to the dictionary
                dictionaryObjects.Add(objName, obj);
            }
        }

        public void changeValue(String objName, String propName, String varName)
        {
            Object? obj = null;
            Object? variable = null;
            if (dictionaryObjects.Remove(objName, out obj))
            {
                if (dictionaryVariables.Remove(varName, out variable))
                {
                    // changing the value of the property
                    PropertyInfo property = obj.GetType().GetProperty(propName);
                    property.SetValue(obj, Convert.ChangeType(variable, property.PropertyType), null);
                    Console.WriteLine("Changed value: " + property.Name + " = " + variable);
                    Console.WriteLine();

                    //adding the variable back to the dictionary
                    dictionaryVariables.Add(varName, variable);
                }
                // adding the object back to the dictionary
                dictionaryObjects.Add(objName, obj);
            }
        }
    }
}