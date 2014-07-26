using System;

namespace Lib.Utilities.DataAccess
{
    // This class maintains the parameter array for the query object
    public class Parameters
    {
        // Private members
        private Parameter[] mParameterArray = new Parameter[0];

        // Properties
        internal Parameter[] ParameterArray
        {
            get { return mParameterArray; }
        }

        #region Public Methods
        
        // Constructor
        public Parameters()
        {
            // Do nothing
        }

        // Destructor
        ~Parameters()
        {
            mParameterArray = null;
        }

        /// <summary>
        /// Add a new parameter to the parameter array
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value of the parameter</param>
        public void Add(string name, object value)
        {
            // Create a new parameter
            Parameter newParm = new Parameter(name, value);

            // Resize the array
            Array.Resize(ref mParameterArray, mParameterArray.GetLength(0) + 1);

            // Add the new parameter to the array
            mParameterArray[mParameterArray.GetUpperBound(0)] = newParm;
        }

        /// <summary>
        /// Changes the value of a parameter by index value
        /// </summary>
        /// <param name="index">The 0-based index of the parameter to change</param>
        /// <param name="newValue">The new value to change the specified parameter to</param>
        public void ChangeValue(int index, object newValue)
        {
            // make sure the index is within the bounds of the array
            if (index > mParameterArray.GetUpperBound(0))
            {
                throw (new Exception("Index is outside the bounds of the array"));
            }

            // Change the value
            mParameterArray[index].Value = newValue;
        }

        /// <summary>
        /// Changes the value of a parameter by name
        /// </summary>
        /// <param name="name">The name of the parameter to change</param>
        /// <param name="newValue">The new value to change the specified parameter to</param>
        public void ChangeValue(string name, object newValue)
        {
            // Find the parameter by name
            int i = 0;
            foreach (Parameter parameterClass in mParameterArray)
            {
                if (parameterClass.Name.Equals(name))
                {
                    mParameterArray[i].Value = newValue;
                    break;
                }

                i++;
            }
        }

        /// <summary>
        /// Clears all the parameters from the parameter array
        /// </summary>
        public void ClearAll()
        {
            Array.Resize(ref mParameterArray, 0);
        }

        /// <summary>
        /// Returns a value of a parameter by name
        /// </summary>
        /// <param name="name">The name of the parameter to return the value</param>
        /// <returns>The value of the parameter specified by name</returns>
        public object GetValue(string name)
        {
            // Find the parameter by name
            object value = null;
            foreach (Parameter parameterClass in mParameterArray)
            {
                if (parameterClass.Name.Equals(name))
                {
                    value = parameterClass.Value;
                    break;
                }
            }

            return value;
        }

        /// <summary>
        /// Returns a value of a parameter by index
        /// </summary>
        /// <param name="index">The 0-based index of the parameter value to retrieve</param>
        /// <returns>The value of the parameter specified by the index</returns>
        public object GetValue(int index)
        {
            // make sure the index is within the bounds of the array
            if (index > mParameterArray.GetUpperBound(0))
            {
                throw (new Exception("Index is outside the bounds of the array"));
            }

            Parameter parameterClass = mParameterArray[index];
            return parameterClass.Value;
        }

        /// <summary>
        /// Removes a specified parameter from the parameter array
        /// </summary>
        /// <param name="name">The name of the parameter to remove</param>
        public void Remove(string name)
        {
            // declare a new parameter array
            Parameter[] newArray = new Parameter[0];
            int index = 0;

            // Loop through each parameter in the array only adding the ones that don't match the parameter name
            foreach (Parameter findParam in mParameterArray)
            {
                if (!findParam.Name.Equals(name))
                {
                    // resize the new array
                    index++;
                    Array.Resize(ref newArray, index);
                    newArray[index - 1] = findParam;
                }
            }

            // Set the member array equal to the new array
            mParameterArray = newArray;
        }

        /// <summary>
        /// Removes a specified parameter from the parameter array
        /// </summary>
        /// <param name="index">The 0-based index of the parameter to remove from the array</param>
        public void Remove(int index)
        {
            // make sure the index is within the bounds of the array
            if (index > mParameterArray.GetUpperBound(0))
            {
                throw (new Exception("Index is outside the bounds of the array"));
            }

            // declare a new parameter array
            Parameter[] newArray = new Parameter[0];
            int newArrayIndex = 0;

            // Loop through each parameter in the array only adding the ones that don't match the parameter name
            for (int i = 0; i <= mParameterArray.GetUpperBound(0); i++)
            {
                if (!i.Equals(index))
                {
                    // resize the new array
                    newArrayIndex++;
                    Array.Resize(ref newArray, newArrayIndex);
                    newArray[newArrayIndex - 1] = mParameterArray[i];
                }
            }

            // Set the member array equal to the new array
            mParameterArray = newArray;
        }

        #endregion
    }
}
