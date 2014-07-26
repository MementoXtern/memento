using System;
using System.IO;
using System.Security.Cryptography;

namespace Lib.Utilities.DataAccess
{
    // Enumeration of available cryptography algorithms
    public enum CryptoType
    {
        DES, RC2, Rijndael, TripleDES
    }

    public class CryptoManager
    {
        // Member variables
        private SymmetricAlgorithm mCSP;

        #region Properties
        
        public string Key
        {
            get { return Convert.ToBase64String(mCSP.Key); }
            set { mCSP.Key = Convert.FromBase64String(value); }
        }

        public string IV
        {
            get { return Convert.ToBase64String(mCSP.IV); }
            set { mCSP.IV = Convert.FromBase64String(value); }
        }

        #endregion

        #region Public Methods
        
        // Constructor
        public CryptoManager(CryptoType type)
        {
            // Set the Cryptography Service Provider object
            SetServiceProvider(type);
        }

        // Constructor
        public CryptoManager(CryptoType type, string key, string iv)
        {
            // Set the Cryptography Service Provider object
            SetServiceProvider(type);

            // Set properties
            Key = key;
            IV = iv;
        }

        // Destructor
        ~CryptoManager()
        {
            mCSP = null;
        }

        /// <summary>
        /// Decrypts a string value
        /// </summary>
        /// <param name="value"></param>
        public void Decrypt(ref string value)
        {
            DoDecryption(ref value);
        }

        /// <summary>
        /// Encrypts a string value
        /// </summary>
        /// <param name="value"></param>
        public void Encrypt(ref string value)
        {
            DoEncryption(ref value);
        }

        /// <summary>
        /// Generates a random encryption intitialization vector
        /// </summary>
        /// <returns></returns>
        public string GenerateIV()
        {
            mCSP.GenerateIV();
            return Convert.ToBase64String(mCSP.IV);
        }

        /// <summary>
        /// Generates a random encryption key
        /// </summary>
        /// <returns></returns>
        public string GenerateKey()
        {
            mCSP.GenerateKey();
            return Convert.ToBase64String(mCSP.Key);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Decrypts a string value using the selected cryptography algorithm
        /// </summary>
        /// <param name="value">content that will be decrypted by this method</param>
        private void DoDecryption(ref string value)
        {
            MemoryStream myMemoryStream;
            CryptoStream myCryptoStream;
            StreamReader myStreamReader;

            // Convert the string to decrypt to an array of bytes
            byte[] byteArray = Convert.FromBase64String(value);

            // put the byte array into a memory stream
            myMemoryStream = new MemoryStream(byteArray);

            // Create a new crypto stream for decryption
            myCryptoStream = new CryptoStream(myMemoryStream, mCSP.CreateDecryptor(),
                                              CryptoStreamMode.Read);

            // Decrypt the string using the selected cryptography algorithm
            myStreamReader = new StreamReader(myCryptoStream);

            value = myStreamReader.ReadToEnd();

            //close the reader
            myStreamReader.Close();
        }

        /// <summary>
        /// Encrypts a string value using the selected cryptography algorithm
        /// </summary>
        /// <param name="value">content that will be encrypted by this method</param>
        private void DoEncryption(ref string value)
        {
            MemoryStream myMemoryStream = new MemoryStream();
            CryptoStream myCryptoStream;
            StreamWriter myStreamWriter;

            // Create a new crypto stream for encryption
            myCryptoStream = new CryptoStream(myMemoryStream, mCSP.CreateEncryptor(),
                                              CryptoStreamMode.Write);

            // Create a new stream writer for the crypto stream to write to in memory
            myStreamWriter = new StreamWriter(myCryptoStream);

            // Start the encryption
            myStreamWriter.Write(value);

            // Close the stream writer and crypto writer
            myStreamWriter.Close();
            myCryptoStream.Close();

            // Convert the encrypted stream into a string
            byte[] returnByteArray = myMemoryStream.ToArray();

            // Return the encrypted string
            value = Convert.ToBase64String(returnByteArray);
        }

        /// <summary>
        /// Sets the member service provider object to a specific type of cryptography algorithm
        /// </summary>
        /// <param name="type"></param>
        private void SetServiceProvider(CryptoType type)
        {
            try
            {
                switch (type)
                {
                    case CryptoType.DES:
                        mCSP = new DESCryptoServiceProvider();
                        break;
                    case CryptoType.RC2:
                        mCSP = new RC2CryptoServiceProvider();
                        break;
                    case CryptoType.Rijndael:
                        mCSP = new RijndaelManaged();
                        break;
                    case CryptoType.TripleDES:
                        mCSP = new TripleDESCryptoServiceProvider();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message + " -- SetServiceProvider "));
            }
        }

        #endregion
    }
}
