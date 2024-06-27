
using System;

namespace Centrifuge
{
    public class MessageEvent
    {
        public byte[] Data { get; set; }
        public string ToString() {
            return System.Text.Encoding.Default.GetString(this.Data);
        }
    }
}