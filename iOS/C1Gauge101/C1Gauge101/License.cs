using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace C1Gauge101
{
    public static class License
    {
        public const string Key =
            "ABwBHAIcB3VDADEARwBhAHUAZwBlADEAMAAxACkEB2cnvhINj5G7RLRFbpytQD84" +
            "nylNWy+60zeI39O0OwwLIV67XfxO+xi1kkuDaFzX4Z69ay0W8BbABTYszc3kI8j0" +
            "3Nagkezi/PkF99GGI6Rx+4Por0EygSMihsoydz5YCdawIhMjiy/aADu+Zbj98raA" +
            "6Sjd5CwFc2KAcYeFSv4gHGZF9lifUO4vzy1b+5v7o+1+NMDJW9rGmrF/SggNY8u4" +
            "WF2VrlnWN14DhgjfXCjjgXOAJMuJ/u85efpRoiQT+/mtnxyKPryRVqCO7AtUH++i" +
            "L7RiN8RFisluLGMAQdgPjdI+cXh3/WB7cjFNA4lG/mlZWLe+uA1Z8VltFm5rOiLE" +
            "Fq1d6vQefovEQK7mkwxzeIhiu3+fSDYzXx8KB6Sc/QomNXrwb+lRyGsgj+DWjCk9" +
            "6jAnVy1dgkqDtYyya9T4w47n3zG8Cj9a9zppeRrjwAzAoIM99hNZpXRd3TZ4nBRI" +
            "mAWQeAwgQoOSxbDXkNZOlQ6YGx2S9kkn5TrxTNXqvbhcO4OcfpYcsrMQiB8TdpQh" +
            "c6gF80YQmKxTUeG8jTE+BaSziF2jEPN0KFCNicK0nyWQqTfaiJExoanw7VG5IVLi" +
            "oqyLn9U7IxwF9ixQhqmM1YqRQiHdh35FaNp9Px1tW7rFMr2bgG2ufm4mVeSrqXYs" +
            "T5CawkwP3k9dZCtrMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
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
            "hvcNAQEBBQADggEPADCCAQoCggEBAJHcygafiWbEfgG3QkJzMAizzfjUWB9w3ebi" +
            "b7FR6L4HK7X6+brL8oyUP+9FtKRdFpNjlY8e8rufH8ibVK5T0qPBg7q3z5vqZBZi" +
            "5TFEM2jH023ZaFQaySNt1JJhXUOBkHL9k5gXR6RA+6h435yLdcHXhSVuac9YTsbD" +
            "2QuNtlyblrYjDR0/vleMfLtCv4U204+mJgLiTrUiFVdKlOgCsQyE1VhQqMKT/6RV" +
            "2AG0lfmxmLxtTY/c8gTZ2HdREnjZRNK8GBO4j+sdzgjnB7+A+1BhBdiM3Pa0q9xU" +
            "g8VCcGxrhmmJjFuFhBNWP7SdQkMay9zgB3Wffbs6HJPNvXYTaH8CAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAcYH6O36AYGiGlMwTWaNkzHD2Zr5aTDpJhb2Uh9I/EeqZ" +
            "m+SMeQg+KUcH7a4T2koG6TJa1IM2gycNdlqhA5+8ks9Huaij/qLHsm9ra4rJ1tC3" +
            "e5XDYCIHrZoPLYS7dNBPTIc4fzA352qtHWYGVik4USBM5UnMeJmTUvU2tvOBZ7el" +
            "UGN8M5xOGFqvUZyqQf0mCZ1vGDXKPXd8D2B03pkKQghhX1YA1C6p6B3seQpnMuwn" +
            "WRMOldV30N2gP6NutKXPCY1nWGvqYCOdQ38ACDFx4iZ2Lh2oo+UknXlU2cH3igWm" +
            "Ggzb4EkYieTzS36stQTiFDX772NMcQVw1vWshSAF+A==";
    }

}