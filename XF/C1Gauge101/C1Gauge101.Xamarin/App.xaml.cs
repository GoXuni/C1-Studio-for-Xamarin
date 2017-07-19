namespace C1Gauge101
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Xamarin.Forms.NavigationPage(new GaugeSamples());
        }

        protected override void OnStart()
        {
            C1.Xamarin.Forms.Core.LicenseManager.Key = License.Key;
        }
    }

    public static class License
    {
        public const string Key =
            "ABwBHAIcB3VDADEARwBhAHUAZwBlADEAMAAxAEgWr2nrGW5W9zSUoyVuVSXXvAwu" +
            "Klx5M2pLegOdYzW5gDCbzSQRe9DbO/raO26csKVA8HFGVzilUugwCFvSpaY7Z3wP" +
            "f03QwiwKnk5xLGMN+D0axi//FWvCIz8UpWXEMbdbq+2N6FU4oM9msrbsr2bZ9kiC" +
            "rV/P1gZ/Y60u4eyD9zatv6jcMPOlcLaXQFKflIUcJEj9b4DRV70hptuHWIGsm0Uh" +
            "H3vkThRJBcOqStoK5vVaPiNVKNIPE8G5YnbxGGr2D4IMY82LVwJ4DTq2MBTPWeFc" +
            "UAkbfNVuog7n/WEdlqt8kx9HZVISBQnXsNXdfQajMPpSyLSPFg9Y0f/h1CK+rPky" +
            "Od/xQnpQzL7SAhsydw0vztPUzk1T0hpAlbKK1k9q6Rx8WWJemEXYywSZwW2Q//5l" +
            "iQUUTwt5akd73CFZtlO4BSC+1IxbTQAppfc/+XTzSBvjg6FlwHumLK/SERjLPa6H" +
            "JtHnT3TbBo6kw1CdXsaIZRAMxJHIIF24t9Z0c4ELl7Z0sx2G/EB2gIW6HAfVecmw" +
            "SpM9mENmt0uh1MHyX4IMrf2JaKDjWpoEG5cdDXwoayiqgI86Yllk6Q9aD8KnbQBA" +
            "Cj+iEiBVxusMPMpWMBgs6K43srhHUBfj/THT5DrRJyv+vSmh1FA955HPZE5GTl9K" +
            "PAzcGoZUGzSBm9qXMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
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
            "cm5hbCBEZXZlbG9wZXIwHhcNMTcwMTAxMTQwMzEzWhcNMzcxMjMxMTQwMzEzWjAl" +
            "MSMwIQYDVQQDDBpHQy1YdW5pIEludGVybmFsIERldmVsb3BlcjCCASIwDQYJKoZI" +
            "hvcNAQEBBQADggEPADCCAQoCggEBAIyU86sjzcCkXUYcC1+k8Flu9mwauXqVKbWe" +
            "FYUHnHdFp1z+lGIRzDST+seN3/YXX21EeSJkwEKJrnKGQt7luovyX4hNLi+WywxX" +
            "RSBaDgC/xtnXvM5gxQ6Y9O2KGGu789TGYRRZZvIpUaM/iv9kyWZ/iWnAae4LNbtC" +
            "VvSrWo+Yua9D8JHEVZShZ0RBWDWsfXIInN33qb+NmkCSLA+2Gdn0nqTL836IapMW" +
            "KGxwU+8tLkxXBstbJo0ulbEJT4HHBuTL26CuHy83yJTu180gqeN6XfZz0OepJo5M" +
            "nFlbd969NMIq+kaDlqn4y0u8zcfh93ByfhvvablkcO10DDcgbXsCAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEAC9apJNbKCubBztlpfkMjFNQCtekaEFdBxfyINc6H67Jp" +
            "ghtRkoUcNy4DykvyarM539mFNt6xAG71AbC8U418MQ+jG+4cmPKsqGsWgNWyqKxk" +
            "/JUyHIvPP1XxoN+stUv8OXY6CA8DOHXr+duXnhM/SihsY6H2nUYfMeV6Jkz6oS0u" +
            "CqdpkBTCCcuK4FjczAGl86atIIYFA2aiWs+pIrCV65wWYRRiR1DSvtU95s8BSr7k" +
            "fX6hiVFJ/2qAegC6czaINfhHKSCY3GVcy8oZeQCPLhwEwsNKCd5z3+3eVS5RByrP" +
            "LoDXoQEeGArGOEs56ZJyfDHvxkmB7VJHgowyBFUmcw==";
    }
}
