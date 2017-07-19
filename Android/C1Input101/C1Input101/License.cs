using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace C1Input101
{
    public static class License
    {
        public const string Key =
            "ABwBHAIcB3VDADEASQBuAHAAdQB0ADEAMAAxADHGSfNu/Q0Vu/GdTLpvPL1Gv3uP" +
            "bqVUxjNBW42oeNvc+qJ5XFJqv5hJ0gO6385IXUCIhBjZyY7aqbM+FFq1/hibT07f" +
            "eH+6oqroGk+7c97rvQZwJhbbEBXKNTPfD7LzJZcZ9yRWSUajkKlr84FjaOqKcT9I" +
            "l6z8wy+lAvqP569Ls6Ok7qAl3P2pvok+E3Ng3GxEuU+AenpPU5GqxP/eGihsZO7d" +
            "lKn4WuTeY1vtd60mTEyYInPzH1Y2kBJ2lCQ3+op0bJ+qN1So/YFoQyvKTIcaCs0+" +
            "UBVT76YPaL6BsmDEsuoCgo6/QxKTfO2TgduLOxEvi9v+wRTXA69WqD9UHZIDIYXI" +
            "rbgzT8QsBXuxvlblXcDKAiobq3sy6pMQElgSO4tvGq8gfk59xKenIaVDeDw/lGbD" +
            "tOjXx4JKrBGtZNTWowLFmBi4ZHPQlXkuscJZXxJQRI5eFIiawqy401+JzLLurFIo" +
            "KsFidlEvBQdDYd63QOSa2efxhsaWskSvtiaLDHkpj/KS575UmOsU8hyXnz3X4Smj" +
            "5YLhf5M+w1vuQKEioGWibolvKAYDVJTvLz+8l1sF3B/uBjVX27OqODZQ1nh+9Jxr" +
            "kEcgSmEn7fqwUOFEfg9yIAJIil8+NC6XTIK2e5GH/oOeVT8+Ys2lPycW1nxSDnJ6" +
            "RCsfd4WN3RWjq4rLMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
            "hkiG9w0BAQUFADCBtDELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDlZlcmlTaWduLCBJ" +
            "bmMuMR8wHQYDVQQLExZWZXJpU2lnbiBUcnVzdCBOZXR3b3JrMTswOQYDVQQLEzJU" +
            "ZXJtcyBvZiB1c2UgYXQgaHR0cHM6Ly93d3cudmVyaXNpZ24uY29tL3JwYSAoYykx" +
            "MDEuMCwGA1UEAxMlVmVyaVNpZ24gQ2xhc3MgMyBDb2RlIFNpZ25pbmcgMjAxMCBD" +
            "QTAeFw0xNDEyMTEwMDAwMDBaFw0xNTEyMjIyMzU5NTlaMIGGMQswCQYDVQQGEwJK" +
            "UDEPMA0GA1UECBMGTWl5YWdpMRgwFgYDVQQHEw9TZW5kYWkgSXp1bWkta3UxFzAV" +
            "BgNVBAoUDkdyYXBlQ2l0eSBpbmMuMRowGAYDVQQLFBFUb29scyBEZXZlbG9wbWVu" +
            "dDEXMBUGA1UEAxQOR3JhcGVDaXR5IGluYy4wggEiMA0GCSqGSIb3DQEBAQUAA4IB" +
            "DwAwggEKAoIBAQDBAvbKZVuylaQKkQelVQe1yZvPmutMe/B2VjZrwI7P3q5qe6W4" +
            "fDPR2LhFU0Y/B+G2l8RWKuIu+XuZDa+7PpxmyeVHzOgpXam3kbEOM70W+p6X67XD" +
            "gcH2DsdMKHmEHyOlcy1c4T2xo1AyuqnR2S3/xHL0iCr0W7tyCzhN5LrsdO4EJG/v" +
            "q60gVMiSl1PJ1vHPivvbH1qh2D2/BRdiGs1sYZnyHSKAzSso696/8CJ940Ho6an2" +
            "pohzbFPztuiktBHLwkuQhTig0+r73ZwJHpN5Mi1nn/nGv3GxaO+L2sGBrZsNsM8P" +
            "4XMJQDSEGggMc/uSR0Gd0hIPCy0mfgvBOE/vAgMBAAGjggGNMIIBiTAJBgNVHRME" +
            "AjAAMA4GA1UdDwEB/wQEAwIHgDArBgNVHR8EJDAiMCCgHqAchhpodHRwOi8vc2Yu" +
            "c3ltY2IuY29tL3NmLmNybDBmBgNVHSAEXzBdMFsGC2CGSAGG+EUBBxcDMEwwIwYI" +
            "KwYBBQUHAgEWF2h0dHBzOi8vZC5zeW1jYi5jb20vY3BzMCUGCCsGAQUFBwICMBkM" +
            "F2h0dHBzOi8vZC5zeW1jYi5jb20vcnBhMBMGA1UdJQQMMAoGCCsGAQUFBwMDMFcG" +
            "CCsGAQUFBwEBBEswSTAfBggrBgEFBQcwAYYTaHR0cDovL3NmLnN5bWNkLmNvbTAm" +
            "BggrBgEFBQcwAoYaaHR0cDovL3NmLnN5bWNiLmNvbS9zZi5jcnQwHwYDVR0jBBgw" +
            "FoAUz5mp6nsm9EvJjo/X8AUm7+PSp50wHQYDVR0OBBYEFABa8K2l1Hg19YQSqCwF" +
            "DvhWG46OMBEGCWCGSAGG+EIBAQQEAwIEEDAWBgorBgEEAYI3AgEbBAgwBgEBAAEB" +
            "/zANBgkqhkiG9w0BAQUFAAOCAQEAiMKYWjeOW+VYirEXwgOoW1XqjITQiZi+uJqs" +
            "XWL8N4LBeKDgg6IjOpFoctTaFHdi6XK/T43xieeWV+LGZaqMXn5U6R4J1/DDybiq" +
            "QwbJO1pIYhLuuXwcG/oPcEBzDH4GNIIxyAENmRH9jyek00hXL49uMIe93bMqnJo9" +
            "vdH6cA7R2hdoxOaav7UATifLw5DeOsLeKjIRupyKToHPSp4Miy3RDu1d+CjNTW/r" +
            "DfSZKk1lzaDapTn+0I2B8JcOyru1t5CBivn9ZD9cakwaV8LARObC5Z7oz/iQKlfG" +
            "ipQSQykSNyIZaxvQiVJqhTYZmdn+UBOYwLz0Hl3ry5zGIqia4DCCAsYwggGuoAMC" +
            "AQICBA7u7u4wDQYJKoZIhvcNAQEFBQAwJTEjMCEGA1UEAwwaR0MtWHVuaSBJbnRl" +
            "cm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMTMxMjQ3WhcNMzcxMjMxMTMxMjQ3WjAl" +
            "MSMwIQYDVQQDDBpHQy1YdW5pIEludGVybmFsIERldmVsb3BlcjCCASIwDQYJKoZI" +
            "hvcNAQEBBQADggEPADCCAQoCggEBAJMzerbLo4DQkScDnrl43t/Aexw4gYpKxeTF" +
            "7xwR2yEJvSrL3MbQ0v5xhjG3c3WiLQPBl+3PWYPELSUHPfAku9X+ZLoEnvTwoGkT" +
            "IQBRTKTGBUyFXQx02LrKT4cok4C/5oVzmqw81JpYBurWavrsqvAfwyVfIrvciI2J" +
            "rLLipTm22nf31rQJvBuGbTGAfgoAi2JZaCoeWuC9J+BCMyxxCAGjw7UpAqxUbEjJ" +
            "8B01/DSzOi+D3XkEDJsX4Y9TyIGJcgjPqRZ01XktfeQKfZAIg7OIV/FsNTHSd7Mx" +
            "WQJnb5C44JjMISLq4QAYanKq4MSH5tBs7D1ro5WI2/KW4ZcunkUCAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAYevjguQ0icpYgDanQzKkT8WqG0vjRQOoqXdzl1ItM57R" +
            "PLFwJ3BnArARuOYAqnfYa+0WszGSFqQCoShjhfvVdSo0s5syM3nRli7pipulV5Ax" +
            "/fLs3KIwsmrwIuzPZBmWxdbcVXnXUlWaJfIR4Hn2Wcr8md4LbRcKZajxQqtYoH5A" +
            "cehTcgmO9A0E86YjZuef9RqpyxurpncL7IMPvqwLTbp6m6d82koPyqOGt2tcysR5" +
            "aiT/XTg8wbcWK5kGg8Rg8Nnk8f+GDViASRvtgn2EhDBMl6bNRRBFqQSABjv0BDnu" +
            "YOGlxfKuDkKelgmGKvTM4HwWaEGrz+yR3cDOoZiKOA==";
    }

}