// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandLine.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2013 Yellow Feather Ltd
// </copyright>
// <summary>
//   The command line.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DbfCompare
{
  using System;
  using System.Collections;
  using System.Globalization;

  /// <summary>
  /// The command line.
  /// </summary>
  public class CommandLine
  {
    /// <summary>
    /// The dictionary.
    /// </summary>
    private readonly IDictionary dictionary = new Hashtable();

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandLine"/> class.
    /// </summary>
    public CommandLine()
    {
      var arguments = Environment.GetCommandLineArgs();
      for (var i = 1; i < arguments.Length; i++)
      {
        var argument = arguments[i];
        var name = string.Empty;
        var value = string.Empty;

        if ((argument[0] != '/') && (argument[0] != '-'))
        {
          value = argument;
        }
        else
        {
          var index = argument.IndexOf(':');

          if (index == -1)
          {
            // "-option" without value
            name = argument.Substring(1).ToLower(CultureInfo.InvariantCulture);

            // Turn '-?' into '-help'
            if (name == "?")
            {
              name = "help";
            }
          }
          else
          {
            // "-option:value"
            name = argument.Substring(1, index - 1).ToLower(CultureInfo.InvariantCulture);
            value = argument.Substring(index + 1);
          }
        }

        // Ensure key exists and add value.
        var strings = (ArrayList)this.dictionary[name];
        if (strings == null)
        {
          strings = new ArrayList();
          this.dictionary.Add(name, strings);
        }

        strings.Add(value);
      }
    }

    /// <summary>
    /// The get argument.
    /// </summary>
    /// <param name="name">
    /// The name.
    /// </param>
    /// <returns>
    /// The argument value <see cref="string"/>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the argument has not been given a value.
    /// </exception>
    public string GetArgument(string name)
    {
      var list = (ArrayList)this.dictionary[name];

      if (list != null)
      {
        if (list.Count != 1) 
        {
          throw new InvalidOperationException();
        }

        return (string)list[0];
      }

      return null;
    }

    /// <summary>
    /// The get arguments.
    /// </summary>
    /// <param name="name">
    /// The name.
    /// </param>
    /// <returns>
    /// The string array.
    /// </returns>
    public string[] GetArguments(string name)
    {
      var list = (ArrayList)this.dictionary[name];

      if (list != null) 
      {
        var array = new string[list.Count];
        list.CopyTo(array, 0);
        return array;
      }

      return null;
    }
  }
}