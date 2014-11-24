using System;
using System.Collections.Generic;
using System.Text;

namespace KayakoTestApplication
{
    public static class MockAttachment
    {
        public static string Contents
        {
            get
            {
                return @"VGhpcyBpcyBhIHRlc3Q=";
            }
        }

        public static string Filename
        {
            get
            {
                return "test.txt";
            }
        }
    }
}
