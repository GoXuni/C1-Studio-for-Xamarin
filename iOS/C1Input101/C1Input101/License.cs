using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace C1Input101
{
    public static class License
    {
        public const string Key =
            "ABwBHAIcB3VDADEASQBuAHAAdQB0ADEAMAAxACUJQcsy74+vLVThUM+C+50njkvk" +
            "SsTHrO8sJqAPRpI3znjJHTxRrAZNKuvENi0cEcXA8Rr1N/UDXL6yCAilOECX7xVe" +
            "TG9SUU6FK2IFyGyJ5MLqWjSUidJBbhNrXbzlUV9wJoAPBEo0bjNxokqpmk3kW4AD" +
            "snsJ6gDCyXMugcxPUa7EV5jEc6XJQlNjuD0uFL6VoI+zoI0gbhdqx8gENiGnnBHl" +
            "4s8Nrl1nan/XmHXT740D/f/GvXrcud15BWldbbIiRf93A+Gy5xpmwHG2CbZBqCbG" +
            "Ta0gDyEC0QY4/5I2EMS6Djx9Qp2tugtmBDpl+QBlDjmEW/QUN+KcsnYkxhpMxga6" +
            "AoAFGHeD+CC1zJM4+brCW0XFGrEVFe2/VTT+jI3NTmQW8MEouKayG6WAh7QLJggs" +
            "Vfai7OziBqHXPxnuRCfc9bKIkjDzuBa0Z/L5p8VUmsALZuo/iy8X++cYTWukJJRU" +
            "gR9IuQZ0AhbLRxHpuQmbrsqYBEbSRYubOyX2YsLdejRo4TJWvcuLdiNFKv/FNujR" +
            "LqLNZg26f0yYSqNwiDCxmr+YT+3kJUaJInPMXbNX072NAhnvPL+8n/DG+CyJCTdG" +
            "UqUhosu/uL7EScRFrPGqUD+bOrDmZkMe46zIjvaFo6t0oqmjc+7gOc43iAU3oimp" +
            "tCDWWsxpSiTe7ZcYMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
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
            "hvcNAQEBBQADggEPADCCAQoCggEBAIUDuF0iSYEWGdg7/N8B2nsXcgrtpqlhFsho" +
            "HiEYp8I/U1O87mRdms7tGDKS4Gvx6YLcahkPWEZr9bIzVdgu+bRlHiITLtyB5+z+" +
            "tFjw5xarwB91uukQYq2Elp8KyQ1AVejMwtmUot93oyZ/6AC/Bn3GvpohPPoaX+OS" +
            "iKEnnnyLcl1EmuIJgTDKaW3uBFcLdptKl7Od1/UV3eTzhzfZGfhIAVY7EaV0wXth" +
            "w9xngJjfdF3yrqjt/+Ct18s1fZe2DtGDmadK4cJG6O8pTN7FpmjFko0vOYq6b5bO" +
            "cK8LRzfQoZrkNn4zockBcauB7V0l5URRz2R4cy9DsffqZYUjrCsCAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAcx2pTn8gVN7ql4nNtf6d4QhiSws7y+ANaCXAkVyPk5tP" +
            "OobnK5pzCA7Nfo8Sw+EQQVCDIF2albIeL8y468/x/ATgWswJmx3Z187gcwOmrrUh" +
            "+40xdiQnM9nfGqzjez+E3H9qgs6cKLKNCao1Ks3OnzJvrJqtzJg685s689FtD5k8" +
            "X5WPGgzH/SGHym/scwBIVK/TMGlMSQdKR/BViCVdsmuz8C0XWEHhES5iHPD1+IBK" +
            "aGHd5Glwl+Sm6gZvZv1IeqP9ou2S/84I9pLmDr6/SiaC9TcA6hyyrBMpZuYBjb7q" +
            "1Mf5Tom9U44YplC6pKj7GmRv/vpZs9I3yDvDyBCfHA==";
    }

}