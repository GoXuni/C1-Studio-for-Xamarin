using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1Input101
{
    public static class License
    {
        public const string Key =
            "ABwBHAIcB3VDADEASQBuAHAAdQB0ADEAMAAxAISWG5IlUp7Cf0UTmLWZvLOxlOLq" +
            "3bZ1IHYkMcGNvO6xOqSjK32wjs6JbUujxVsNZlkoAlFdhCJvQoN44CDO77zE+Z8h" +
            "TKpF9s8lVsdjamMt+SSP5sQn6ESUQroJNu1YY1+0R0MU7dxOtInL/ApDR5DPEOQK" +
            "mbLW7uXZ4wIuzRp3JrQ04NqMHw7UHKM1KA7f6VZ9dYLomkGZRrd5UCRiOgpxUTKS" +
            "gVyCfV/Bvb6Y3a2QBU04J9x7l5GzLB5DPVTLru0sAA8fNQITTYgKOO7u2FRdvdal" +
            "Nghmi4Ec4tEnvHHs57swgayVPV4xvqq53WlKJsi5HIRH/pzD5XkUdeXR0Ns3R8EG" +
            "rdDRY6kNOWFgsVnVfKvHZRpSHVfcCUSeUs4u/pTo3d5AOrR8S0lvxCxmDSvRACWi" +
            "bpOnbrVwCC2BChzCkZ+4NRgzpT5KdYQjRAERCXXNPWi0NdeoXM15tj2aedMpOIsJ" +
            "OE2D075YfXxFWEdGUwNyM/nAOdhP65Q0B87CyLuf8lB8r4NM6pKLA1w/zPJnPkhO" +
            "vNjYvAvWAAWbLJVpJtC3yt1ZJa6w4xBHHUBgiVeVunhClcEp/HXQADRCEo8miEfb" +
            "7fGAGkyuhTr6KHHKXO7EcS+K/Bt56y3XcPtXiCR0uGH1srRPSVHMGYmDFKaPnGkt" +
            "mbD3kQVTRQxXz6NMMIIFVTCCBD2gAwIBAgIQQQN40iY2WXoW2ybGvRCUizANBgkq" +
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
            "hvcNAQEBBQADggEPADCCAQoCggEBAK+KJUY1KFEb0JjKB5LoG9ktgTy1MFolburw" +
            "MSHT8n6NOz7CKDFnRffVoQPXVrCgoKC9HrnWSAhupWdyU6ck8liJLCtBUq/sbK/s" +
            "afAaGveZGatUDu+rutzRFKzFUv9VLAa0x44r3PRWcXyL4EKll5njq3SVEYIGlpT7" +
            "+REGIQILei/MxdoNV7U6RINA9ubNH+R9qPV1Iar4Hdp2XTCtotANUKHSM9iMxR7V" +
            "IjUYV6a777+FDhZBQ5kkElsrWOgMXJOtfjGGwo+58VHBjHv7rUbxatZ+l8r0UU92" +
            "dHbwV0wpv+daM5Nn6iXkfhCM/rEOFt1/sR6SZQ6R/Rhvd2N0jcUCAwEAATANBgkq" +
            "hkiG9w0BAQUFAAOCAQEANKpuR5FurCtiLlQNyQjnrnjHC/aE8Mmq2jj2i7XuuI+M" +
            "V1KFox4PNcok2yDA85kqqPrBmZVVpkColAlZZkKgX365c+3BHAEHjpX927B9bQJO" +
            "5Ts82J6+jo0D/D42/bMfiTd2Ow8H0hve8oYa6a3APCPWlghu2NI5VcHrptQhG3Et" +
            "fhsgxU8NDHROD+fI8JPhUWWIsKJFGP2u7NRCTDT6SVkNLF+JZZQ4LLHELM/7qz4m" +
            "QLlxMzzBcI9gdr6YMmkQ5K6JB1F2OVaeqMoqWJx8nvNjGvhRDVAVVcrINMNFWCvR" +
            "Rkm+n/weEh6bqFYgOM18qpAmg/vfNoEGPndzzgP6lQ==";
    }

}
