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

namespace C1Gauge101
{
    public static class License
    {
        public const string Key =
            "ABwBHAIcB3VDADEARwBhAHUAZwBlADEAMAAxAHeeCFIg07Ma6NqEYr4aAKRFgyDj" +
            "Q9L83LmVVr/218E5u9XVa84cL75wCKjOPHGiVehAUL0H8Y/8Q6L6ry4/b6c0rL0x" +
            "ZuVKjA1/NJPWUeKs4vJR2gk0qXdKAV1iiidOjzde64W9qxYlH1o2CoJiJvbMPkC7" +
            "djqvt9OxRKQEYgDZOPSMBET3z2kviPI8CJslBHs1LmbLoPkLFVbbSMY4nmbY3ewO" +
            "AzzCPg2XQ92n+sUvxixFjvybbbdHhaj2NT40vQfg0dPf6Zz7bYDDGV1jb6FliSgK" +
            "nI96cVR8EsRf0eEZRSY0TKzEegcehT2gL1ZN+R4vywDVG/fzEl+NbFQm3t1fDJ4c" +
            "L6jNPR2Tmu/3ERJKW+c5/nTp8iEKd46+2g+JXAcI2xkvT8VZSXhNDhdFuCu23UFw" +
            "KLlJxhFXgJRw3UTUZsRVFd7hKz8V3WHs8Y/SKy23ZAtA5yt3z+a0BVZAOlRb4FxY" +
            "tiDNGUuz9M4+LS2i5/TTug+L9sDcsgnXcxG5RpfbzNxgDoY2t3nXKKSIlYJ6U+/9" +
            "dDDJdZazfBX33XlcMDTcq8RmxaOncIAby6xUsPh4lkCmKuDMlhbRWuajrtADPeB9" +
            "GPGytoMA0j0+55rcAS3pOaR8zTs4cs3ahNHkIig/pqpcjouZy2P0WoGOfrb5zwdR" +
            "Cn4z5anKaZajtkMxMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
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
            "hvcNAQEBBQADggEPADCCAQoCggEBAJlaDW4au91Th2o2rMpUpxiyZlNO7r+aN7bV" +
            "NbUYp2dwO2E2aYPXvHocqSII0yYT3BTIaP+R/UdOzbFL0fUJZzXnoWpTiRVaabmh" +
            "7hhUywG8HvcnkrmAu2lduuDzUFj9ZS/osQ7JBJPhRTwJLSQNCD1D/klUttlf0JaY" +
            "Iz+RY38Za3N9BzLFIJzesjhQeT4krKhElZXU1nfOVicvSRdNKwJzmxBo4I0wxlQ2" +
            "8eIcEdVHLUXY+TqIODvZsWIh5a+9rcOXsrpOSOWZKw47jTkHzwt190Q+yOgtIjEz" +
            "Sg+uE/vaG9TnKEVN5VO12Y/YetW1/RDBY15dh5BaVCkzu9eMDXUCAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEASGqt1ie3X4DHYa8MXkNzJ4tlyn/2zDx7z/vuedE9b2xQ" +
            "ZQDPwGadd9+RpdPbQBrqog3K6B7YsZCUZyWC1ms7v+aGtvPmj6AQAB1r2qA9pRn3" +
            "uUZLbV9l/wqDuMAUuEdmkQjlkf8Qn5FzAIVWv9TwdrrAd3rrvS++d57En2LN95Cq" +
            "E5Lkh0Wy6S0IMHsC+S5Dxeq+TWO6kMaltADN0S+E08VJnMUG4hE9Mf9phXJ2MjTa" +
            "xRyeL9O60HzXqO3Loh79qbUojWJXAPGCOvEFQ6LYVseu/TtA/Gyt9LoALsqfV1kb" +
            "Q3USDvR/zaDEhBkfVNS4bsZt5fDH/Y7/TXMHB4r7QQ==";
    }

}