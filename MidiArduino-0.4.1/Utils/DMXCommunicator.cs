using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

//  ______                          _____   ______   _____  
// (____  \                        (____ \ (_____ \ / ___ \ 
//  ____)  ) ____ _   _ ____   ___  _   \ \ _____) ) |   | |
// |  __  ( / ___) | | |  _ \ / _ \| |   | |  ____/| |   | |
// | |__)  ) |   | |_| | | | | |_| | |__/ /| |     | |___| |
// |______/|_|    \____|_| |_|\___/|_____/ |_|      \_____/ 
//
// 01000010 01110010 01110101 01101110 01101111 01000100 01010000 01001111

namespace BrunoDPO.DMX
{
    /// <summary>
    /// This class implements the DMX Communication Protocol over a Serial Port.
    /// It is recommended for this class to work that you either buy or make a
    /// RS232 to RS485 converter.
    /// </summary>
    public class DMXCommunicator
    {
        private byte[] buffer = new byte[513];
        private bool isActive = false;
        private Thread senderThread;
        private SerialPort serialPort;

        /// <summary>
        /// Default baud rate for the DMX512 Protocol
        /// </summary>
        private const int DMX512_BAUD_RATE = 250000;

        /// <summary>
        /// Initialize a DMXCommunicator class
        /// </summary>
        /// <param name="portName">Name of the serial port as a string</param>
        /// <exception cref="Exception">If the serial port is somehow inaccessible</exception>
        public DMXCommunicator(string portName) : this(new SerialPort(portName)) { }

        /// <summary>
        /// Initialize a DMXCommunicator class
        /// </summary>
        /// <param name="port">Instance of a SerialPort</param>
        /// <exception cref="Exception">If the serial port is somehow inaccessible</exception>
        public DMXCommunicator(SerialPort port)
        {
            buffer[0] = 0; // The first byte must be a zero
            serialPort = ConfigureSerialPort(port);
        }

        /// <summary>
        /// Set up a connection and try to open it to see if the port is
        /// compatible with the DMX512 protocol
        /// </summary>
        /// <param name="port">Serial port instance</param>
        /// <returns>The referenced serial port instance</returns>
        /// <exception cref="Exception">If the serial port is somehow inaccessible</exception>
        private static SerialPort ConfigureSerialPort(SerialPort port)
        {
            try
            {
                if (port.IsOpen)
                    port.Close();

                // Port configuration
                port.BaudRate = DMX512_BAUD_RATE;
                port.DataBits = 8;
                port.Handshake = Handshake.None;
                port.Parity = Parity.None;
                port.StopBits = StopBits.Two;

                // Try to open a connection with the given settings
                port.Open();
                port.Close();

                return port;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// Returns the state of the connection
        /// </summary>
        /// <returns>True if the communication is active</returns>
        public bool IsActive
        {
            get
            {
                lock (this)
                {
                    return isActive;
                }
            }
        }

        /// <summary>
        /// Get a parameter value
        /// </summary>
        /// <param name="index">Parameter index between 0 and 511</param>
        /// <returns>Parameter value in bytes</returns>
        /// <exception cref="IndexOutOfRangeException">If the index is not between 0 and 511</exception>
        public byte GetByte(int index)
        {
            if (index < 0 || index > 511)
                throw new IndexOutOfRangeException("Index is not between 0 and 511");

            lock (this)
            {
                return buffer[index + 1];
            }
        }

        /// <summary>
        /// Get all the parameter values as a byte array
        /// </summary>
        /// <returns>All 512 parameters as a byte array</returns>
        public byte[] GetBytes()
        {
            byte[] newBuffer = new byte[512];
            lock (this)
            {
                Array.Copy(buffer, 1, newBuffer, 0, 512);
                return newBuffer;
            }
        }

        /// <summary>
        /// List all DMX-compatible serial ports
        /// </summary>
        /// <returns>A list of all valid serial ports</returns>
        public static List<string> GetValidSerialPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            List<string> portNames = new List<string>();
            foreach (string port in ports)
            {
                try
                {
                    ConfigureSerialPort(new SerialPort(port));
                    portNames.Add(port);
                }
                catch (Exception) { }
            }
            return portNames;
        }

        /// <summary>
        /// Send the parameters to all slaves in this DMX512 universe
        /// </summary>
        private void SendBytes()
        {
            while (isActive)
            {
                // Send a "zero" for 1ms (must send it for at least 100us)
                serialPort.BreakState = true;
                Thread.Sleep(1);
                serialPort.BreakState = false;
                // Send all the byte parameters
                serialPort.Write(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// Update a parameter value
        /// </summary>
        /// <param name="index">Parameter index between 0 and 511</param>
        /// <param name="value">Parameter value</param>
        /// <exception cref="IndexOutOfRangeException">If the index is not between 1 and 512</exception>
        public void SetByte(int index, byte value)
        {
            if (index < 0 || index > 511)
                throw new IndexOutOfRangeException("Index is not between 0 and 511");

            lock (this)
            {
                buffer[index + 1] = value;
            }
        }

        /// <summary>
        /// Update all parameter values
        /// </summary>
        /// <param name="bytes">A byte array containing 512 elements</param>
        /// <exception cref="ArgumentException">If the new byte array does not contain 512 elements</exception>
        public void SetBytes(byte[] newBuffer)
        {
            if (newBuffer.Length != 512)
                throw new ArgumentException("This byte array does not contain 512 elements", "newBuffer");

            lock (this)
            {
                Array.Copy(newBuffer, 0, buffer, 1, 512);
            }
        }

        /// <summary>
        /// Open the connection and start sending data
        /// </summary>
        public void Start()
        {
            // Prevents it from being started more than once
            if (!this.IsActive)
            {
                lock (this)
                {
                    if (!this.IsActive)
                    {
                        if (serialPort != null && !serialPort.IsOpen)
                            serialPort.Open();
                        this.isActive = true;
                        if (serialPort != null && serialPort.IsOpen)
                        {
                            senderThread = new Thread(this.SendBytes);
                            senderThread.Start();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Stop sending data and close the connection
        /// </summary>
        public void Stop()
        {
            // Prevents it from being stopped more than once
            if (this.IsActive)
            {
                lock (this)
                {
                    if (this.IsActive)
                    {
                        this.isActive = false;
                        try
                        {
                            senderThread.Join(1000);
                        }
                        catch (Exception)
                        {
                            // TODO: Better exception handling
                        }
                        if (serialPort != null && serialPort.IsOpen)
                            serialPort.Close();
                    }
                }
            }
        }
    }
}
